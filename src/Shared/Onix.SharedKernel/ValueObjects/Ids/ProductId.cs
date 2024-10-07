namespace Onix.SharedKernel.ValueObjects.Ids;

public class ProductId
{
    private ProductId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get;}

    public static ProductId NewId() => new(Guid.NewGuid());
    public static ProductId Empty() => new(Guid.Empty);
    public static ProductId Create(Guid id) => new(id);
}