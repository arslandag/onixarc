using FluentValidation;
using Onix.Core.Validation;
using Onix.SharedKernel;

namespace Onix.WebSites.Application.Commands.FAQ.Delete;

public class DeleteFaqValidation : AbstractValidator<DeleteFaqCommand>
{
    public DeleteFaqValidation()
    {
        RuleFor(a => a.WebSiteId)
            .NotEmpty()
            .WithError(Errors.Domain.ValueIsRequired(ConstType.WebSiteId));

        RuleFor(a => a.WebSiteId.ToString())
            .Matches(Constants.ID_REGEX)
            .WithError(Errors.Domain.ValueIsInvalid(ConstType.WebSiteId));
        
        RuleFor(f => f.Question)
            .Empty()
            .WithError(Errors.Domain.Empty(ConstType.Question));
        
        RuleFor(f => f.Question)
            .MaximumLength(Constants.QUESTION_MAX_LENGHT)
            .WithError(Errors.Domain.MaxLength(ConstType.Question));
    }
}