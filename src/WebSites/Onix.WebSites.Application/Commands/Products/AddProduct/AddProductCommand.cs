using Onix.Core.Abstraction;

namespace Onix.WebSites.Application.Commands.Products.AddProduct;

public record AddProductCommand(
    Guid WebSiteId,
    Guid BlockId,
    string Name,
    string Description) : ICommand;