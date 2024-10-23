using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Onix.Core.Abstraction;
using Onix.WebSites.Application.Commands.Blocks.Add;
using Onix.WebSites.Application.Commands.Categories.Add;
using Onix.WebSites.Application.Commands.FAQ.Add;
using Onix.WebSites.Application.Commands.Locations.Add;
using Onix.WebSites.Application.Commands.Socials.Add;
using Onix.WebSites.Application.Commands.WebSites.AddContact;
using Onix.WebSites.Application.Commands.WebSites.Create;
using Onix.WebSites.Application.Commands.WebSites.Delete;
using Onix.WebSites.Application.Commands.WebSites.Update;
using Onix.WebSites.Application.Commands.WebSites.UpdateAppearance;
using Onix.WebSites.Application.Queries.WebSites.GetById;
using Onix.WebSites.Application.Queries.WebSites.GetByIdWithBlocks;
using Onix.WebSites.Application.Queries.WebSites.GetByIdWithCategories;
using Onix.WebSites.Application.Queries.WebSites.GetByIdWithFavicon;
using Onix.WebSites.Application.Queries.WebSites.GetByIdWithLocations;
using Onix.WebSites.Application.Queries.WebSites.GetByUrl;

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
        service.AddScoped<UpdateAppearanceHandle>();

        service.AddScoped<AddBlockHandler>();
        service.AddScoped<AddCategoryHandle>();
        service.AddScoped<AddContactHandle>();
        service.AddScoped<AddFAQHandle>();
        service.AddScoped<AddLocationHandle>();
        service.AddScoped<AddSocialHandle>();
        
        return service;
    }

    private static IServiceCollection AddWebSiteQuery(
        this IServiceCollection service)
    {
        service.AddScoped<GetByIdHandle>();
        service.AddScoped<GetByUrlHandle>();
        service.AddScoped<GetByIdHandleWithBLocks>();
        service.AddScoped<GetByIdHandleWithCategories>();
        service.AddScoped<GetByIdHandleWithFavicon>();
        service.AddScoped<GetByIdHandleWithLocations>();

        return service;
    }
}