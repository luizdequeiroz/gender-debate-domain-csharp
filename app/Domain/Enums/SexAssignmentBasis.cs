namespace GenderDebate.Domain.Enums
{
    /// <summary>
    /// Base usada para atribuir o sexo ao nascer.
    /// Mostra que é um ato interpretativo, não exame completo.
    /// </summary>
    public enum SexAssignmentBasis
    {
        Unknown = 0,
        ExternalGenitalia = 1,
        ChromosomalTest = 2,
        HormonalProfile = 3,
        MixedCriteria = 4
    }
}
