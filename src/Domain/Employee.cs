namespace Domain;

public sealed class Employee
{
    public Employee(
        string firstName,
        string lastName,
        int age,
        Gender gender,
        int departmentId)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Gender = gender;
        DepartmentId = departmentId;
    }

    private Employee()
    {
    }

    public int Id { get; private set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; private set; } = default!;
    public ICollection<WorkingExperience> WorkingExperiences { get; private set; } = default!;
}