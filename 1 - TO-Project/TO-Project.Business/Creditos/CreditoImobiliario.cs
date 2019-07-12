using System;
using TO_Project.Business.Interfaces;
using TO_Project.Util.Enums;

namespace TO_Project.Business.Creditos
{
    public class CreditoImobiliario : CreditoBase, ICredito
    {
        private const int TAXA_PERCENTUAL_JUROS = 9;

        public CreditoImobiliario(decimal valorCredito, int quantidadeParcelas, DateTime dataPrimeiroVencimento) :
            base(valorCredito, quantidadeParcelas, dataPrimeiroVencimento)
        {
            _tipoJuros = TipoJuros.Anual;
        }

        protected override int ObterTaxaJuros()
        {
            return TAXA_PERCENTUAL_JUROS;
        }
    }
}
