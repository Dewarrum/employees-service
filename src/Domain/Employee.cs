﻿namespace Domain;

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
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public int Age { get; private set; }
    public Gender Gender { get; private set; }
    public int DepartmentId { get; private set; }
    public Department Department { get; private set; } = default!;
}