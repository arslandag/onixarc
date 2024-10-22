namespace Onix.WebSites.Application.Commands.WebSites.AddCategory;

public record AddCategoryCommand(
    Guid WebSiteId,
    string Name);