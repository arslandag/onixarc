using CSharpFunctionalExtensions;
using Onix.SharedKernel;
using Onix.WebSites.Domain.WebSites.ValueObjects;

namespace Onix.WebSites.Application.Database;

public interface IWebSiteRepository
{
    Task<Result<WebSites.Domain.WebSites.WebSite, Error>> GetById(
        WebSites.Domain.WebSites.WebSite webSite, CancellationToken cancellationToken = default);
    
    Task<Guid> Add(
        WebSites.Domain.WebSites.WebSite webSite, CancellationToken cancellationToken);

    Guid Save(
        WebSites.Domain.WebSites.WebSite webSite, CancellationToken cancellationToken = default);

    Guid Delete(
        WebSites.Domain.WebSites.WebSite webSite, CancellationToken cancellationToken = default);

    Task<Result<WebSites.Domain.WebSites.WebSite, Error>> GetByUrl(
        Url url, CancellationToken cancellationToken = default);
}