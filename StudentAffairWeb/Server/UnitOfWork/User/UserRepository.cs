namespace StudentAffairWeb.Server;

public class UserRepository : BaseSettingRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext _context) : base(_context) { }
}
