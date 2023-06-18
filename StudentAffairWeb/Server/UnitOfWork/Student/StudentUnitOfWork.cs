namespace StudentAffairWeb.Server;

public class StudentUnitOfWork : BaseSettingUnitOfWork<Student>, IStudentUnitOfWork
{
    public StudentUnitOfWork(IStudentRepository repository) : base(repository) { }
}
