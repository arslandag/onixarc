namespace Onix.Core.Dtos;

public class WebSiteDto
{
    public Guid Id { get; init; }
    public string Url { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Phone { get; init; } = string.Empty;
    public bool ShowStatus { get; init; }
    
    public string ColorScheme { get; init; } = string.Empty;
    public int ButtonAngle { get; init; }
    public string ButtonStyle { get; init; } = string.Empty;
    public string Font { get; init; } = string.Empty;
    public PhotoDto Favicon { get; init; } = null!;

    public SocialDto[] Socials { get; init; } = null!;

    public BlockDto[] Blocks { get; init; } = null!;
}