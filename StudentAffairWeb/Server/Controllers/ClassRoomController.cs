namespace StudentAffairWeb.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassRoomController : BaseSettingController<ClassRoom>
{
    public ClassRoomController(IClassRoomUnitOfWork unitOfWork) : base(unitOfWork) { }
}
