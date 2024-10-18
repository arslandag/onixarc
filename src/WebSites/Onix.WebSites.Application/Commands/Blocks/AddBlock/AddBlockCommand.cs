using Onix.Core.Abstraction;

namespace Onix.WebSites.Application.Commands.Blocks.AddBlock;

public record AddBlockCommand(
    Guid WebSiteId,
    string Code) : ICommand;