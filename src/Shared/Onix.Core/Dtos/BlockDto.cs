namespace Onix.Core.Dtos;

public class BlockDto
{
     public Guid Id { get; init; }
     public Guid WebSiteId { get; init; }
     
     public string Title { get; init; } = string.Empty;
     public string Description { get; init; } = string.Empty;

     public PhotoDto? BackPhoto { get; init; }

     public List<ServiceDto> Services { get; init; } = [];
     public List<ProductDto> Products { get; init; } = [];
     public List<EmployeeDto> Employees { get; init; } = [];
     public List<PhotoDto> Photos { get; init; } = [];
     public List<LocationDto> Location { get; init; } = [];
}