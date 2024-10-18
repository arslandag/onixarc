namespace Onix.Core.Dtos;

public class CategoryDto
{
    public Guid Id { get; init; }
    public Guid WebSiteId { get; init; } = Guid.Empty;
    public Guid ParentId { get; init; }

    public string Name { get; init; } = string.Empty;

    public List<CategoryDto> SubCategories { get; init; } = [];
    
    public List<ServiceDto> Services { get; init; } = [];
    public List<ProductDto> Products { get; init; } = [];
}