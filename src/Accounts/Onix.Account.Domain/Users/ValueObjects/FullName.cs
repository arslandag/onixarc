using CSharpFunctionalExtensions;

namespace Onix.Account.Domain.Users.ValueObjects;

public record FullName
{
    private FullName(
        string firstName,
        string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; }
    public string LastName { get; }

    public static Result<FullName> Create(
        string firstName,
        string lastName)
    {
        return new FullName(firstName,lastName);
    }
}