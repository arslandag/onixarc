using FluentValidation;
using Onix.Core.Validation;
using Onix.SharedKernel;
using Onix.WebSites.Domain.Blocks.ValueObjects;

namespace Onix.WebSites.Application.Commands.Blocks.AddBlock;

public class AddBlockValidator : AbstractValidator<AddBlockCommand>
{
    public AddBlockValidator()
    {
        RuleFor(a => a.WebSiteId)
            .NotEmpty()
            .WithError(Errors.Domain.ValueIsRequired(nameof(WebSites)));
        
        RuleFor(a => a.Code)
            .MaximumLength(Constants.CODE_MAX_LENGHT)
            .WithError(Errors.Domain.MaxLength(nameof(Code)));
    }
}