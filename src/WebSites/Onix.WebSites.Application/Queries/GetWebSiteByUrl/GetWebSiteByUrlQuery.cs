using Onix.Core.Abstraction;

namespace Onix.WebSites.Application.Queries.GetWebSiteByUrl;

public record GetWebSiteByUrlQuery(string Url) : IQuery;