using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Onix.Core.Abstraction;
using Onix.Core.Extensions;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Application.Database;
using Onix.WebSites.Domain.Categories;

namespace Onix.WebSites.Application.Commands.Categories.Add;

public class AddCategoryHandle
{
    private readonly IWebSiteRepository _webSiteRepository;
    private readonly ILogger<AddCategoryHandle> _logger;
    private readonly IValidator<AddCategoryCommand> _validator;
    private readonly IUnitOfWork _unitOfWork;

    public AddCategoryHandle(
        IWebSiteRepository webSiteRepository,
        ILogger<AddCategoryHandle> logger,
        IValidator<AddCategoryCommand> validator,
        IUnitOfWork unitOfWork)
    {
        _webSiteRepository = webSiteRepository;
        _logger = logger;
        _validator = validator;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid, ErrorList>> Handle(
        AddCategoryCommand command, CancellationToken cancellationToken = default)
    {
        var validator = await _validator.ValidateAsync(command, cancellationToken);
        if (!validator.IsValid)
            return validator.ToList();
        
        var webSiteId = WebSiteId.Create(command.WebSiteId);
        
        var webSiteResult = await _webSiteRepository
            .GetByIdWithCategories(webSiteId, cancellationToken);
        if (webSiteResult.IsFailure)
            return webSiteResult.Error.ToErrorList();

        var categoryId = CategoryId.NewId();
        var name = Name.Create(command.Name).Value;
        
        var category = Category.Create(
            categoryId,
            name,
            null).Value;

        var result = webSiteResult.Value.AddCategory(category);
        if (result.IsFailure)
            return result.Error.ToErrorList();
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return categoryId.Value;
    }
}