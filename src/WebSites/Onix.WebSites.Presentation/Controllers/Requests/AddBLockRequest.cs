using Onix.WebSites.Application.Commands.AddBlock;

namespace Onix.WebSites.Presentation.Controllers.Requests;

public record AddBLockRequest(
    string Title,
    string Description)
{
    public AddBlockCommand ToCommand(Guid webSiteId)
        => new (webSiteId,Title, Description);
}