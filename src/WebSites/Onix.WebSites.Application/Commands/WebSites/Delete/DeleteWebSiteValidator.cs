using FluentValidation;
using Onix.Core.Validation;
using Onix.SharedKernel;

namespace Onix.WebSites.Application.Commands.WebSites.Delete;

public class DeleteWebSiteValidator : AbstractValidator<DeleteWebSiteCommand>
{
    public DeleteWebSiteValidator()
    {
        RuleFor(w => w.WebSiteId)
            .NotEmpty()
            .WithError(Errors.Domain.Empty(ConstType.WebSiteId));

        RuleFor(w => w.WebSiteId.ToString())
            .Matches(Constants.ID_REGEX)
            .WithError(Errors.Domain.ValueIsInvalid(ConstType.WebSiteId));
    }
}