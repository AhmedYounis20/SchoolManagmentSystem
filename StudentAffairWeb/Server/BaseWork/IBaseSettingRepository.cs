namespace StudentAffairWeb.Server;

public interface IBaseSettingRepository<TEntity>:IBaseRepository<TEntity>, IDisposable where TEntity : BaseSetting
{
    Task<IEnumerable<TEntity>> Search(string name);
}
