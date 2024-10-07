using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Onix.Core.Abstraction;
using Onix.WebSites.Infrastructure.DbContexts;

namespace Onix.WebSites.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly WriteDbContext _dbContexts;

    public UnitOfWork(WriteDbContext dbContexts)
    {
        _dbContexts = dbContexts;
    }

    public async Task<IDbTransaction> BeginTransaction(
        CancellationToken cancellationToken = default)
    {
        var transaction = await _dbContexts.Database.BeginTransactionAsync(cancellationToken);
        
        return transaction.GetDbTransaction();
    }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        await _dbContexts.SaveChangesAsync(cancellationToken);
    }
}
    
