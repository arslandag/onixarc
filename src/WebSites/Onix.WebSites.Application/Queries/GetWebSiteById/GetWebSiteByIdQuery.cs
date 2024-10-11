using Onix.Core.Abstraction;

namespace Onix.WebSites.Application.Queries.GetWebSiteById;

public record GetWebSiteByIdQuery (Guid Id) : IQuery;