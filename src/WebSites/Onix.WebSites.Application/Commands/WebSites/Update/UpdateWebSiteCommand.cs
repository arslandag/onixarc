using Onix.Core.Abstraction;
using Onix.SharedKernel.ValueObjects.Ids;

namespace Onix.WebSites.Application.Commands.WebSites.Update;

public record UpdateWebSiteCommand(
    Guid WebSiteId, 
    string Url,
    string Name) : ICommand;