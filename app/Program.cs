// See https://aka.ms/new-console-template for more information
using GenderDebate.Domain.Entities;
using GenderDebate.Domain.Enums;
using GenderDebate.Domain.ValueObjects;

Console.WriteLine("Hello, World!");

// Criando uma pessoa de exemplo:
var assigned = new AssignedSexAtBirth(
    BiologicalSexCategory.Male,
    SexAssignmentBasis.ExternalGenitalia,
    notes: "Atribuído com base em observação clínica ao nascer."
);

var sexProfile = new SexProfile(
    BiologicalSexCategory.Male,
    chromosomalPattern: "46,XY",
    genitalDescription: "Genitália típica masculina"
);

var genderIdentity = new GenderIdentity(
    GenderIdentityType.Woman,
    selfDescription: "Mulher trans"
);

var person = new Person(
    name: "Exemplo",
    dateOfBirth: new DateOnly(1992, 11, 28),
    assignedSexAtBirth: assigned,
    sexProfile: sexProfile,
    genderIdentity: genderIdentity
);

Console.WriteLine($"Pessoa criada: {person.Name}, Identidade de gênero: {person.GenderIdentity}.");
Console.WriteLine(person.IsCis);

// Aqui, person.IsCis provavelmente será false,
// segundo a lógica simplificada de inferência.
