namespace Onix.WebSites.Application.Commands.Blocks.Delete;

public record DeleteBlockCommand(
    Guid WebSiteId,
    Guid BlockId);