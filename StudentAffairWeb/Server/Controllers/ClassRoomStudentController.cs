namespace StudentAffairWeb.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassRoomStudentController : BaseController<ClassRoomStudent>
{
    public ClassRoomStudentController(IClassRoomStudentUnitOfWork unitOfWork) : base(unitOfWork) { }

 
}
