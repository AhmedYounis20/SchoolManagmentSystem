namespace StudentAffairWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : BaseController<Message>
    {
        public MessageController(IMessageUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
