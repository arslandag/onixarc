using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Onix.Core.Abstraction;
using Onix.Core.Extensions;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Application.Database;
using Onix.WebSites.Domain.ConfigSite;
using Onix.WebSites.Domain.WebSites.ValueObjects;

namespace Onix.WebSites.Application.Features.WebSites.Commands.Create;

public class CreateWebSiteHandler
{
    private readonly ILogger<CreateWebSiteHandler> _logger;
    private readonly IValidator<CreateWebSiteCommand> _validator;
    private readonly IWebSiteRepository _webSiteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateWebSiteHandler(
        IValidator<CreateWebSiteCommand> validator,
        IWebSiteRepository webSiteWebSiteRepository,
        IUnitOfWork unitOfWork,
        ILogger<CreateWebSiteHandler> logger)
    {
        _logger = logger;
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

        //сделать проверку через readdbcontext
        var website = await _webSiteRepository.GetByUrl(url, cancellationToken);
        if (website.IsSuccess)
            return Errors.Domain.AlreadyExist(nameof(url)).ToErrorList();

        var webSiteId = WebSiteId.NewId();
        
        var appearance = Appearance.Bases;
        
        var webSiteToCreate = Onix.WebSites.Domain.WebSites.WebSite.Create(
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