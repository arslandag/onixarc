namespace Onix.WebSites.Application.Commands.WebSites.AddLocation;

public record AddLocationCommand(
    Guid WebSiteId,
    string Name,
    string Phone,
    string City,
    string Street,
    string Build,
    string Index);