namespace Domain;

public sealed class ProgrammingLanguage
{
    public ProgrammingLanguage(
        string name)
    {
        Name = name;
    }

    private ProgrammingLanguage()
    {
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = default!;
}