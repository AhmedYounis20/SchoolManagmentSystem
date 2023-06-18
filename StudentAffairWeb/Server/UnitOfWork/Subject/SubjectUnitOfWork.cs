namespace StudentAffairWeb.Server;

public class SubjectUnitOfWork : BaseSettingUnitOfWork<Subject>, ISubjectUnitOfWork
{
    public SubjectUnitOfWork(ISubjectRepository repository) : base(repository) { }
}
