using Microsoft.Extensions.DependencyInjection;

namespace Onix.WebSites.Presentation;

public static class Inject
{
    public static IServiceCollection AddWebSitePresentation(
        this IServiceCollection service)
    {
        service.AddControllers();
        return service;
    }
}