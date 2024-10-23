namespace Onix.WebSites.Application.Commands.Categories.Add;

public record AddCategoryCommand(
    Guid WebSiteId,
    string Name);