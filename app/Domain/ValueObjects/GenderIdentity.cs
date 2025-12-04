using GenderDebate.Domain.Common;
using GenderDebate.Domain.Enums;

namespace GenderDebate.Domain.ValueObjects
{
    /// <summary>
    /// Identidade de gênero: como a pessoa se percebe e se apresenta.
    /// </summary>
    public sealed class GenderIdentity : ValueObject
    {
        public GenderIdentityType Type { get; }
        public string? SelfDescription { get; }

        private GenderIdentity() { }

        public GenderIdentity(GenderIdentityType type, string? selfDescription = null)
        {
            Type = type;
            SelfDescription = string.IsNullOrWhiteSpace(selfDescription)
                ? null
                : selfDescription.Trim();
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Type;
            yield return SelfDescription;
        }

        public override string ToString()
            => SelfDescription ?? Type.ToString();
    }
}
