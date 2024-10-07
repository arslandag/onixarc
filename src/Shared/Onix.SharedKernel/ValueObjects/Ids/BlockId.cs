namespace Onix.SharedKernel.ValueObjects.Ids;

public class BlockId
{
    private BlockId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get; }

    public static BlockId NewUserId() => new(Guid.NewGuid());
    public static BlockId Empty() => new(Guid.Empty);
    public static BlockId Create(Guid id) => new(id);
}