namespace StudentAffairWeb.Server;

public class MessageRepository : BaseRepository<Message>, IMessageRepository
{
    public MessageRepository(ApplicationDbContext _context) : base(_context) { }
}
