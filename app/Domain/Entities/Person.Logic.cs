using GenderDebate.Domain.Enums;

namespace GenderDebate.Domain.Entities
{
    public partial class Person
    {
        private void SetName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Name = null;
                return;
            }

            if (name.Length > 200)
                throw new ArgumentException("Name is too long (max 200 chars).", nameof(name));

            Name = name.Trim();
        }

        /// <summary>
        /// Exemplo simples: inferir se a pessoa é cis, com base na categoria de sexo e tipo de gênero.
        /// Na prática, isso poderia ser muito mais complexo, ou até removido.
        /// </summary>
        private void InferCisStatus()
        {
            if (AssignedSexAtBirth is null || SexProfile is null || GenderIdentity is null)
            {
                IsCis = null;
                return;
            }

            // Em casos intersexo/unknown não inferimos automaticamente
            if (AssignedSexAtBirth.Category is not (BiologicalSexCategory.Male or BiologicalSexCategory.Female))
            {
                IsCis = null;
                return;
            }

            if (GenderIdentity.Type == GenderIdentityType.Man &&
                AssignedSexAtBirth.Category == BiologicalSexCategory.Male)
            {
                IsCis = true;
            }
            else if (GenderIdentity.Type == GenderIdentityType.Woman &&
                     AssignedSexAtBirth.Category == BiologicalSexCategory.Female)
            {
                IsCis = true;
            }
            else
            {
                IsCis = false;
            }
        }
    }
}
