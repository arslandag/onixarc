using Onix.Core.Abstraction;

namespace Onix.WebSites.Application.Queries.WebSites.GetById;

public record GetByIdQuery (Guid Id) : IQuery;