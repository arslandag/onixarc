using FluentValidation;
using Onix.Core.Validation;
using Onix.SharedKernel;

namespace Onix.WebSites.Application.Commands.FAQ.Add;

public class AddFAQValidator : AbstractValidator<AddFAQCommand>
{
    public AddFAQValidator()
    {
        RuleFor(c => c.WebSiteId)
            .Empty()
            .WithError(Errors.Domain.Empty(ConstType.WebSiteId));

        RuleFor(c => c.WebSiteId.ToString())
            .Matches(Constants.ID_REGEX)
            .WithError(Errors.Domain.ValueIsInvalid(ConstType.WebSiteId));
        
        RuleFor(f => f.Question)
            .Empty()
            .WithError(Errors.Domain.Empty(ConstType.Question));
        
        RuleFor(f => f.Answer)
            .Empty()
            .WithError(Errors.Domain.Empty(ConstType.Answer));
        
        RuleFor(f => f.Question)
            .MaximumLength(Constants.QUESTION_MAX_LENGHT)
            .WithError(Errors.Domain.MaxLength(ConstType.Question));
        
        RuleFor(f => f.Answer)
            .MaximumLength(Constants.ANSWER_MAX_LENGHT)
            .WithError(Errors.Domain.MaxLength(ConstType.Answer));
    }
}