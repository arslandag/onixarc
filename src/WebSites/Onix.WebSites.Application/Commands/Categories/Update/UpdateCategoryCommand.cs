using Onix.Core.Abstraction;

namespace Onix.WebSites.Application.Commands.Categories.Update;

public record UpdateCategoryCommand(
    Guid WebSiteId,
    Guid CategoryId,
    string Name) : ICommand;