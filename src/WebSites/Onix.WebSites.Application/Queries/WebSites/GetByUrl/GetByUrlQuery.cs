using Onix.Core.Abstraction;

namespace Onix.WebSites.Application.Queries.WebSites.GetByUrl;

public record GetByUrlQuery(string Url) : IQuery;