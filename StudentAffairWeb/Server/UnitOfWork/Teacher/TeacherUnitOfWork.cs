namespace StudentAffairWeb.Server;

public class TeacherUnitOfWork : BaseSettingUnitOfWork<Teacher>, ITeacherUnitOfWork
{
    public TeacherUnitOfWork(ITeacherRepository repository) : base(repository) { }
}
