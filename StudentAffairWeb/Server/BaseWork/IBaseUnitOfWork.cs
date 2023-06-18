
namespace StudentAffairWeb.Server;

public interface IBaseUnitOfWork<TEntity>: IDisposable where TEntity : Base
{
    public Task Create(TEntity entity);
    public Task Create(IEnumerable<TEntity> entities);

    public Task<IEnumerable<TEntity>> Read();
    
    public Task<TEntity> Read(Guid id);

    public Task Update(TEntity entity);
    public Task Update(IEnumerable<TEntity> entities);

    public Task Delete(Guid entityId);
    public Task Delete(TEntity entity);
    public Task Delete(IEnumerable<TEntity> entities);
}
