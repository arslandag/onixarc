using CSharpFunctionalExtensions;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.Categories.ValueObjects;
using Onix.WebSites.Domain.Photos;

namespace Onix.WebSites.Domain.Categories.Entities;

public class Service : SharedKernel.Entity<ServiceId>
{
    //ef core
    private Service (ServiceId id) : base(id)
    {
    }
    
    private Service(
        ServiceId id,
        Name name,
        Description description,
        Price price,
        int? duration,
        Link link) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        Duration = duration;
        Link = link;
    } 

    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Price Price { get; private set; }
    public int? Duration { get; private set; }
    public Link Link { get; private set; }
    
    public IReadOnlyList<Photo> ServicePhotos => _servicePhotos ;
    private readonly List<Photo> _servicePhotos = [];

    public static Result<Service> Create(
        ServiceId id,
        Name name,
        Description description,
        Price price,
        int? duration,
        Link link)
    {
        return new Service(
            id,
            name,
            description,
            price,
            duration,
            link);
    }
    
    //photo
    public UnitResult<Error> AddPhoto(
        Photo photo)
    {
        if (_servicePhotos.Count >= Constants.MAX_PHOTO_COUNT)
            return UnitResult.Failure<Error>(
                Errors.Domain.MaxCount(nameof(photo)));

        _servicePhotos.Add(photo);
        return UnitResult.Success<Error>();
    }
    
    public UnitResult<Error> RemovePhoto(
        Photo photo)
    {
        if (_servicePhotos.Count is Constants.MIN_COUNT)
            return UnitResult.Failure<Error>(
                Errors.Domain.Empty(nameof(photo)));

        _servicePhotos.Remove(photo);
        return UnitResult.Success<Error>();
    }
}