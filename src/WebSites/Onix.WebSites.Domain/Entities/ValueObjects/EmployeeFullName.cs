using CSharpFunctionalExtensions;

namespace Onix.WebSites.Domain.Entities.ValueObjects;

public record EmployeeFullName
{
    private EmployeeFullName(
        string lastName, 
        string firstName,
        string patronymic)
    {
        LastName = lastName;
        FirstName = firstName;
        Patronymic = patronymic;
    }

    public string? LastName { get; }
    public string FirstName { get; }
    public string? Patronymic { get; }

    public static Result<EmployeeFullName> Create(
        string? lastName,
        string firstName,
        string? patronymic)
    {
        return new EmployeeFullName(
            lastName,
            firstName,
            patronymic);
    }
}