namespace Onix.WebSites.Application.Commands.WebSites.AddFAQ;

public record AddFAQCommand(
    Guid WebSiteId,
    string Question,
    string Answer);