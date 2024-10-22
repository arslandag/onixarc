using FluentValidation;
using Onix.Core.Validation;
using Onix.SharedKernel;

namespace Onix.WebSites.Application.Commands.WebSites.AddLocation;

public class AddLocationValidator : AbstractValidator<AddLocationCommand>
{
    public AddLocationValidator()
    {
        RuleFor(l => l.WebSiteId)
            .Empty()
            .WithError(Errors.Domain.Empty(ConstType.WebSiteId));
        
        RuleFor(c => c.WebSiteId.ToString())
            .Matches(Constants.ID_REGEX)
            .WithError(Errors.Domain.ValueIsInvalid(ConstType.WebSiteId));

        RuleFor(l => l.Name)
            .NotEmpty()
            .WithError(Errors.Domain.Empty(ConstType.Name));
        
        RuleFor(l => l.Name)
            .MaximumLength(Constants.NAME_MAX_LENGHT)
            .WithError(Errors.Domain.MaxLength(ConstType.Name));
        
        RuleFor(l => l.Phone)
            .NotEmpty()
            .WithError(Errors.Domain.Empty(ConstType.Phone));
        
        RuleFor(l => l.Phone)
            .MaximumLength(Constants.PHONE_MAX_LENGHT)
            .WithError(Errors.Domain.MaxLength(ConstType.Phone));
        
        RuleFor(l => l.City)
            .NotEmpty()
            .WithError(Errors.Domain.Empty(ConstType.City));
        
        RuleFor(l => l.City)
            .MaximumLength(Constants.ADDRESS_MAX_LENGHT)
            .WithError(Errors.Domain.MaxLength(ConstType.City));
        
        RuleFor(l => l.Street)
            .NotEmpty()
            .WithError(Errors.Domain.Empty(ConstType.Street));
        
        RuleFor(l => l.Street)
            .MaximumLength(Constants.ADDRESS_MAX_LENGHT)
            .WithError(Errors.Domain.MaxLength(ConstType.Street));
        
        RuleFor(l => l.Build)
            .NotEmpty()
            .WithError(Errors.Domain.Empty(ConstType.Build));
        
        RuleFor(l => l.Build)
            .MaximumLength(Constants.ADDRESS_MAX_LENGHT)
            .WithError(Errors.Domain.MaxLength(ConstType.Build));

        RuleFor(l => l.Index)
            .MaximumLength(Constants.INDEX_MAX_LENGHT)
            .WithError(Errors.Domain.MaxLength(ConstType.Index));
    }
}