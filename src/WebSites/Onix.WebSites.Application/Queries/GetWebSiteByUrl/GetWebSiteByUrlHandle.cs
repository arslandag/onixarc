using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Onix.Core.Dtos;
using Onix.SharedKernel;
using Onix.WebSites.Application.Database;

namespace Onix.WebSites.Application.Queries.GetWebSiteByUrl;

public class GetWebSiteByUrlHandle
{
    private readonly IReadDbContext _readDbContext;

    public GetWebSiteByUrlHandle(IReadDbContext readDbContext)
    {
        _readDbContext = readDbContext;
    }
    
    public async Task<Result<WebSiteDto, Error>> Handle(
        GetWebSiteByUrlQuery query,
        CancellationToken cancellationToken = default)
    {
        var webSiteDto = await _readDbContext.WebSites
            .FirstOrDefaultAsync(w => w.Url == query.Url, cancellationToken);
        
        if (webSiteDto is null)
            return Errors.General.NotFound();

        return webSiteDto;
    }
}