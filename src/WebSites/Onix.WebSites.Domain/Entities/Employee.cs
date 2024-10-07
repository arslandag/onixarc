using CSharpFunctionalExtensions;
using Onix.SharedKernel.ValueObjects;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.Entities.ValueObjects;

namespace Onix.WebSites.Domain.Entities;

public class Employee : SharedKernel.Entity<EmployeeId>
{
    //ef core
    private Employee(EmployeeId id) : base(id)
    {
    }
    
    private Employee(
        EmployeeId id,
        EmployeeFullName fullName,
        Description description,
        Photo photo) : base(id)
    {
        FullName = fullName;
        Description = description;
        Photo = photo;
    }

    public EmployeeFullName FullName { get; private set; }
    public Description Description { get; private set; }
    public Photo Photo { get; private set; }

    public static Result<Employee> Create(
        EmployeeId id,
        EmployeeFullName fullName,
        Description description,
        Photo photo)
    {
        return new Employee(
            id,
            fullName,
            description,
            photo);
    }
}