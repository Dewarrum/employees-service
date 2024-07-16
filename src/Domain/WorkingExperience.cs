namespace Domain;

public sealed class WorkingExperience
{
    public WorkingExperience(
        int employeeId,
        Employee employee,
        int programmingLanguageId,
        ProgrammingLanguage programmingLanguage,
        DateTime startDate,
        DateTime endDate)
    {
        EmployeeId = employeeId;
        Employee = employee;
        ProgrammingLanguageId = programmingLanguageId;
        ProgrammingLanguage = programmingLanguage;
        StartDate = startDate;
        EndDate = endDate;
    }

    private WorkingExperience()
    {
    }

    public int Id { get; private set; }
    public int EmployeeId { get; private set; }
    public Employee Employee { get; private set; } = default!;
    public int ProgrammingLanguageId { get; private set; }
    public ProgrammingLanguage ProgrammingLanguage { get; private set; } = default!;
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
}