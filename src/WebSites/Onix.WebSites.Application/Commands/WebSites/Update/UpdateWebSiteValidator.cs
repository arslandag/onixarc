using FluentValidation;
using Onix.Core.Validation;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.WebSites.ValueObjects;

namespace Onix.WebSites.Application.Commands.WebSites.Update;

public class UpdateWebSiteValidator : AbstractValidator<UpdateWebSiteCommand>
{
    public UpdateWebSiteValidator()
    {
        RuleFor(a => a.WebSiteId)
            .NotEmpty()
            .WithError(Errors.Domain.ValueIsRequired(nameof(WebSiteId)));

        RuleFor(a => a.WebSiteId.ToString())
            .Matches(Constants.ID_REGEX)
            .WithError(Errors.Domain.ValueIsInvalid(nameof(WebSiteId)));
        
        RuleFor(c => c.Url)
            .NotEmpty()
            .WithError(Errors.Domain.ValueIsRequired(nameof(Url)));
        
        RuleFor(c => c.Url)
            .MaximumLength(Constants.URL_MAX_LENGHT)
            .WithError(Errors.Domain.MaxLength(nameof(Url)));
        
        RuleFor(c => c.Url)
            .MinimumLength(Constants.URL_MIN_LENGTH)
            .WithError(Errors.Domain.MinLength(nameof(Url)));

        RuleFor(c => c.Url)
            .Matches(Constants.URL_REGEX)
            .WithError(Errors.Domain.ValueIsInvalid(nameof(Url)));

        RuleFor(c => c.Name)
            .NotEmpty()
            .WithError(Errors.Domain.ValueIsRequired(nameof(Name)));

        RuleFor(c => c.Name)
            .MaximumLength(Constants.NAME_MAX_LENGHT)
            .WithError(Errors.Domain.MaxLength(nameof(Name)));
        
        RuleFor(c => c.Name)
            .MinimumLength(Constants.NAME_MIN_LENGHT)
            .WithError(Errors.Domain.MaxLength(nameof(Name)));
    }
}