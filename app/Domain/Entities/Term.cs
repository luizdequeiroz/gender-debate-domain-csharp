using GenderDebate.Domain.Common;
using GenderDebate.Domain.Enums;

namespace GenderDebate.Domain.Entities
{
    /// <summary>
    /// Termos usados no discurso: ex.: "homem biológico", "sexo designado ao nascer".
    /// </summary>
    public class Term : Entity
    {
        public string Text { get; private set; } = null!;
        public TermCategory Category { get; private set; }
        public string? Definition { get; private set; }
        public bool IsDeprecated { get; private set; }

        public ICollection<TermConcept> TermConcepts { get; private set; } = new List<TermConcept>();
        public ICollection<ArgumentTerm> ArgumentTerms { get; private set; } = new List<ArgumentTerm>();

        private Term() { }

        public Term(string text, TermCategory category, string? definition = null, bool isDeprecated = false)
        {
            SetText(text);
            Category = category;
            Definition = string.IsNullOrWhiteSpace(definition) ? null : definition.Trim();
            IsDeprecated = isDeprecated;
        }

        public void SetText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Text cannot be empty.", nameof(text));

            if (text.Length > 200)
                throw new ArgumentException("Text is too long (max 200 chars).", nameof(text));

            Text = text.Trim();
            Touch();
        }

        public void MarkDeprecated(bool deprecated = true)
        {
            IsDeprecated = deprecated;
            Touch();
        }

        public void UpdateDefinition(string? definition)
        {
            Definition = string.IsNullOrWhiteSpace(definition) ? null : definition.Trim();
            Touch();
        }
    }
}
