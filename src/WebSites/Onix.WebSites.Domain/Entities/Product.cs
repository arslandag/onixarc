using CSharpFunctionalExtensions;
using Onix.SharedKernel.ValueObjects;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.Entities.ValueObjects;

namespace Onix.WebSites.Domain.Entities;

public class Product : SharedKernel.Entity<ProductId>
{
    //ef core
    private Product(ProductId id) : base(id)
    {
    }
    
    private Product(
        ProductId id,
        Name name,
        Description description,
        Price price,
        Link link) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        Link = link;
    }
    
    public Name Name {get; private set; }
    public Description Description { get; private set; }
    public Price Price { get; private set; }
    public Link Link { get; private set; }
    
    public IReadOnlyList<Photo> ProductPhotos => _productPhotos ;
    private readonly List<Photo> _productPhotos = [];

    public static Result<Product> Create(
        ProductId id,
        Name name,
        Description description,
        Price price,
        Link link)
    {
        return new Product(
            id,
            name,
            description,
            price,
            link); 
    }
}