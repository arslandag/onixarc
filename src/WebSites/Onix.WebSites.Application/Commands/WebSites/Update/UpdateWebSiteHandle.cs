using CSharpFunctionalExtensions;
using FluentValidation;
using Onix.Core.Extensions;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Application.Database;
using Onix.WebSites.Domain.WebSites;
using Onix.WebSites.Domain.WebSites.ValueObjects;

namespace Onix.WebSites.Application.Commands.WebSites.Update;

public class UpdateWebSiteHandle
{
    private readonly IValidator<UpdateWebSiteCommand> _validator;
    private readonly IWebSiteRepository _webSiteRepository;

    public UpdateWebSiteHandle(
        IValidator<UpdateWebSiteCommand> validator,
        IWebSiteRepository webSiteRepository)
    {
        _validator = validator;
        _webSiteRepository = webSiteRepository;
    }
    
    public async Task<Result<Guid, ErrorList>> Handle(
        UpdateWebSiteCommand command, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (validationResult.IsValid == false)
            return validationResult.ToList();

        var url = Url.Create(command.Url).Value;
        var name = Name.Create(command.Name).Value;
        
        var webSite = await _webSiteRepository
            .GetById(command.WebSiteId, cancellationToken);

        if (webSite.IsFailure)
            return webSite.Error.ToErrorList();

         
        

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Created website {url} with id {websiteId}", url, webSiteId);
        
        return webSiteToCreate.Id.Value;
    }
}