using CSharpFunctionalExtensions;

namespace Onix.WebSites.Domain.Locations.ValueObjects;

public record Address
{
    private Address(
        string city,
        string street,
        string build,
        string? index)
    {
        City = city;
        Street = street;
        Build = build;
        Index = index;
    }

    public string City { get; }
    public string Street { get; }
    public string Build { get; }
    public string? Index { get; }

    public static Result<Address> Create(
        string city,
        string street,
        string build,
        string? index)
    {
        return new Address(
            city,
            street,
            build,
            index);
    }
}