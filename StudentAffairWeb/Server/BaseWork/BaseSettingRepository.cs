namespace StudentAffairWeb.Server;

public class BaseSettingRepository<TEntity> : BaseRepository<TEntity>, IBaseSettingRepository<TEntity> where TEntity : BaseSetting
{
    public BaseSettingRepository(ApplicationDbContext _context) : base(_context){}

    public async Task<IEnumerable<TEntity>> Search(string name)=> await dbSet.Where(x => x.Name.Contains(name)).ToListAsync(); 
}
