namespace Onix.WebSites.Application.Commands.FAQ.Add;

public record AddFAQCommand(
    Guid WebSiteId,
    string Question,
    string Answer);