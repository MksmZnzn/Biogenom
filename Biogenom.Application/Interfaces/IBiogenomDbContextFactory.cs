using Biogenom.Application.Interfaces;

namespace Biogenom.Application;

public interface IBiogenomDbContextFactory
{
    public Task<IBiogenomDbContext> CreateDbContextAsync(CancellationToken cancellationToken = default);
}