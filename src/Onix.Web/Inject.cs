using Onix.WebSites.Application;
using Onix.WebSites.Infrastructure;
using Onix.WebSites.Presentation;

namespace Onix.Web;

public static class Inject
{
    public static IServiceCollection AddAllService(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddWebSiteApplication()
            .AddWebSiteInfrastructure(configuration)
            .AddWebSitePresentation();
        
        return services;
    }
}