using Onix.Core.Abstraction;

namespace Onix.WebSites.Application.Commands.Blocks.Update;

public record UpdateBlockCommand(
    Guid WebSiteId,
    Guid BlockId,
    string Code) : ICommand;