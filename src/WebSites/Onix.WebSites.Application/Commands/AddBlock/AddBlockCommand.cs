using Onix.Core.Abstraction;

namespace Onix.WebSites.Application.Commands.AddBlock;

public record AddBlockCommand(
    Guid WebSiteId,
    string Title,
    string Description) : ICommand;