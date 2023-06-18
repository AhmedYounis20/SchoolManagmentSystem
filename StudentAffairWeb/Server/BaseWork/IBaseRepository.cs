namespace StudentAffairWeb.Server;

public interface IBaseRepository<TEntity>:IDisposable  where TEntity : Base
{
    public Task Add(TEntity entity);
    public Task Add(IEnumerable<TEntity> entities);
   
    public Task<IEnumerable<TEntity>> Get();
    
    public Task<TEntity> Get(Guid id);


    public Task Update(TEntity entity);
    public Task Update(IEnumerable<TEntity> entities);
   
    public Task Delete(Guid  entityId);
    public Task Delete(TEntity entity);
    public Task Delete(IEnumerable<TEntity> entities);


    public Task<IDbContextTransaction> GetTransaction();
}
