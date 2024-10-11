using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Onix.Core.Abstraction;
using Onix.WebSites.Application.Commands.AddBlock;
using Onix.WebSites.Application.Commands.Create;
using Onix.WebSites.Application.Queries.GetWebSiteById;
using Onix.WebSites.Application.Queries.GetWebSiteByUrl;

namespace Onix.WebSites.Application;

public static class Inject
{
    public static IServiceCollection AddWebSiteApplication(
        this IServiceCollection services)
    {
        var assembly = typeof(Inject).Assembly;

        services.Scan(scan => scan.FromAssemblies(assembly)
            .AddClasses(classes => classes
                .AssignableToAny(typeof(ICommandHandler<,>), typeof(ICommandHandler<>)))
            .AsSelfWithInterfaces()
            .WithScopedLifetime());

        services.Scan(scan => scan.FromAssemblies(assembly)
            .AddClasses(classes => classes
                .AssignableToAny(typeof(IQueryHandler<,>), typeof(IQueryHandlerWithResult<,>)))
            .AsSelfWithInterfaces()
            .WithScopedLifetime());

        services
            .AddValidatorsFromAssembly(assembly)
            .AddCommand()
            .AddQuery();

        return services;
    }

    private static IServiceCollection AddCommand(
        this IServiceCollection service)
    {
        service.AddScoped<CreateWebSiteHandler>();
        service.AddScoped<AddBlockHandler>();
        
        return service;
    }

    private static IServiceCollection AddQuery(
        this IServiceCollection service)
    {
        service.AddScoped<GetWebSiteByIdHandle>();
        service.AddScoped<GetWebSiteByUrlHandle>();

        return service;
    }
}