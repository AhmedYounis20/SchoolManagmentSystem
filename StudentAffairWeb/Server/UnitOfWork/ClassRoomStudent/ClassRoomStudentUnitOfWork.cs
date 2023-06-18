namespace StudentAffairWeb.Server;

public class ClassRoomStudentUnitOfWork : BaseUnitOfWork<ClassRoomStudent>, IClassRoomStudentUnitOfWork
{
    private readonly IClassRoomStudentRepository _studentrepo;
    public ClassRoomStudentUnitOfWork(IClassRoomStudentRepository repository) : base(repository) 
    {
        _studentrepo = repository;
    }

    public override Task Create(ClassRoomStudent entity)
    {
        entity.JoinedOn = DateTime.Now;
        return base.Create(entity);
    }

}
