namespace GenderDebate.Domain.Entities
{
    /// <summary>
    /// Liga uma pessoa a argumentos que ela usa num debate (ex.: o seu "kit de argumentação").
    /// </summary>
    public class PersonArgument
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; } = null!;

        public Guid ArgumentId { get; set; }
        public Argument Argument { get; set; } = null!;

        /// <summary>
        /// Ordem de prioridade/uso desse argumento pela pessoa.
        /// </summary>
        public int Priority { get; set; }
    }
}
