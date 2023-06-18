namespace StudentAffairWeb.Server;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseSettingController<User>
{
    IUserUnitOfWork _systemUserUnitOfWork;
    public UserController(IUserUnitOfWork unitOfWork) : base(unitOfWork) => _systemUserUnitOfWork = unitOfWork;
}