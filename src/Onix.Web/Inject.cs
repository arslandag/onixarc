
namespace Onix.Web;

public static class Inject
{
    public static IServiceCollection AddApi(
        this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}