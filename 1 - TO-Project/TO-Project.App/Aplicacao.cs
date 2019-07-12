using System;
using System.Linq;
using System.Windows.Forms;
using TO_Project.Business;
using TO_Project.Dtos;
using TO_Project.Util.Enums;
using TO_Project.Util.Resources;

namespace TO_Project.App
{
    public partial class Aplicacao : Form
    {
        public Aplicacao()
        {
            InitializeComponent();
            this.cmbTipoCredito.Items.Add("Crédito Direto");
            this.cmbTipoCredito.Items.Add("Crédito Consignado");
            this.cmbTipoCredito.Items.Add("Crédito Pessoa Jurídica");
            this.cmbTipoCredito.Items.Add("Crédito Pessoa Física");
            this.cmbTipoCredito.Items.Add("Crédito Imobiliário");
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            this.txtRetorno.ResetText();

            ResultadoCreditoDto retorno = ObterRetorno();
            if (retorno == null)
                return;

            if (retorno.Erros.Any())
            {
                AdicionarTextoRetorno("Erros de validação: ");
                AdicionarQuebraLinhaTextoRetorno();
                retorno.Erros.ForEach(x => { AdicionarTextoRetorno("-" + x); AdicionarQuebraLinhaTextoRetorno(); });
                return;
            }

            AdicionarTextoRetorno("Status do crédito: ");
            AdicionarTextoRetorno(retorno.SituacaoCredito.EhAprovado() ? "Aprovado" : "Reprovado");
            AdicionarQuebraLinhaTextoRetorno();
            AdicionarTextoRetorno("Valor total com juros: ");
            AdicionarTextoRetorno(retorno.ValorTotal.ToString("C"));
            AdicionarQuebraLinhaTextoRetorno();
            AdicionarTextoRetorno("Valor do Juros: ");
            AdicionarTextoRetorno(retorno.ValorJuros.ToString("C"));
        }

        private void AdicionarTextoRetorno(string texto)
        {
            this.txtRetorno.Text += texto;
        }

        private void AdicionarQuebraLinhaTextoRetorno()
        {
            AdicionarTextoRetorno("\r\n");
        }

        private ResultadoCreditoDto ObterRetorno()
        {
            try
            {
                var valorCredito = TratarValorCredito();
                var tipoCredito = ObterTipoCredito();
                var quantidadeParcelas = ObterQuantidadeParcelas();
                var dataPrimeiroVencimento = ObterDataPrimeiroVencimento();
                return RegraExecutarCalculo.Executar(tipoCredito, valorCredito, quantidadeParcelas, dataPrimeiroVencimento);
            }
            catch (Exception ex)
            {
                this.txtRetorno.Text = ex.Message;
                return null;
            }
        }

        private decimal TratarValorCredito()
        {
            if (!decimal.TryParse(this.txtValorCredito.Text.Replace("R$", "").Replace(" ", "").TrimStart().TrimEnd(), out decimal valorCredito))
                throw new Exception(Mensagens.Erro_ValorCreditoInvalido2);

            return valorCredito;
        }

        private TipoCredito ObterTipoCredito()
        {
            switch (this.cmbTipoCredito.SelectedIndex)
            {
                case 0:
                    return TipoCredito.Direto;
                case 1:
                    return TipoCredito.Consignado;
                case 2:
                    return TipoCredito.PessoaJuridica;
                case 3:
                    return TipoCredito.PessoaFisica;
                case 4:
                    return TipoCredito.Imobiliario;
                default:
                    throw new Exception(Mensagens.Erro_TipoCreditoInvalido);
            }
        }

        private int ObterQuantidadeParcelas()
        {
            if (!int.TryParse(this.txtQtdParcelas.Text, out int quantidadeParcelas))
                throw new Exception(Mensagens.Erro_QuantidadeParcelasInvalida);

            return quantidadeParcelas;
        }

        private DateTime ObterDataPrimeiroVencimento()
        {
            if (!DateTime.TryParse(this.txtDataPrimeiroVencimento.Text, out DateTime dataPrimeiroVencimento))
                throw new Exception(Mensagens.Erro_DataPrimeiroVencimentoInvalida);

            return dataPrimeiroVencimento;
        }
    }
}