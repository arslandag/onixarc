using CSharpFunctionalExtensions;
using Onix.SharedKernel.ValueObjects;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.Locations.ValueObjects;

namespace Onix.WebSites.Domain.Locations;

public class Location : SharedKernel.Entity<LocationId>
{
    //ef core
    private Location(LocationId id) : base(id)
    {
    }
    
    private Location(
        LocationId id,
        Name name,
        Phone locationPhone,
        Address locationAddress) : base(id)
    {
        Name = name;
        LocationPhone = locationPhone;
        LocationAddress = locationAddress;
    }
    
    public Name Name { get; private set; }
    public Phone LocationPhone { get; private set; }
    public Address LocationAddress { get; private set; }

    public IReadOnlyList<Schedule> Schedules => _schedules;
    private readonly List<Schedule> _schedules = [];
    
    public static Result<Location> Create(
        LocationId id,
        Name name,
        Phone locationPhone,
        Address locationAddress)
    {
        return new Location(
            id,
            name,
            locationPhone,
            locationAddress);
    }
}