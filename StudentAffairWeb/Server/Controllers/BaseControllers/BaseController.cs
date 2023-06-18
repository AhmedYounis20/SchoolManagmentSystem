namespace StudentAffairWeb.Server;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController<TEntity> : ControllerBase where TEntity : Base
{
    private readonly IBaseUnitOfWork<TEntity> _unitOfWork;

    public BaseController(IBaseUnitOfWork<TEntity> unitOfWork) => _unitOfWork = unitOfWork;

    [HttpPost]
    public virtual async Task Post([FromBody] TEntity entity) => await _unitOfWork.Create(entity);

    [HttpGet]
    public virtual async Task<IEnumerable<TEntity>?> Get() => await _unitOfWork.Read();
    [HttpGet("{id}")]
    public virtual async Task<TEntity> Get(Guid id) => await _unitOfWork.Read(id);
    
    [HttpPut]
    public virtual async Task Put([FromBody] TEntity entity) => await _unitOfWork.Update(entity);
   
    [HttpDelete("{id}")]
    public virtual async Task DeleteAsync(Guid id) => await _unitOfWork.Delete(id);
}
