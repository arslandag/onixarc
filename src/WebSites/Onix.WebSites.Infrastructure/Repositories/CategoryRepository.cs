using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Application.Database;
using Onix.WebSites.Domain.Categories;
using Onix.WebSites.Infrastructure.DbContexts;

namespace Onix.WebSites.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly WriteDbContext _dbContext;

    public CategoryRepository(WriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Result<Category, Error>> GetById(
        CategoryId id, CancellationToken cancellationToken = default)
    {
        var webSite = await _dbContext.Categories
            .Include(c => c.ParentCategory)
            .Include(c => c.SubCategory)
            .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
        
        if (webSite is null)
            return Errors.General.NotFound(id.Value);

        return webSite;
    }
    
    public async Task<Result<Category, Error>> GetByIdWithProduct(
        CategoryId id, CancellationToken cancellationToken = default)
    {
        var webSite = await _dbContext.Categories
            .Include(c => c.Products)
            .ThenInclude(p => p.ProductPhotos)
            .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
        
        if (webSite is null)
            return Errors.General.NotFound(id.Value);

        return webSite;
    }
    
    public async Task<Result<Category, Error>> GetByIdWithService(
        CategoryId id, CancellationToken cancellationToken = default)
    {
        var webSite = await _dbContext.Categories
            .Include(c => c.Services)
            .ThenInclude(p => p.ServicePhotos)
            .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
        
        if (webSite is null)
            return Errors.General.NotFound(id.Value);

        return webSite;
    }
}