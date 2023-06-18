namespace StudentAffairWeb.Server;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseSettingController<TEntity> : BaseController<TEntity> where TEntity : BaseSetting
{
    IBaseSettingUnitOfWork<TEntity> _unitOfWork;
    protected BaseSettingController(IBaseSettingUnitOfWork<TEntity> unitOfWork) : base(unitOfWork)=> _unitOfWork = unitOfWork;
    [HttpGet("Search/{searchText}")]
    public virtual async Task<IEnumerable<TEntity>?> Get(string searchText) => await _unitOfWork.Search(searchText);

}
