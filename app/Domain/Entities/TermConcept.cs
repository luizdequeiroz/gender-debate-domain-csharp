namespace GenderDebate.Domain.Entities
{
    /// <summary>
    /// Relação N:N entre Termos e Conceitos (ex.: termo "homem biológico"
    /// ligado aos conceitos "sexo" e "gênero").
    /// </summary>
    public class TermConcept
    {
        public Guid TermId { get; set; }
        public Term Term { get; set; } = null!;

        public Guid ConceptId { get; set; }
        public Concept Concept { get; set; } = null!;
    }
}
