using Onix.Core.Abstraction;

namespace Onix.WebSites.Application.Commands.Create;

public record CreateWebSiteCommand(string Url, string Name) : ICommand;