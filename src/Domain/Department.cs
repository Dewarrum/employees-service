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

    private Department()
    {
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = default!;
    public int Floor { get; private set; }
    public ICollection<Employee> Employees { get; private set; } = default!;
}