using CSharpFunctionalExtensions;

namespace Onix.WebSites.Domain.ConfigSite;

public record ColorScheme
{
    private  ColorScheme(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static Result<ColorScheme> Create(string value)
    {
        return new ColorScheme(value);
    }
}