using Onix.Core.Abstraction;

namespace Onix.WebSites.Application.Commands.Categories.Delete;

public record DeleteCategoryCommand(
    Guid WebSiteId,
    Guid CategoryId) : ICommand;