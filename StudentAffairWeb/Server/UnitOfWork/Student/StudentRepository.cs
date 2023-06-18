namespace StudentAffairWeb.Server;

public class StudentRepository : BaseSettingRepository<Student>, IStudentRepository
{
    public StudentRepository(ApplicationDbContext _context) : base(_context) { }
}
