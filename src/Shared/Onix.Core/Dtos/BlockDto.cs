namespace Onix.Core.Dtos;

public class BlockDto
{
     public Guid Id { get; init; }
     public string Title { get; init; } = string.Empty;
     public string Description { get; init; } = string.Empty;

     public PhotoDto BackPhoto { get; init; } = null!;

     public ServiceDto[] Services { get; init; } = null!;
     public ProductDto[] Products { get; init; } = null!;
     public EmployeeDto[] Employees { get; init; } = null!;
     public PhotoDto[] Photos { get; init; } = null!;
}