using CSharpFunctionalExtensions;

namespace Onix.SharedKernel.ValueObjects;

public class Path
{
    private Path(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static Result<Path> Create(string value)
    {
        return new Path(value);
    }
}