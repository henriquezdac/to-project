using System;
using TO_Project.Business.Interfaces;
using TO_Project.Util.Enums;

namespace TO_Project.Business.Creditos
{
    public class CreditoPessoaFisica : CreditoBase, ICredito
    {
        private const int TAXA_PERCENTUAL_JUROS = 3;

        public CreditoPessoaFisica(decimal valorCredito, int quantidadeParcelas, DateTime dataPrimeiroVencimento) :
            base(valorCredito, quantidadeParcelas, dataPrimeiroVencimento)
        {
            _tipoJuros = TipoJuros.Mensal;
        }

        protected override int ObterTaxaJuros()
        {
            return TAXA_PERCENTUAL_JUROS;
        }
    }
}
