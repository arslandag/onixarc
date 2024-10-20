using Onix.WebSites.Application.Commands.WebSites.AddBlock;

namespace Onix.WebSites.Presentation.Controllers.WebSites.Requests;

public record AddBLockRequest(
    string Code)
{
    public AddBlockCommand ToCommand(Guid webSiteId)
        => new (webSiteId, Code);
}