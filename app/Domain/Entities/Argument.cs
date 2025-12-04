using GenderDebate.Domain.Common;
using GenderDebate.Domain.Enums;

namespace GenderDebate.Domain.Entities
{
    /// <summary>
    /// Representa um argumento: pode ser explicação, objeção, réplica etc.
    /// Ex.: "A biologia não é tão simples", "Mas o DNA não muda!".
    /// </summary>
    public class Argument : Entity
    {
        public string Title { get; private set; } = null!;
        public string Content { get; private set; } = null!;
        public ArgumentType Type { get; private set; }

        public Guid? ParentArgumentId { get; private set; }
        public Argument? ParentArgument { get; private set; }

        public ICollection<Argument> Children { get; private set; } = new List<Argument>();

        public ICollection<ArgumentConcept> ArgumentConcepts { get; private set; } = new List<ArgumentConcept>();
        public ICollection<ArgumentTerm> ArgumentTerms { get; private set; } = new List<ArgumentTerm>();
        public ICollection<PersonArgument> PersonArguments { get; private set; } = new List<PersonArgument>();

        private Argument() { }

        public Argument(
            string title,
            string content,
            ArgumentType type,
            Argument? parentArgument = null)
        {
            SetTitle(title);
            SetContent(content);
            Type = type;

            if (parentArgument is not null)
            {
                ParentArgument = parentArgument;
                ParentArgumentId = parentArgument.Id;
                parentArgument.Children.Add(this);
            }
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.", nameof(title));

            if (title.Length > 300)
                throw new ArgumentException("Title too long (max 300 chars).", nameof(title));

            Title = title.Trim();
            Touch();
        }

        public void SetContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Content cannot be empty.", nameof(content));

            Content = content.Trim();
            Touch();
        }

        public void ChangeType(ArgumentType newType)
        {
            Type = newType;
            Touch();
        }
    }
}
