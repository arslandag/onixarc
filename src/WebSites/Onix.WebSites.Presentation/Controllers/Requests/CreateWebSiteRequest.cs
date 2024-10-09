using Onix.WebSites.Application.Commands.Create;

namespace Onix.WebSites.Presentation.Controllers.Requests;

public record CreateWebSiteRequest(
    string Url,
    string Name)
{
    public CreateWebSiteCommand ToCommand()
        => new(Url, Name);
}