
using System.Linq.Expressions;
using System.Reflection;

namespace StudentAffairWeb.Server;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Base
{
    private ApplicationDbContext context;
    protected DbSet<TEntity> dbSet;

    public BaseRepository(ApplicationDbContext _context)
    {
        context = _context;
        dbSet = context.Set<TEntity>();
    }

    public virtual async Task Add(TEntity entity)
    {
        try
        {

            CheckNullParameter(entity);
            await dbSet.AddAsync(entity);
            await SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }

    public virtual async Task Add(IEnumerable<TEntity> entities)
    {
        CheckNullParameter(entities);
        await dbSet.AddRangeAsync(entities);
        await SaveChangesAsync();
    }

    public virtual async Task<TEntity> Get(Guid id) => await dbSet.FirstOrDefaultAsync(e => e.Id == id) ?? Activator.CreateInstance<TEntity>();
    public virtual async Task<IEnumerable<TEntity>> Get() => await dbSet.ToListAsync();
    public virtual async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate) => await dbSet.Where(predicate).ToListAsync();
   
    public virtual async Task Delete(Guid entityId)
    {
        TEntity? entity = await CheckIfInDatabase(entityId);
        await Task.Run(() => { dbSet.Remove(entity); });
        await SaveChangesAsync();
    }

    public virtual async Task Update(TEntity entity)
    {
        CheckNullParameter(entity);
        await CheckIfInDatabase(entity);
        await Task.Run(() => { dbSet.Update(entity); });
        await SaveChangesAsync();
    }

    public virtual async Task Update(IEnumerable<TEntity> entities)
    {
        CheckNullParameter(entities);
        await CheckIfInDatabase(entities);
        await Task.Run(() => { dbSet.UpdateRange(entities); });
        await SaveChangesAsync();
    }
    public virtual async Task Delete(TEntity entity)
    {
        CheckNullParameter(entity);
        await CheckIfInDatabase(entity);
        await Task.Run(() => { dbSet.Remove(entity); });
        await SaveChangesAsync();
    }
    public virtual async Task Delete(IEnumerable<TEntity> entities)
    {
        CheckNullParameter(entities);
        foreach (TEntity entity in entities)
        {
            await CheckIfInDatabase(entity);
        }
        await Task.Run(() =>
        {

            dbSet.RemoveRange(entities);
        });


    }

    public async Task<IDbContextTransaction> GetTransaction() => await context.Database.BeginTransactionAsync();
    private async Task SaveChangesAsync() => await context.SaveChangesAsync();
    public void Dispose() => context.Dispose();

    // Exceptions
    private void CheckNullParameter(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException($"{nameof(entity)} is not provided");
    }

    private void CheckNullParameter(IEnumerable<TEntity> entities)
    {
        if (entities == null || !entities.Any())
            throw new ArgumentNullException($"{nameof(TEntity)} was not provided");
    }

    private async Task<TEntity> CheckIfInDatabase(Guid entityId)
    {
        TEntity? entity = await Get(entityId);
        if (entity == null)
            throw new ArgumentNullException($"{nameof(TEntity)} is not found in DB.");

        return entity;
    }

    private async Task<TEntity> CheckIfInDatabase(TEntity ent)
    {
        TEntity? entity = await Get(ent.Id);
        if (entity == null)
            throw new ArgumentNullException($"{nameof(TEntity)} is not found in DB.");

        return entity;
    }
    private async Task CheckIfInDatabase(IEnumerable<TEntity> entities)
    {
        foreach (TEntity entity in entities)
        {
            await CheckIfInDatabase(entity);
        }
    }

}