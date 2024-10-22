using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Onix.Core.Abstraction;
using Onix.Core.Extensions;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Application.Commands.WebSites.Update;
using Onix.WebSites.Application.Database;
using Onix.WebSites.Application.Queries.GetWebSiteByUrl;
using Onix.WebSites.Domain.WebSites.ValueObjects;

namespace Onix.WebSites.Application.Commands.WebSites.UpdateAppearance;

public class UpdateAppearanceHandle
{
    private readonly IValidator<UpdateAppearanceCommand> _validator;
    private readonly IWebSiteRepository _webSiteRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly GetWebSiteByUrlHandle _getWebSiteByUrlHandle;
    private readonly ILogger<UpdateAppearanceHandle> _logger;

    public UpdateAppearanceHandle(
        IValidator<UpdateAppearanceCommand> validator,
        IWebSiteRepository webSiteRepository,
        IUnitOfWork unitOfWork,
        GetWebSiteByUrlHandle getWebSiteByUrlHandle,
        ILogger<UpdateAppearanceHandle> logger)
    {
        _validator = validator;
        _webSiteRepository = webSiteRepository;
        _unitOfWork = unitOfWork;
        _getWebSiteByUrlHandle = getWebSiteByUrlHandle;
        _logger = logger;
    }
    
    public async Task<Result<Guid, ErrorList>> Handle(
        UpdateAppearanceCommand command, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
            return validationResult.ToList();
        
        var webSiteId = WebSiteId.Create(command.WebSiteId);
        
        var webSiteResult = await _webSiteRepository.GetById(webSiteId, cancellationToken);
        if (webSiteResult.IsFailure)
            return webSiteResult.Error.ToErrorList();

        var result = webSiteResult.Value.Appearance.Update(
            command.ColorScheme, command.ButtonStyle, command.Font);
        if (result.IsFailure)
            return result.Error.ToErrorList();
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return webSiteResult.Value.Id.Value;
    }
}