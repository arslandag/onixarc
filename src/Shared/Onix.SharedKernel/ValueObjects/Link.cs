using CSharpFunctionalExtensions;

namespace Onix.SharedKernel.ValueObjects;

public class Link
{
    private Link(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static Result<Link> Create(string value)
    {
        return new Link(value);
    }
}