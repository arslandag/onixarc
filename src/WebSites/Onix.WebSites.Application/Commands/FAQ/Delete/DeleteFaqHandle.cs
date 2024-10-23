using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Onix.Core.Abstraction;
using Onix.Core.Extensions;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Application.Database;

namespace Onix.WebSites.Application.Commands.FAQ.Delete;

public class DeleteFaqHandle
{
    private readonly IValidator<DeleteFaqCommand> _validator;
    private readonly IWebSiteRepository _webSiteRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<DeleteFaqHandle> _logger;

    public DeleteFaqHandle(
        IValidator<DeleteFaqCommand> validator,
        IWebSiteRepository webSiteRepository,
        IUnitOfWork unitOfWork,
        ILogger<DeleteFaqHandle> logger)
    {
        _validator = validator;
        _webSiteRepository = webSiteRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<UnitResult<ErrorList>> Handle(
        DeleteFaqCommand command ,CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command,cancellationToken);
        if (validationResult.IsValid == false)
            return validationResult.ToList();

        var webSiteId = WebSiteId.Create(command.WebSiteId);
        
        var webSiteResult = await _webSiteRepository
            .GetByIdWithCategories(webSiteId, cancellationToken);
        if (webSiteResult.IsFailure)
            return webSiteResult.Error.ToErrorList();
        
        var faqResult = webSiteResult.Value.Faqs
            .FirstOrDefault(f => f.Question == command.Question);
        if (faqResult is null)
            return Errors.General.NotFound(command.Question).ToErrorList();

        webSiteResult.Value.RemoveFAQ(faqResult);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return UnitResult.Success<Error>().Error.ToErrorList();
    }
}