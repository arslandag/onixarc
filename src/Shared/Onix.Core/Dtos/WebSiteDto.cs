namespace Onix.Core.Dtos;

public class WebSiteDto
{
    public Guid Id { get; init; }
    
    public string Url { get; init; } = string.Empty;
    public bool ShowStatus { get; init; }
    
    public string Name { get; init; } = string.Empty;
    
    public string ColorScheme { get; init; } = string.Empty;
    public string ButtonStyle { get; init; } = string.Empty;
    public string Font { get; init; } = string.Empty;
    
    public string Phone { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;

    public List<PhotoDto> Favicon { get; init; } = [];
    public List<SocialDto> SocialMedias { get; init; } = [];
    public List<DataSolutionDto> FAQs { get; init; } = [];
    public List<BlockDto> Blocks { get; init; } = [];
    public List<CategoryDto> Categories { get; init; } = [];
    public List<LocationDto> Location { get; init; } = [];
}