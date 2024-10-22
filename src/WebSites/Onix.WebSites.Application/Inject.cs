using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Onix.Core.Abstraction;
using Onix.WebSites.Application.Commands.WebSites.AddBlock;
using Onix.WebSites.Application.Commands.WebSites.AddCategory;
using Onix.WebSites.Application.Commands.WebSites.AddContact;
using Onix.WebSites.Application.Commands.WebSites.AddFAQ;
using Onix.WebSites.Application.Commands.WebSites.AddLocation;
using Onix.WebSites.Application.Commands.WebSites.Create;
using Onix.WebSites.Application.Commands.WebSites.Delete;
using Onix.WebSites.Application.Commands.WebSites.Update;
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
            .AddWebSiteCommand()
            .AddWebSiteQuery();

        return services;
    }

    private static IServiceCollection AddWebSiteCommand(
        this IServiceCollection service)
    {
        service.AddScoped<CreateWebSiteHandler>();
        service.AddScoped<UpdateWebSiteHandle>();
        service.AddScoped<DeleteWebSiteHandle>();

        service.AddScoped<AddBlockHandler>();
        service.AddScoped<AddCategoryHandle>();
        service.AddScoped<AddContactHandle>();
        service.AddScoped<AddFAQHandle>();
        service.AddScoped<AddLocationHandle>();
        
        return service;
    }

    private static IServiceCollection AddWebSiteQuery(
        this IServiceCollection service)
    {
        service.AddScoped<GetWebSiteByIdHandle>();
        service.AddScoped<GetWebSiteByUrlHandle>();

        return service;
    }
}