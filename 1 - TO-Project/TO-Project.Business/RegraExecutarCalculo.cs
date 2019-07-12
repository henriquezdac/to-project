using System;
using TO_Project.Business.Creditos;
using TO_Project.Business.Interfaces;
using TO_Project.Dtos;
using TO_Project.Util.Enums;
using TO_Project.Util.Resources;

namespace TO_Project.Business
{
    public static  class RegraExecutarCalculo
    {
        public static ResultadoCreditoDto Executar(TipoCredito tipoCredito, decimal valorCredito, int quantidadeParcelas, DateTime dataPrimeiroVencimento)
        {
            var interfaceCredito = ObterInterface(tipoCredito, valorCredito, quantidadeParcelas, dataPrimeiroVencimento);
            return interfaceCredito.ExecutarCalculo();
        }

        #region Métodos privados
        private static ICredito ObterInterface(TipoCredito tipoCredito, decimal valorCredito, int quantidadeParcelas, DateTime dataPrimeiroVencimento)
        {
            switch (tipoCredito)
            {
                case TipoCredito.Direto:
                    return new CreditoDireto(valorCredito, quantidadeParcelas, dataPrimeiroVencimento);
                case TipoCredito.Consignado:
                    return new CreditoConsignado(valorCredito, quantidadeParcelas, dataPrimeiroVencimento);
                case TipoCredito.PessoaJuridica:
                    return new CreditoPessoaJuridica(valorCredito, quantidadeParcelas, dataPrimeiroVencimento);
                case TipoCredito.PessoaFisica:
                    return new CreditoPessoaFisica(valorCredito, quantidadeParcelas, dataPrimeiroVencimento);
                case TipoCredito.Imobiliario:
                    return new CreditoImobiliario(valorCredito, quantidadeParcelas, dataPrimeiroVencimento);
                default:
                    throw new Exception(Mensagens.Erro_ParametroNaoMapeado);
            }
        }
        #endregion
    }
}
