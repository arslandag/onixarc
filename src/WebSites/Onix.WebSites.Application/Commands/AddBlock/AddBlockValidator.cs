using FluentValidation;
using Onix.Core.Validation;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects;
using Onix.WebSites.Domain.WebSites.ValueObjects;

namespace Onix.WebSites.Application.Commands.AddBlock;

public class AddBlockValidator : AbstractValidator<AddBlockCommand>
{
    public AddBlockValidator()
    {
        RuleFor(a => a.Title)
            .MaximumLength(Constants.TITLE_MAX_LENGHT)
            .WithError(Errors.Domain.MaxLength(nameof(Title)));

        RuleFor(a => a.Description)
            .MaximumLength(Constants.DESCRIPTION_MAX_LENGHT)
            .WithError(Errors.Domain.MaxLength(nameof(Description)));
    }
}