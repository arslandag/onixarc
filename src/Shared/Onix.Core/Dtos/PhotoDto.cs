namespace Onix.Core.Dtos;

public class PhotoDto
{
    public Guid Id { get; init; }
    
    public Guid WebSiteId { get; init; }
    public Guid ProductId { get; init; }
    public Guid ServiceId { get; init; }
    
    public string Path { get; init; } = string.Empty;
}