using Onix.Core.Abstraction;

namespace Onix.WebSites.Application.Commands.WebSites.Create;

public record CreateWebSiteCommand(string Url, string Name) : ICommand;