using Onix.Core.Abstraction;

namespace Onix.WebSites.Application.Features.WebSites.Commands.Create;

public record CreateWebSiteCommand(string Url, string Name) : ICommand;