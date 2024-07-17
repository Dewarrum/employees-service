using Domain;

namespace Web.Models.ProgrammingLanguages;

public sealed record ProgrammingLanguageModel(int Id, string Name)
{
    public static ProgrammingLanguageModel From(ProgrammingLanguage pl) => new(pl.Id, pl.Name);
}