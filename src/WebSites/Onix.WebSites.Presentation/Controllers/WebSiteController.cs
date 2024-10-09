using Microsoft.AspNetCore.Mvc;
using Onix.Framework;
using Onix.WebSites.Application.Commands.AddBlock;
using Onix.WebSites.Application.Commands.Create;
using Onix.WebSites.Presentation.Controllers.Requests;

namespace Onix.WebSites.Presentation.Controllers;

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
}