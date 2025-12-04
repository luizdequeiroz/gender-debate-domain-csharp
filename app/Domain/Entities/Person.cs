using GenderDebate.Domain.Common;
using GenderDebate.Domain.ValueObjects;

namespace GenderDebate.Domain.Entities
{
    /// <summary>
    /// Representa uma pessoa no sistema (para fins de exemplo de modelagem).
    /// </summary>
    public partial class Person : Entity
    {
        public string? Name { get; private set; }
        public DateOnly? DateOfBirth { get; private set; }

        /// <summary>
        /// Rótulo inicial: "designado homem/mulher ao nascer" etc.
        /// </summary>
        public AssignedSexAtBirth AssignedSexAtBirth { get; private set; } = default!;

        /// <summary>
        /// Perfil biológico mais detalhado (pode não estar todo preenchido).
        /// </summary>
        public SexProfile SexProfile { get; private set; } = default!;

        /// <summary>
        /// Identidade de gênero atual da pessoa.
        /// </summary>
        public GenderIdentity GenderIdentity { get; private set; } = default!;

        /// <summary>
        /// Indica se a pessoa se identifica com o sexo atribuído ao nascer.
        /// </summary>
        public bool? IsCis { get; private set; }

        /// <summary>
        /// Exemplo de relacionamento com termos/argumentos no sistema.
        /// </summary>
        public ICollection<PersonArgument> PersonArguments { get; private set; } = new List<PersonArgument>();

        private Person() { }

        public Person(
            string? name,
            DateOnly? dateOfBirth,
            AssignedSexAtBirth assignedSexAtBirth,
            SexProfile sexProfile,
            GenderIdentity genderIdentity)
        {
            SetName(name);
            DateOfBirth = dateOfBirth;
            AssignedSexAtBirth = assignedSexAtBirth ?? throw new ArgumentNullException(nameof(assignedSexAtBirth));
            SexProfile = sexProfile ?? throw new ArgumentNullException(nameof(sexProfile));
            GenderIdentity = genderIdentity ?? throw new ArgumentNullException(nameof(genderIdentity));

            InferCisStatus();
        }

        public void UpdateGenderIdentity(GenderIdentity newIdentity)
        {
            GenderIdentity = newIdentity ?? throw new ArgumentNullException(nameof(newIdentity));
            InferCisStatus();
            Touch();
        }

        public void UpdateSexProfile(SexProfile newProfile)
        {
            SexProfile = newProfile ?? throw new ArgumentNullException(nameof(newProfile));
            Touch();
        }

        public void UpdateAssignedSexAtBirth(AssignedSexAtBirth newAssignedSex)
        {
            AssignedSexAtBirth = newAssignedSex ?? throw new ArgumentNullException(nameof(newAssignedSex));
            InferCisStatus();
            Touch();
        }
    }
}
