namespace StudentAffairWeb.Server;

public class SubjectRepository : BaseSettingRepository<Subject>, ISubjectRepository
{
    public SubjectRepository(ApplicationDbContext _context) : base(_context) { }
}
