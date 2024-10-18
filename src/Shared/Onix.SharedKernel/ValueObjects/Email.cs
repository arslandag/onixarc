using CSharpFunctionalExtensions;

namespace Onix.SharedKernel.ValueObjects;

public class Email
{
    private Email(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static Result<Email> Create(string value)
    {
        return new Email(value);
    }
}