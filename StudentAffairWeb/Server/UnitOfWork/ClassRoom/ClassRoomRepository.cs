namespace StudentAffairWeb.Server;

public class ClassRoomRepository : BaseSettingRepository<ClassRoom>, IClassRoomRepository
{
    private ApplicationDbContext context;

    public ClassRoomRepository(ApplicationDbContext _context) : base(_context){
        context = _context;
    }

    public override async Task<IEnumerable<ClassRoom>> Get() => await context.Set<ClassRoom>().Include(e => e.Subject).Include(e => e.Teacher).Include(e => e.ClassRoomStudents).ThenInclude(e=>e.Student).ToListAsync();
    public override async Task<ClassRoom> Get(Guid id ) => await context.Set<ClassRoom>().Include(e => e.Subject).Include(e => e.Teacher).Include(e => e.ClassRoomStudents).ThenInclude(e => e.Student).FirstOrDefaultAsync(e=>e.Id==id) ?? Activator.CreateInstance<ClassRoom>();



}
