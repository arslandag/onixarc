using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onix.Core.Abstraction;
using Onix.WebSites.Application.Database;
using Onix.WebSites.Infrastructure.DbContexts;
using Onix.WebSites.Infrastructure.Repositories;

namespace Onix.WebSites.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddWebSiteInfrastructure(
        this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext()
            .AddRepositories()
            .AddDatabase();
        
        return service;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection service)
    {
        service.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
        service.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return service;
    }

    private static IServiceCollection AddRepositories(
        this IServiceCollection service)
    {
        service.AddScoped<IWebSiteRepository, WebSiteRepository>();
        
        return service;
    }

    private static IServiceCollection AddDbContext(
        this IServiceCollection service)
    {
        service.AddScoped<WriteDbContext>();
        service.AddScoped<IReadDbContext, ReadDbContext>();

        return service;
    }
    
    private static IServiceCollection AddMinio(
        this IServiceCollection services, IConfiguration configuration)
    {
        
        //чекни документацию
        /*services.Configure<MinioOptions>(
            configuration.GetSection(MinioOptions.MINIO));

        services.AddMinio(options =>
        {
            var minioOptions = configuration.GetSection(MinioOptions.MINIO).Get<MinioOptions>()
                               ?? throw new ApplicationException("Missing minio configuration");

            options.WithEndpoint(minioOptions.Endpoint);

            options.WithCredentials(minioOptions.AccessKey, minioOptions.SecretKey);
            options.WithSSL(minioOptions.WithSsl);
        });*/

        return services;
    }
}