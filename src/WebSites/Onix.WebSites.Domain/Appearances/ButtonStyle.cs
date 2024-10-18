using CSharpFunctionalExtensions;

namespace Onix.WebSites.Domain.Appearances;

public record ButtonStyle
{
    private  ButtonStyle(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static Result<ButtonStyle> Create(string value)
    {
        return new ButtonStyle(value);
    }
}