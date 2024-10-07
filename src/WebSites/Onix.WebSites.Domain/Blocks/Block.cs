using CSharpFunctionalExtensions;
using Onix.SharedKernel.ValueObjects;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.Entities;
using Onix.WebSites.Domain.Locations;
using Onix.WebSites.Domain.WebSites.ValueObjects;

namespace Onix.WebSites.Domain.Blocks;

public class Block : SharedKernel.Entity<BlockId>
{
    //ef core
    private Block(BlockId id) : base(id)
    {
        
    }
    
    private Block(
        BlockId id,
        Title title,
        Description description,
        Photo backgroundPhoto) : base(id)
    {
        Title = title;
        Description = description;
        BackgroundPhoto = backgroundPhoto;
    }
    
    public Title Title { get; private set; }
    public Description Description { get; private set; }
    public Photo BackgroundPhoto { get; private set; }
    
    public IReadOnlyList<Location> Locations => _locations;
    private readonly List<Location> _locations = [];
    
    public IReadOnlyList<Service> Services => _services;
    private readonly List<Service> _services = [];
    
    public IReadOnlyList<Product> Products => _products;
    private readonly List<Product> _products = [];
    
    public IReadOnlyList<Employee> Employees => _employees;
    private readonly List<Employee> _employees = [];
    
    public IReadOnlyList<Photo> Photos => _photos;
    private readonly List<Photo> _photos = [];

    public static Result<Block> Create(
        BlockId id,
        Title title,
        Description description,
        Photo backgroundPhoto)
    {
        return new Block(
            id,
            title,
            description,
            backgroundPhoto);
    }
}