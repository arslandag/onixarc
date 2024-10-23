using Onix.Core.Abstraction;

namespace Onix.WebSites.Application.Commands.Blocks.Add;

public record AddBlockCommand(
    Guid WebSiteId,
    string Code) : ICommand;