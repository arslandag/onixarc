using CSharpFunctionalExtensions;

namespace Onix.SharedKernel.ValueObjects;

public class Description
{
    private Description(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static Result<Description> Create(string value)
    {
        return new Description(value);
    }
}