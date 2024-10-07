using CSharpFunctionalExtensions;

namespace Onix.WebSites.Domain.WebSites.ValueObjects;

public record Title
{
    private Title(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static Result<Title> Create(string value)
    {
        return new Title(value);
    }
}