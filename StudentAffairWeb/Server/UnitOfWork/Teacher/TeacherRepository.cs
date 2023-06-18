namespace StudentAffairWeb.Server;

public class TeacherRepository : BaseSettingRepository<Teacher>, ITeacherRepository
{
    public TeacherRepository(ApplicationDbContext _context) : base(_context) { }
}
