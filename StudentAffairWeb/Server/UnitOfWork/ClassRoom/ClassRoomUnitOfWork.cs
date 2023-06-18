namespace StudentAffairWeb.Server;

public class ClassRoomUnitOfWork : BaseSettingUnitOfWork<ClassRoom>, IClassRoomUnitOfWork
{
    public ClassRoomUnitOfWork(IClassRoomRepository repository) : base(repository)
    {
    }
}
