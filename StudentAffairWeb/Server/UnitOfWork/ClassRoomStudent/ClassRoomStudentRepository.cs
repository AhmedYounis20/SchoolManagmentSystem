namespace StudentAffairWeb.Server;

public class ClassRoomStudentRepository : BaseRepository<ClassRoomStudent>, IClassRoomStudentRepository
{
    private ApplicationDbContext context;

    public ClassRoomStudentRepository(ApplicationDbContext _context) : base(_context){
        context = _context;
    }

    

}
