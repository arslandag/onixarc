using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Onix.Core.Dtos;
using Onix.SharedKernel;
using Onix.WebSites.Application.Database;
using Onix.WebSites.Application.Queries.WebSites.GetById;

namespace Onix.WebSites.Application.Queries.WebSites.GetByIdWithLocations;

public class GetByIdHandleWithLocations
{
    private readonly IReadDbContext _readDbContext;

    public GetByIdHandleWithLocations(IReadDbContext readDbContext)
    {
        _readDbContext = readDbContext;
    }

    public async Task<Result<WebSiteDto, ErrorList>> Handle(
        GetByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        var webSiteDto = await _readDbContext.WebSites
            .Include(w => w.Location)
            .FirstOrDefaultAsync(w => w.Id == query.Id, cancellationToken);

        if (webSiteDto is null)
            return Errors.General.NotFound(query.Id).ToErrorList();

        return webSiteDto;
    }
}