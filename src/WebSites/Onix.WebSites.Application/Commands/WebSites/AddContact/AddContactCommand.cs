namespace Onix.WebSites.Application.Commands.WebSites.AddContact;

public record AddContactCommand(
    Guid WebSiteId,
    string Phone,
    string Email);