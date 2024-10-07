namespace Onix.SharedKernel.ValueObjects.Ids;

public record PhotoId
{
    private PhotoId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get;}

    public static PhotoId NewId() => new(Guid.NewGuid());
    public static PhotoId Empty() => new(Guid.Empty);
    public static PhotoId Create(Guid id) => new(id);
}