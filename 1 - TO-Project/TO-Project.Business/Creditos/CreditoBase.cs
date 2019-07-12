using System;
using System.Collections.Generic;
using TO_Project.Dtos;
using TO_Project.Util.Enums;
using TO_Project.Util.Resources;

namespace TO_Project.Business.Creditos
{
    public abstract class CreditoBase
    {
        private const decimal VALOR_MINIMO_CREDITO = 0.0M;
        private const decimal VALOR_MAXIMO_CREDITO = 1000000.0M;
        protected readonly decimal _valorCredito;
        protected readonly int _quantidadeParcelas;
        protected readonly DateTime _dataPrimeiroVencimento;
        protected TipoJuros _tipoJuros;
        protected List<string> _erros;

        public CreditoBase(decimal valorCredito, int quantidadeParcelas, DateTime dataPrimeiroVencimento)
        {
            _valorCredito = valorCredito;
            _quantidadeParcelas = quantidadeParcelas;
            _dataPrimeiroVencimento = dataPrimeiroVencimento;
            _erros = new List<string>();
        }

        public ResultadoCreditoDto ExecutarCalculo()
        {
            Validar();
            var valorJuros = CalcularValorJuros();

            return new ResultadoCreditoDto
            {
                Erros = _erros,
                ValorTotal = _valorCredito + valorJuros,
                ValorJuros = valorJuros
            };
        }

        protected abstract int ObterTaxaJuros();
        protected virtual void ValidarLimiteMinimo()
        {
        }

        #region Métodos privados
        private void Validar()
        {
            ValidarValorCredito();
            ValidarQuantidadeParcelas();
            ValidarLimiteMinimo();
            ValidarDataPrimeiroVencimento();
        }
        private void ValidarValorCredito()
        {
            if (_valorCredito < VALOR_MINIMO_CREDITO)
                _erros.Add(Mensagens.Erro_ValorCreditoInvalido);
            if (_valorCredito >= VALOR_MAXIMO_CREDITO)
                _erros.Add(Mensagens.Erro_ValorMaximoUltrapassado);
        }
        private void ValidarQuantidadeParcelas()
        {
            if (_quantidadeParcelas < 5 || _quantidadeParcelas > 72)
                _erros.Add(Mensagens.Erro_QuantidadeParcelas);
        }
        private void ValidarDataPrimeiroVencimento()
        {
            var dataMinima = DateTime.Now.AddDays(15);
            var dataMaxima = DateTime.Now.AddDays(40);
            if (_dataPrimeiroVencimento < dataMinima | _dataPrimeiroVencimento > dataMaxima)
                _erros.Add(string.Format(Mensagens.Erro_DataPrimeiroVencimento, dataMinima.ToString("dd/MM/yyyy"), dataMaxima.ToString("dd/MM/yyyy")));
        }
        private decimal CalcularValorJuros()
        {
            /*Conforme especificado: Para este exercício, os juros são calculados da seguinte forma, incremente a porcentagem de juros no valor total do crédito */
            return _valorCredito * ObterTaxaJuros() / 100.0M;
        }
        #endregion
    }
}