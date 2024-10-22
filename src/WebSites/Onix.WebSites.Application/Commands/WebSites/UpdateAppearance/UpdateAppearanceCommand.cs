namespace Onix.WebSites.Application.Commands.WebSites.UpdateAppearance;

public record UpdateAppearanceCommand(
    Guid WebSiteId,
    string ColorScheme,
    string ButtonStyle,
    string Font);