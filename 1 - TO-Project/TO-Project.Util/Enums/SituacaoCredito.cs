namespace TO_Project.Util.Enums
{
    public enum SituacaoCredito
    {
        Aprovado = 1,
        Reprovado = 2
    }

    public static class SituacaoCreditoComplemento
    {
        public static bool EhAprovado(this SituacaoCredito situacaoCredito)
        {
            return situacaoCredito == SituacaoCredito.Aprovado;
        }
    }
}
