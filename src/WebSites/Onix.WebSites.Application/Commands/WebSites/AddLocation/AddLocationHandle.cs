using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Onix.Core.Abstraction;
using Onix.Core.Extensions;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Application.Commands.WebSites.AddContact;
using Onix.WebSites.Application.Database;
using Onix.WebSites.Domain.Locations;
using Onix.WebSites.Domain.Locations.ValueObjects;

namespace Onix.WebSites.Application.Commands.WebSites.AddLocation;

public class AddLocationHandle
{
    private readonly ILogger<AddLocationHandle> _logger;
    private readonly IWebSiteRepository _webSiteRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<AddLocationCommand> _validator;

    public AddLocationHandle(
        ILogger<AddLocationHandle> logger,
        IWebSiteRepository webSiteRepository,
        IUnitOfWork unitOfWork,
        IValidator<AddLocationCommand> validator)
    {
        _logger = logger;
        _webSiteRepository = webSiteRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result<Guid, ErrorList>> Handle(
        AddLocationCommand command, CancellationToken cancellationToken = default)
    {
        var validator = await _validator.ValidateAsync(command, cancellationToken);
        if (!validator.IsValid)
            return validator.ToList();

        var webSiteId = WebSiteId.Create(command.WebSiteId);

        var webSiteResult = await _webSiteRepository
            .GetByIdWithLocation(webSiteId, cancellationToken);
        if (webSiteResult.IsFailure)
            return webSiteResult.Error.ToErrorList();

        var locationId = LocationId.NewId();
        var name = Name.Create(command.Name).Value;
        var phone = Phone.Create(command.Phone).Value;
        
        var address = Address.Create(
            command.City,
            command.Street,
            command.Build,
            command.Index).Value;

        var location = Location.Create(
            locationId,
            name,
            phone,
            address).Value;

        var result = webSiteResult.Value.AddLocation(location);
        if (result.IsFailure)
            return result.Error.ToErrorList();
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return location.Id.Value;
    }
}