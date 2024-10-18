using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Onix.Core.Abstraction;
using Onix.Core.Extensions;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Application.Database;

namespace Onix.WebSites.Application.Commands.Products.AddProduct;

public class AddProductHandle
{
    private readonly IValidator<AddProductCommand> _validator;
    private readonly IWebSiteRepository _webSiteRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AddProductHandle> _logger;

    public AddProductHandle(
        IValidator<AddProductCommand> validator,
        IWebSiteRepository webSiteRepository,
        IUnitOfWork unitOfWork,
        ILogger<AddProductHandle> logger)
    {
        _validator = validator;
        _webSiteRepository = webSiteRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Result<Guid, ErrorList>> Handle(
        AddProductCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command,cancellationToken);
        if (validationResult.IsValid == false)
            return validationResult.ToList();

        var webSiteId = WebSiteId.Create(command.WebSiteId);
        
        var webSiteResult = await _webSiteRepository
            .GetById(webSiteId, cancellationToken);

        if (webSiteResult.IsFailure)
            return webSiteResult.Error.ToErrorList();

        var blockId = BlockId.Create(command.BlockId);
        var name = Name.Create(command.Name).Value;
        var description = Description.Create(command.Description).Value;
        
        /*var product = Product.Create(
            blockId,
            name,
            description,
            null,
            null).Value;

        webSiteResult.Value.Blocks.add;

        await _unitOfWork.SaveChangesAsync(cancellationToken);*/

        return Guid.NewGuid();
    }
}