namespace Onix.WebSites.Application.Commands.WebSites.AddSocial;

public record AddSocialCommand(
    Guid WebSiteId,
    string Social,
    string Link);