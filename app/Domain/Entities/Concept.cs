using GenderDebate.Domain.Common;

namespace GenderDebate.Domain.Entities
{
    /// <summary>
    /// Conceitos centrais: "Sexo", "Gênero", "Sexo designado ao nascer", etc.
    /// </summary>
    public class Concept : Entity
    {
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;

        public ICollection<TermConcept> TermConcepts { get; private set; } = new List<TermConcept>();
        public ICollection<ArgumentConcept> ArgumentConcepts { get; private set; } = new List<ArgumentConcept>();

        private Concept() { }

        public Concept(string name, string description)
        {
            SetName(name);
            SetDescription(description);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));

            if (name.Length > 200)
                throw new ArgumentException("Name is too long (max 200 chars).", nameof(name));

            Name = name.Trim();
            Touch();
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty.", nameof(description));

            Description = description.Trim();
            Touch();
        }
    }
}
