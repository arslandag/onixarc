using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Application.Database;
using Onix.WebSites.Domain.WebSites;
using Onix.WebSites.Domain.WebSites.ValueObjects;
using Onix.WebSites.Infrastructure.DbContexts;

namespace Onix.WebSites.Infrastructure.Repositories;

public class WebSiteRepository : IWebSiteRepository
{
    private readonly WriteDbContext _dbContext;

    public WebSiteRepository( WriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Result<WebSite,Error>> GetById(
        WebSiteId webSiteId, CancellationToken cancellationToken = default)
    {
        var website = await _dbContext.WebSites
            .Include(w => w.Blocks)
            .ThenInclude(b => b.BackgroundPhoto)
            .FirstOrDefaultAsync(w => w.Id == webSiteId, cancellationToken );

        if (website is null)
            return Errors.General.NotFound(webSiteId.Value);
        
        return website;
    }

    public async Task<Guid> Add(
        WebSite webSite, CancellationToken cancellationToken)
    {
        await _dbContext.WebSites.AddAsync(webSite, cancellationToken);

        return webSite.Id.Value;
    }

    public Guid Save(
        WebSite webSite, CancellationToken cancellationToken = default)
    {
        _dbContext.WebSites.Attach(webSite);
        return webSite.Id.Value;
    }

    public Guid Delete(
        WebSite webSite, CancellationToken cancellationToken = default)
    {
        _dbContext.WebSites.Remove(webSite);
        return webSite.Id.Value;
    }

    public async Task<Result<WebSite, Error>> GetByUrl(
        Url url, CancellationToken cancellationToken = default)
    {
        var website = await _dbContext.WebSites
            .Include(w => w.Blocks)
            .ThenInclude(b => b.BackgroundPhoto)
            .FirstOrDefaultAsync(w => w.Url == url, cancellationToken );

        if (website is null)
            return Errors.General.NotFound();

        return website;
    }
}