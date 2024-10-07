using CSharpFunctionalExtensions;

namespace Onix.Account.Domain.Users.ValueObjects;

public record PasswordHash
{
    private PasswordHash(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static Result<PasswordHash> Create(string value)
    {
        return new PasswordHash(value);
    }
}