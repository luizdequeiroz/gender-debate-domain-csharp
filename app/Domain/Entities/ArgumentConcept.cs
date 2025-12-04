namespace GenderDebate.Domain.Entities
{
    /// <summary>
    /// Relação N:N entre Argumentos e Conceitos.
    /// Ex.: argumento "Sexo é multidimensional" ligado ao conceito "Sexo".
    /// </summary>
    public class ArgumentConcept
    {
        public Guid ArgumentId { get; set; }
        public Argument Argument { get; set; } = null!;

        public Guid ConceptId { get; set; }
        public Concept Concept { get; set; } = null!;
    }
}
