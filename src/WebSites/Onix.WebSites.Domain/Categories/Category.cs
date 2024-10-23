using CSharpFunctionalExtensions;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.Categories.Entities;

namespace Onix.WebSites.Domain.Categories;

public class Category : SharedKernel.Entity<CategoryId>
{
    //ef core
    private Category(CategoryId id) : base(id)
    {
    }

    private Category(
        CategoryId id,
        Name name,
        Category? parentCategory) : base(id)
    {
        Name = name;
        ParentCategory = parentCategory;
    }
    
    public Name Name { get; private set; }
    public Category? ParentCategory { get; private set; }
    
    public IReadOnlyList<Category> SubCategory => _subCategories;
    private readonly List<Category> _subCategories = [];
    
    public IReadOnlyList<Service> Services => _services;
    private readonly List<Service> _services = [];
    
    public IReadOnlyList<Product> Products => _products;
    private readonly List<Product> _products = [];

    //category
    public static Result<Category, ErrorList> Create(
        CategoryId id,
        Name name,
        Category? parentCategory)
    {
        return new Category(
            id,
            name,
            parentCategory);
    }

    public UnitResult<Error> Update(Name name)
    {
        this.Name = name;
        return UnitResult.Success<Error>();
    }

    //subcategory
    public UnitResult<Error> AddSubCategory(
        Category category)
    {
        if (_services.Count is not Constants.MIN_COUNT
            && _products.Count is not Constants.MIN_COUNT)
            return UnitResult.Failure<Error>(Errors.Domain.ValueIsInvalid());

        if (_subCategories.Count >= Constants.MAX_CATEGORY_COUNT)
            return UnitResult.Failure<Error>(Errors.Domain.MaxCount());
        
        _subCategories.Add(category);
        return UnitResult.Success<Error>();
    }
    
    public UnitResult<Error> DeleteSubCategory(
        Category category)
    {
        if (_subCategories.Count is Constants.MIN_COUNT)
            return UnitResult.Failure<Error>(
                Errors.Domain.Empty(nameof(category)));

        _subCategories.Remove(category);
        return UnitResult.Success<Error>();
    }

    
    //product
    public UnitResult<Error> AddProduct(
        Product product)
    {
        if (_services.Count is not Constants.MIN_COUNT)
            return UnitResult.Failure<Error>(Errors.Domain.ValueIsInvalid());

        if (_products.Count >= Constants.MAX_PRODUCT_COUNT)
            return UnitResult.Failure(Errors.Domain.MaxCount(nameof(product)));
        
        _products.Add(product);
        return UnitResult.Success<Error>();
    }
    
    public UnitResult<Error> RemoveProduct(
        Product product)
    {
        if (_products.Count is Constants.MIN_COUNT)
            return UnitResult.Failure<Error>(
                Errors.Domain.Empty(nameof(product)));

        _products.Remove(product);
        return UnitResult.Success<Error>();
    }
    
    //service
    public UnitResult<Error> AddService(
        Service service)
    {
        if (_products.Count is not Constants.MIN_COUNT)
            return UnitResult.Failure<Error>(Errors.Domain.ValueIsInvalid());
        
        if (_services.Count >= Constants.MAX_SERVICE_COUNT)
            return UnitResult.Failure(Errors.Domain.MaxCount(nameof(service)));
        
        _services.Add(service);
        return UnitResult.Success<Error>();
    }
    
    public UnitResult<Error> RemoveService(
        Service service)
    {
        if (_services.Count is Constants.MIN_COUNT)
            return UnitResult.Failure<Error>(
                Errors.Domain.Empty(nameof(service)));

        _services.Remove(service);
        return UnitResult.Success<Error>();
    }
}