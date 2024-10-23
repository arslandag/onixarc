using FluentValidation;
using Onix.Core.Validation;
using Onix.SharedKernel;

namespace Onix.WebSites.Application.Commands.FAQ.Update;

public class UpdateFaqValidation : AbstractValidator<UpdateFaqCommand>
{
    public UpdateFaqValidation()
    {
        RuleFor(a => a.WebSiteId)
            .NotEmpty()
            .WithError(Errors.Domain.ValueIsRequired(ConstType.WebSiteId));

        RuleFor(a => a.WebSiteId.ToString())
            .Matches(Constants.ID_REGEX)
            .WithError(Errors.Domain.ValueIsInvalid(ConstType.WebSiteId));
        
        RuleFor(a => a.Name)
            .NotEmpty()
            .WithError(Errors.Domain.ValueIsRequired(ConstType.Name));
        
        RuleFor(a => a.Name)
            .MaximumLength(Constants.NAME_MAX_LENGHT)
            .WithError(Errors.Domain.MaxLength(ConstType.Name));
    }
}