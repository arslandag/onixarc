namespace Onix.SharedKernel.ValueObjects.Ids;

public class ServiceId
{
    private ServiceId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get; }

    public static ServiceId NewId() => new(Guid.NewGuid());
    public static ServiceId Empty() => new(Guid.Empty);
    public static ServiceId Create(Guid id) => new(id);
}