using Biogenom.Application;
using Biogenom.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.Persistence;

public class BiogenomDbContextFactory : IBiogenomDbContextFactory
{
    private readonly IDbContextFactory<BiogenomDbContext> _dbFactory;

    public BiogenomDbContextFactory(IDbContextFactory<BiogenomDbContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }
    
    public async Task<IBiogenomDbContext> CreateDbContextAsync(CancellationToken cancellationToken = default)
    {
        return await _dbFactory.CreateDbContextAsync(cancellationToken);
    }
}