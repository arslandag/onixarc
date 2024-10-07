using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Onix.Core.Abstraction;
using Onix.Core.Extensions;
using Onix.SharedKernel;
using Onix.WebSites.Application.Database;

namespace Onix.WebSites.Application.Features.WebSites.Commands.AddBlock;

public class AddBlockHandler
{
    private readonly IValidator<AddBlockCommand> _validator;
    private readonly IWebSiteRepository _webSiteWebSiteRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AddBlockCommand> _logger;

    public AddBlockHandler(
        IValidator<AddBlockCommand> validator,
        IWebSiteRepository webSiteWebSiteRepository,
        IUnitOfWork unitOfWork,
        ILogger<AddBlockCommand> logge)
    {
        _validator = validator;
        _webSiteWebSiteRepository = webSiteWebSiteRepository;
        _unitOfWork = unitOfWork;
        _logger = logge;
    }

    public async Task<Result<Guid, ErrorList>> Handle(
        AddBlockCommand command ,CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command,cancellationToken);
        if (validationResult.IsValid == false)
            return validationResult.ToList();

        return Guid.NewGuid();
    }
}