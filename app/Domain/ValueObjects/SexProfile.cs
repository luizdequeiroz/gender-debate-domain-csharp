using GenderDebate.Domain.Common;
using GenderDebate.Domain.Enums;

namespace GenderDebate.Domain.ValueObjects
{
    /// <summary>
    /// Perfil biológico mais completo (cromossomos, hormônios etc.).
    /// Mostra a multidimensionalidade do sexo.
    /// </summary>
    public sealed class SexProfile : ValueObject
    {
        public BiologicalSexCategory Category { get; }
        public string? ChromosomalPattern { get; }
        public string? GonadalDescription { get; }
        public string? HormonalProfile { get; }
        public string? GenitalDescription { get; }
        public string? AdditionalNotes { get; }

        private SexProfile() { }

        public SexProfile(
            BiologicalSexCategory category,
            string? chromosomalPattern = null,
            string? gonadalDescription = null,
            string? hormonalProfile = null,
            string? genitalDescription = null,
            string? additionalNotes = null)
        {
            Category = category;
            ChromosomalPattern = Normalize(chromosomalPattern);
            GonadalDescription = Normalize(gonadalDescription);
            HormonalProfile = Normalize(hormonalProfile);
            GenitalDescription = Normalize(genitalDescription);
            AdditionalNotes = Normalize(additionalNotes);
        }

        private static string? Normalize(string? value)
            => string.IsNullOrWhiteSpace(value) ? null : value.Trim();

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Category;
            yield return ChromosomalPattern;
            yield return GonadalDescription;
            yield return HormonalProfile;
            yield return GenitalDescription;
            yield return AdditionalNotes;
        }
    }
}
