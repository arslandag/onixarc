using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Onix.Core.Abstraction;
using Onix.Core.Extensions;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Application.Database;

namespace Onix.WebSites.Application.Commands.WebSites.Delete;

public class DeleteWebSiteHandle
{
    private readonly IWebSiteRepository _webSiteRepository;
    private readonly IValidator<DeleteWebSiteCommand> _validator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<DeleteWebSiteCommand> _logger;

    public DeleteWebSiteHandle(
        IWebSiteRepository webSiteRepository,
        IValidator<DeleteWebSiteCommand> validator,
        IUnitOfWork unitOfWork,
        ILogger<DeleteWebSiteCommand> logger)
    {
        _webSiteRepository = webSiteRepository;
        _validator = validator;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Result<Guid, ErrorList>> Handle(
        DeleteWebSiteCommand command, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
            return validationResult.ToList();

        var webSiteId = WebSiteId.Create(command.WebSiteId);
        
        var webSite = await _webSiteRepository.GetById(webSiteId,cancellationToken);
        if(webSite.IsFailure)
            return webSite.Error.ToErrorList();
        
        var result = _webSiteRepository.Delete(webSite.Value, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return result;

    }
}