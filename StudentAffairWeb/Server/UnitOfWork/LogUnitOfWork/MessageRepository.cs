namespace StudentAffairWeb.Server;

public class LogRepository : BaseRepository<LogEntity>, ILogRepository
{
    public LogRepository(ApplicationDbContext _context) : base(_context) { }
}
