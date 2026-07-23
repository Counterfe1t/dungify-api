namespace Dungify.Infrastructure.DAL.Transactions;

internal sealed class UnitOfWork(DungifyDbContext dbContext) : IUnitOfWork
{
    public async Task ExecuteAsync(Func<Task> action)
    {
        using var transaction = await dbContext.Database.BeginTransactionAsync();

        try
        {
            await action();
            await dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}