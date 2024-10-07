namespace Onix.SharedKernel.ValueObjects.Ids;

public class EmployeeId
{
    private EmployeeId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get; }

    public static EmployeeId NewId() => new(Guid.NewGuid());
    public static EmployeeId Empty() => new(Guid.Empty);
    public static EmployeeId Create(Guid id) => new(id);
}