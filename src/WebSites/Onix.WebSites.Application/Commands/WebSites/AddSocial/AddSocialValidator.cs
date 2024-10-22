using FluentValidation;
using Onix.Core.Validation;
using Onix.SharedKernel;

namespace Onix.WebSites.Application.Commands.WebSites.AddSocial;

public class AddSocialValidator : AbstractValidator<AddSocialCommand>
{
    public AddSocialValidator()
    {
        RuleFor(s => s.Social)
            .Empty()
            .WithError(Errors.Domain.Empty(ConstType.Social));
        
        RuleFor(s => s.Link)
            .Empty()
            .WithError(Errors.Domain.Empty(ConstType.Link));
        
        RuleFor(s => s.Social)
            .MaximumLength(Constants.SOCIAL_MAX_LENGHT)
            .WithError(Errors.Domain.MaxLength(ConstType.Social));
        
        RuleFor(s => s.Link)
            .MaximumLength(Constants.LINK_MAX_LENGHT)
            .WithError(Errors.Domain.MaxLength(ConstType.Link));
    }
}