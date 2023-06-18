namespace StudentAffairWeb.Server;

public class BaseSettingUnitOfWork<TEntity> : BaseUnitOfWork<TEntity>, IBaseSettingUnitOfWork<TEntity> where TEntity : BaseSetting
{
    private IBaseSettingRepository<TEntity> _repository;

    public BaseSettingUnitOfWork(IBaseSettingRepository<TEntity> repository) : base(repository) => _repository = repository;

    public Task<IEnumerable<TEntity>> Search(string name) => _repository.Search(name);
}
