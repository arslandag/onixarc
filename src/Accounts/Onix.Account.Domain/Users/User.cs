using CSharpFunctionalExtensions;
using Onix.Account.Domain.Users.ValueObjects;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects;
using Onix.SharedKernel.ValueObjects.Ids;

namespace Onix.Account.Domain.Users;

public class User : SharedKernel.Entity<UserId>
{
    private User(UserId id) : base(id)
    {
        
    }
    
    private User(
        UserId id,
        Email email,
        PasswordHash passwordHash,
        FullName fullName, 
        Phone phone) : base(id)
    {
        Email = email;
        PasswordHash = passwordHash;
        FullName = fullName;
        UserPhone = phone;
    }
    
    public Email Email { get; private set; }
    public PasswordHash PasswordHash { get; private set; }
    public FullName FullName { get; private set; }
    public Phone UserPhone { get; private set; }

    public IReadOnlyList<WebSites.Domain.WebSites.WebSite> WebSites => _webSites;
    private readonly List<WebSites.Domain.WebSites.WebSite> _webSites = [];

    public static Result<User, Error> Create(
        UserId id,
        Email email,
        PasswordHash passwordHash,
        FullName fullName, 
        Phone phone)
    {
        return new User(
            id,
            email,
            passwordHash,
            fullName,
            phone);
    }
}