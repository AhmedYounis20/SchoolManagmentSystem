namespace StudentAffairWeb.Server;

public class UserUnitOfWork : BaseSettingUnitOfWork<User>, IUserUnitOfWork
{
    public UserUnitOfWork(IUserRepository repository) : base(repository) { }
}