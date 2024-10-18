namespace Onix.Core.Dtos;

public class LocationDto
{
    public Guid Id { get; init; }
    public Guid WebSiteId { get; init; }
    
    public string Name { get; init; } = string.Empty;
    public string LocationPhone { get; init; } = string.Empty;
    
    public string City { get; init; } = string.Empty;
    public string Street { get; init; } = string.Empty;
    public string Build { get; init; } = string.Empty;
    public string? Index { get; init; } = string.Empty;
    
    public List<ScheduleDto> Schedule { get; init; } = [];
}