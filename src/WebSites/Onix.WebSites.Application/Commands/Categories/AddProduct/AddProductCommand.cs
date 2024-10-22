using Onix.Core.Abstraction;

namespace Onix.WebSites.Application.Commands.Categories.AddProduct;

public record AddProductCommand(
    Guid WebSiteId,
    Guid BlockId,
    string Name,
    string Description) : ICommand;