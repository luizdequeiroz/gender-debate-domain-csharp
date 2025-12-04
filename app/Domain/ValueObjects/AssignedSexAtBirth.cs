using GenderDebate.Domain.Common;
using GenderDebate.Domain.Enums;

namespace GenderDebate.Domain.ValueObjects
{
    /// <summary>
    /// Representa o rótulo inicial que a pessoa recebe na certidão.
    /// Ex.: "designado homem ao nascer".
    /// </summary>
    public sealed class AssignedSexAtBirth : ValueObject
    {
        public BiologicalSexCategory Category { get; }
        public SexAssignmentBasis Basis { get; }
        public string? Notes { get; }

        private AssignedSexAtBirth() { }

        public AssignedSexAtBirth(
            BiologicalSexCategory category,
            SexAssignmentBasis basis,
            string? notes = null)
        {
            Category = category;
            Basis = basis;
            Notes = string.IsNullOrWhiteSpace(notes) ? null : notes.Trim();
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Category;
            yield return Basis;
            yield return Notes;
        }

        public override string ToString()
            => $"{Category} (basis: {Basis})";
    }
}
