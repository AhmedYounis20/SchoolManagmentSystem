

namespace StudentAffairWeb.Server;

public class BaseUnitOfWork<TEntity> : IBaseUnitOfWork<TEntity> where TEntity : Base
{
    IBaseRepository<TEntity> _repository;
    public BaseUnitOfWork(IBaseRepository<TEntity> repository) => _repository = repository;

    public virtual async Task Create(TEntity entity) => await _repository.Add(entity);

    public virtual async Task Create(IEnumerable<TEntity> entities) => await _repository.Add(entities);


    public virtual async Task<IEnumerable<TEntity>> Read() => await _repository.Get();
    public async Task<TEntity> Read(Guid id) => await _repository.Get(id);


    public async Task Update(TEntity entity) => await _repository.Update(entity);
    public async Task Update(IEnumerable<TEntity> entities) => await _repository.Update(entities);

 
    public async Task Delete(Guid entityId) => await _repository.Delete(entityId);
    public async Task Delete(TEntity entity) => await _repository.Delete(entity);
    public Task Delete(IEnumerable<TEntity> entities) => _repository.Delete(entities);

    public void Dispose() => _repository.Dispose();
}
