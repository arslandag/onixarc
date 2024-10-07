namespace Onix.SharedKernel.ValueObjects.Ids;

public record LocationId
{
    private LocationId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get; }

    public static LocationId NewId() => new(Guid.NewGuid());
    public static LocationId Empty() => new(Guid.Empty);
    public static LocationId Create(Guid id) => new(id);
}