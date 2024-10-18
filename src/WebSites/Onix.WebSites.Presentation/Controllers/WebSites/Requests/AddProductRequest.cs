using Onix.WebSites.Application.Commands.Products.AddProduct;

namespace Onix.WebSites.Presentation.Controllers.WebSites.Requests;

public record AddProductRequest(
    string Name,
    string Description)
{
    public AddProductCommand ToCommand(Guid webSiteId, Guid blockId) =>
        new(webSiteId, blockId, Name, Description);
}
