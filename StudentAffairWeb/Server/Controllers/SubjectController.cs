using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentAffairWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : BaseSettingController<Subject>
    {
        public SubjectController(ISubjectUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
