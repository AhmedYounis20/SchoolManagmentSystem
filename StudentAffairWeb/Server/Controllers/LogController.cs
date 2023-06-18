namespace StudentAffairWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : BaseController<LogEntity>
    {
        public LogController(ILogUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
