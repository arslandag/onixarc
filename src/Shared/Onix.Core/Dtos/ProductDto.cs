namespace Onix.Core.Dtos;

public class ProductDto
{
    public Guid Id { get; init; }
    public Guid BlockId { get; init; }
    
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public int? Price { get; init; }
    public string? Link { get; init; } = string.Empty;

    public List<PhotoDto> Photos { get; init; } = [];
}