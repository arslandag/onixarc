using FluentValidation;
using Onix.Core.Validation;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects.Ids;

namespace Onix.WebSites.Application.Commands.WebSites.Delete;

public class DeleteWebSiteValidator : AbstractValidator<DeleteWebSiteCommand>
{
    public DeleteWebSiteValidator()
    {
        RuleFor(w => w.WebSiteId)
            .NotEmpty()
            .WithError(Errors.Domain.Empty(nameof(WebSiteId)));
    }
}