using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Onix.Core.Abstraction;
using Onix.Core.Extensions;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Application.Database;
using Onix.WebSites.Application.Queries.GetWebSiteByUrl;
using Onix.WebSites.Domain.Appearances;
using Onix.WebSites.Domain.WebSites;
using Onix.WebSites.Domain.WebSites.ValueObjects;

namespace Onix.WebSites.Application.Commands.WebSites.Create;

public class CreateWebSiteHandler
{
    private readonly ILogger<CreateWebSiteHandler> _logger;
    private readonly GetWebSiteByUrlHandle _getWebSiteByUrlHandle;
    private readonly IValidator<CreateWebSiteCommand> _validator;
    private readonly IWebSiteRepository _webSiteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateWebSiteHandler(
        IValidator<CreateWebSiteCommand> validator,
        IWebSiteRepository webSiteWebSiteRepository,
        IUnitOfWork unitOfWork,
        ILogger<CreateWebSiteHandler> logger,
        GetWebSiteByUrlHandle getWebSiteByUrlHandle)
    {
        _logger = logger;
        _getWebSiteByUrlHandle = getWebSiteByUrlHandle;
        _validator = validator;
        _webSiteRepository = webSiteWebSiteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid, ErrorList>> Handle(
        CreateWebSiteCommand command, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (validationResult.IsValid == false)
            return validationResult.ToList();

        var url = Url.Create(command.Url).Value;
        var name = Name.Create(command.Name).Value;

        var query = new GetWebSiteByUrlQuery(url.Value);
        
        var website = await _getWebSiteByUrlHandle.Handle(query,cancellationToken);
        if (website.IsSuccess)
            return Errors.Domain.AlreadyExist(nameof(url)).ToErrorList();

        var webSiteId = WebSiteId.NewId();
        
        var appearance = Appearance.Bases;
        
        var webSiteToCreate = WebSite.Create(
            webSiteId,
            url,
            name,
            appearance).Value;

        await _webSiteRepository.Add(webSiteToCreate, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Created website {url} with id {websiteId}", url, webSiteId);
        
        return webSiteToCreate.Id.Value;
    }
}