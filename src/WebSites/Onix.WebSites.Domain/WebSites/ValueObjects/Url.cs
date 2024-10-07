using CSharpFunctionalExtensions;

namespace Onix.WebSites.Domain.WebSites.ValueObjects;

public record Url
{
    private Url(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static Result<Url> Create(string value)
    {
        return new Url(value);
    }
}