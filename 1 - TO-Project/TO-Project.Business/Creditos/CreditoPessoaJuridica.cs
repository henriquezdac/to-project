using System;
using TO_Project.Business.Interfaces;
using TO_Project.Util.Enums;
using TO_Project.Util.Resources;

namespace TO_Project.Business.Creditos
{
    public class CreditoPessoaJuridica : CreditoBase, ICredito
    {
        private const int TAXA_PERCENTUAL_JUROS = 5;
        private const decimal VALOR_MINIMO_CREDITO = 15000.0M;

        public CreditoPessoaJuridica(decimal valorCredito, int quantidadeParcelas, DateTime dataPrimeiroVencimento) :
            base(valorCredito, quantidadeParcelas, dataPrimeiroVencimento)
        {
            _tipoJuros = TipoJuros.Mensal;
        }

        protected override void ValidarLimiteMinimo()
        {
            if (_valorCredito < VALOR_MINIMO_CREDITO)
                _erros.Add(Mensagens.Erro_CreditoPJ);
        }

        protected override int ObterTaxaJuros()
        {
            return TAXA_PERCENTUAL_JUROS;
        }
    }
}
