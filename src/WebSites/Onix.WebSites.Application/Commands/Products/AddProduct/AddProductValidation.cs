using FluentValidation;
using Onix.Core.Validation;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects;

namespace Onix.WebSites.Application.Commands.Products.AddProduct;

public class AddProductValidation : AbstractValidator<AddProductCommand>
{
    public AddProductValidation()
    {
        RuleFor(a => a.Name)
            .NotEmpty()
            .WithError(Errors.Domain.ValueIsRequired(nameof(Name)));
        
        RuleFor(a => a.Name)
            .MaximumLength(Constants.NAME_MAX_LENGHT)
            .WithError(Errors.Domain.MaxLength(nameof(Name)));

        RuleFor(a => a.Description)
            .NotEmpty()
            .WithError(Errors.Domain.ValueIsRequired(nameof(Description)));
        
        RuleFor(a => a.Description)
            .MaximumLength(Constants.DESCRIPTION_MAX_LENGHT)
            .WithError(Errors.Domain.MaxLength(nameof(Description)));
    }
}