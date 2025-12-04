namespace GenderDebate.Domain.Entities
{
    /// <summary>
    /// Relação N:N entre Argumentos e Termos.
    /// Ex.: argumento "Evite 'homem biológico'" ligado ao termo "homem biológico".
    /// </summary>
    public class ArgumentTerm
    {
        public Guid ArgumentId { get; set; }
        public Argument Argument { get; set; } = null!;

        public Guid TermId { get; set; }
        public Term Term { get; set; } = null!;
    }
}
