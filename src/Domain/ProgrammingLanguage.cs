namespace Domain;

public sealed class ProgrammingLanguage
{
    public ProgrammingLanguage(
        string name)
    {
        Name = name;
    }

    internal ProgrammingLanguage()
    {
    }

    public int Id { get; internal set; }
    public string Name { get; internal set; } = default!;
    public ICollection<WorkingExperience> WorkingExperiences { get; internal set; } = default!;
}