namespace StudentAffairWeb.Server;

public class MessageUnitOfWork : BaseUnitOfWork<Message>, IMessageUnitOfWork
{
    public MessageUnitOfWork(IMessageRepository repository) : base(repository) { }
}
