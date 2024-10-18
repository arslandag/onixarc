using Onix.Core.Abstraction;
using Onix.SharedKernel.ValueObjects.Ids;

namespace Onix.WebSites.Application.Commands.WebSites.Delete;

public record DeleteWebSiteCommand(
    WebSiteId WebSiteId) : ICommand;