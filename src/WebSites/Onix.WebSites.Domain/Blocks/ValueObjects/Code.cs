using CSharpFunctionalExtensions;
using Onix.SharedKernel;

namespace Onix.WebSites.Domain.Blocks.ValueObjects;

public class Code
{
    private Code(string? value)
    {
        Value = value;
    }
    
    public string? Value { get; private set; }

    public static Result<Code, Error> Create(
        string? value)
    {
        return new Code(value);
    }
}