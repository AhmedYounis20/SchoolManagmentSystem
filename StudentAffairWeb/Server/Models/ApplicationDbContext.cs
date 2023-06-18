namespace StudentAffairWeb.Server;

public class ApplicationDbContext:DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new TeacherConfiguration())
                    .ApplyConfiguration(new StudentConfiguration())
                    .ApplyConfiguration(new ClassRoomConfiguration())
                    .ApplyConfiguration(new ClassRoomStudentConfiguration())
                    .ApplyConfiguration(new SubjectConfiguration())
                    .ApplyConfiguration(new MessageConfiguration())
                    .ApplyConfiguration(new LogConfiguration())
                    .ApplyConfiguration(new UserConfiguration());
    }
}