using Onix.Core.Abstraction;

namespace Onix.WebSites.Application.Commands.Products.Add;

public record AddProductCommand(
    Guid WebSiteId,
    Guid BlockId,
    string Name,
    string Description) : ICommand;