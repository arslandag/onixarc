using Onix.Core.Abstraction;
using Onix.SharedKernel.ValueObjects.Ids;

namespace Onix.WebSites.Application.Commands.WebSites.Delete;

public record DeleteWebSiteCommand(
    Guid WebSiteId) : ICommand;