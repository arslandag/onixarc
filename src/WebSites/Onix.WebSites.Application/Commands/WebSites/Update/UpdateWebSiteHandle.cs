using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Onix.Core.Abstraction;
using Onix.Core.Extensions;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Application.Database;
using Onix.WebSites.Application.Queries.WebSites.GetByUrl;
using Onix.WebSites.Domain.WebSites.ValueObjects;

namespace Onix.WebSites.Application.Commands.WebSites.Update;

public class UpdateWebSiteHandle
{
    private readonly IValidator<UpdateWebSiteCommand> _validator;
    private readonly IWebSiteRepository _webSiteRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly GetByUrlHandle _getByUrlHandle;
    private readonly ILogger<UpdateWebSiteHandle> _logger;

    public UpdateWebSiteHandle(
        IValidator<UpdateWebSiteCommand> validator,
        IWebSiteRepository webSiteRepository,
        IUnitOfWork unitOfWork,
        GetByUrlHandle getByUrlHandle,
        ILogger<UpdateWebSiteHandle> logger)
    {
        _validator = validator;
        _webSiteRepository = webSiteRepository;
        _unitOfWork = unitOfWork;
        _getByUrlHandle = getByUrlHandle;
        _logger = logger;
    }
    
    public async Task<Result<Guid, ErrorList>> Handle(
        UpdateWebSiteCommand command, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
            return validationResult.ToList();

        var url = Url.Create(command.Url).Value;
        var query = new GetByUrlQuery(url.Value);
        
        var existingWebsite = await _getByUrlHandle.Handle(query, cancellationToken);
        if (existingWebsite.IsSuccess)
            return Errors.Domain.AlreadyExist(nameof(url)).ToErrorList();

        var webSiteId = WebSiteId.Create(command.WebSiteId);
        
        var webSiteResult = await _webSiteRepository.GetById(webSiteId, cancellationToken);
        if (webSiteResult.IsFailure)
            return webSiteResult.Error.ToErrorList();

        var name = Name.Create(command.Name).Value;
        
        var result = webSiteResult.Value.Update(url, name);
        if (result.IsFailure)
            return result.Error.ToErrorList();
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return webSiteResult.Value.Id.Value;
    }
}