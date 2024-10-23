using Onix.Core.Abstraction;

namespace Onix.WebSites.Application.Commands.FAQ.Update;

public record UpdateFaqCommand(
    Guid WebSiteId,
    string Question,
    string Answer) : ICommand;