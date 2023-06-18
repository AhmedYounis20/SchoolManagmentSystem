namespace StudentAffairWeb.Server;

public class LogUnitOfWork : BaseUnitOfWork<LogEntity>, ILogUnitOfWork
{
    public LogUnitOfWork(ILogRepository repository) : base(repository) { }
}