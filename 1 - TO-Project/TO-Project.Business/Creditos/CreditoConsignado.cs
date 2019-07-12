using System;
using TO_Project.Business.Interfaces;
using TO_Project.Util.Enums;

namespace TO_Project.Business.Creditos
{
    public class CreditoConsignado : CreditoBase, ICredito
    {
        private const int TAXA_PERCENTUAL_JUROS = 1;

        public CreditoConsignado(decimal valorCredito, int quantidadeParcelas, DateTime dataPrimeiroVencimento) :
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
