using Microsoft.AspNetCore.Mvc;
using Onix.Framework;
using Onix.WebSites.Application.Commands.Blocks.Add;
using Onix.WebSites.Application.Commands.WebSites.Create;
using Onix.WebSites.Presentation.Controllers.WebSites.Requests;

namespace Onix.WebSites.Presentation.Controllers.WebSites;

public class WebSiteController : ApplicationController
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateWebSiteHandler handler,
        [FromBody] CreateWebSiteRequest request,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(request.ToCommand(), cancellationToken);

        if (result.IsFailure)
            return result.Error.ToResponse();
        
        return Ok(result.Value);
    }
    
    [HttpPost("{id:guid}/block")]
    public async Task<IActionResult> AddBlock(
        [FromRoute] Guid id,
        [FromServices] AddBlockHandler handler,
        [FromBody] AddBLockRequest request,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(request.ToCommand(id), cancellationToken);

        if (result.IsFailure)
            return result.Error.ToResponse();
        
        return Ok(result.Value);
    }
    
    /*[HttpPost("{id:guid}/Category/")]
    public async Task<IActionResult> Add(
        [FromForm] AddCategoryRequest request,
        [FromServices] AddCategoryHandle handle,
        [FromRoute] Guid id,
        [FromRoute] Guid blockId,
        CancellationToken cancellationToken)
    {
        var result = await handle.Handle(
            request.ToCommand(id,blockId), cancellationToken);

        if (result.IsFailure)
            return result.Error.ToResponse();

        return Ok(result.Value);
    }*/
}