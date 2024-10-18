namespace Onix.SharedKernel.ValueObjects.Ids;

public class CategoryId
{
    private CategoryId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get; }

    public static CategoryId NewId() => new(Guid.NewGuid());
    public static CategoryId Empty() => new(Guid.Empty);
    public static CategoryId Create(Guid id) => new(id);
}