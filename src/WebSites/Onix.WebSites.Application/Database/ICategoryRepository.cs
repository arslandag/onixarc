using CSharpFunctionalExtensions;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.Categories;

namespace Onix.WebSites.Application.Database;

public interface ICategoryRepository
{
    Task<Result<Category, Error>> GetById(
        CategoryId id, CancellationToken cancellationToken = default);

    Task<Result<Category, Error>> GetByIdWithProduct(
        CategoryId id, CancellationToken cancellationToken = default);

    Task<Result<Category, Error>> GetByIdWithService(
        CategoryId id, CancellationToken cancellationToken = default);
}