using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentAffairWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : BaseSettingController<Teacher>
    {
        public TeacherController(ITeacherUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
