using CSharpFunctionalExtensions;

namespace Onix.WebSites.Domain.Categories.ValueObjects;

public record Price
{
    private Price(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static Result<Price> Create(string value)
    {
        return new Price(value);
    }
}