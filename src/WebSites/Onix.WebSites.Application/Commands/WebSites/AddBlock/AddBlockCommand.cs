using Onix.Core.Abstraction;

namespace Onix.WebSites.Application.Commands.WebSites.AddBlock;

public record AddBlockCommand(
    Guid WebSiteId,
    string Code) : ICommand;