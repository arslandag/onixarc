using CSharpFunctionalExtensions;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.WebSites;
using Onix.WebSites.Domain.WebSites.ValueObjects;

namespace Onix.WebSites.Application.Database;

public interface IWebSiteRepository
{
    Task<Result<WebSite,Error>> GetById(
        WebSiteId webSiteId, CancellationToken cancellationToken = default);

    Task<Guid> Add(
        WebSite webSite, CancellationToken cancellationToken);

    Guid Save(
        WebSite webSite, CancellationToken cancellationToken = default);

    Guid Delete(
        WebSite webSite, CancellationToken cancellationToken = default);

    Task<Result<WebSite, Error>> GetByUrl(
        Url url, CancellationToken cancellationToken = default);

    Task<Result<WebSite, Error>> GetByIdWithProduct(
        WebSiteId webSiteId, CancellationToken cancellationToken = default);

    Task<Result<WebSite, Error>> GetByIdWithService(
        WebSiteId webSiteId, CancellationToken cancellationToken = default);

    Task<Result<WebSite, Error>> GetByIdWithEmployee(
        WebSiteId webSiteId, CancellationToken cancellationToken = default);

    Task<Result<WebSite, Error>> GetByIdWithPhoto(
        WebSiteId webSiteId, CancellationToken cancellationToken = default);

    Task<Result<WebSite, Error>> GetByIdWithLocation(
        WebSiteId webSiteId, CancellationToken cancellationToken = default);
}