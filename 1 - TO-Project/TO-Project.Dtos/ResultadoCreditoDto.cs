using System.Collections.Generic;
using System.Linq;
using TO_Project.Util.Enums;

namespace TO_Project.Dtos
{
    public class ResultadoCreditoDto
    {
        public List<string> Erros { get; set; }
        public SituacaoCredito SituacaoCredito
        {
            get
            {
                return Erros.Any() ? SituacaoCredito.Reprovado : SituacaoCredito.Aprovado;
            }
        }
        public decimal ValorTotal { get; set; }
        public decimal ValorJuros { get; set; }
    }
}