using Onix.Core.Dtos;

namespace Onix.WebSites.Application.Database;

public interface IReadDbContext
{
    IQueryable<WebSiteDto> WebSites { get; }
    IQueryable<BlockDto> Blocks { get; }
    IQueryable<ProductDto> Product { get; }
    IQueryable<ServiceDto> Service { get; }
    IQueryable<EmployeeDto> Employee { get; }
    IQueryable<PhotoDto> Photo { get; }
}