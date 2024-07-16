namespace Domain;

public sealed class Department
{
    public Department(
        string name,
        int floor)
    {
        Name = name;
        Floor = floor;
    }

    internal Department()
    {
    }

    public int Id { get; internal set; }
    public string Name { get; internal set; } = default!;
    public int Floor { get; internal set; }
    public ICollection<Employee> Employees { get; internal set; } = default!;
}