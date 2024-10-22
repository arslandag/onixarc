using FluentValidation;
using Onix.Core.Validation;
using Onix.SharedKernel;

namespace Onix.WebSites.Application.Commands.WebSites.UpdateAppearance;

public class UpdateAppearanceValidator : AbstractValidator<UpdateAppearanceCommand>
{
    public UpdateAppearanceValidator()
    {
        RuleFor(a => a.WebSiteId)
            .NotEmpty()
            .WithError(Errors.Domain.ValueIsRequired(ConstType.WebSiteId));

        RuleFor(a => a.WebSiteId.ToString())
            .Matches(Constants.ID_REGEX)
            .WithError(Errors.Domain.ValueIsInvalid(ConstType.WebSiteId));
        
        RuleFor(a => a.ColorScheme)
            .NotEmpty()
            .WithError(Errors.Domain.Empty(ConstType.ColorScheme));
        
        RuleFor(a => a.ButtonStyle)
            .NotEmpty()
            .WithError(Errors.Domain.Empty(ConstType.ButtonStyle));
        
        RuleFor(a => a.Font)
            .NotEmpty()
            .WithError(Errors.Domain.Empty(ConstType.Font));
    }
}