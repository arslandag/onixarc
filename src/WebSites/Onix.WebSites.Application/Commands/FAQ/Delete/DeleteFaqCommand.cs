using Onix.Core.Abstraction;

namespace Onix.WebSites.Application.Commands.FAQ.Delete;

public record DeleteFaqCommand(
    Guid WebSiteId,
    string Question) : ICommand;