namespace StudentAffairWeb.Shared;

public  class Message:Base
{
    public Guid? SenderId { get; set; }
    public User? Sender { get; set; }
    public Guid? RecieverId { get; set; }
    public User? Reciever { get; set; }
    public string? MessageContent { get; set; }
    public DateTime? SendTime { get; set; }
    public DateTime? ReceiveTime { get; set;}
}
