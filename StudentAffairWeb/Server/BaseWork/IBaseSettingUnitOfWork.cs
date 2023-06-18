namespace StudentAffairWeb.Server;

public interface IBaseSettingUnitOfWork<TEntity>: IBaseUnitOfWork<TEntity>, IDisposable where TEntity : BaseSetting
{
    Task<IEnumerable<TEntity>> Search(string name);
}
