namespace StudentAffairWeb.Server;

public class MessageConfiguration: BaseConfiguration<Message>, IEntityTypeConfiguration<Message>
{
    public new void Configure(EntityTypeBuilder<Message> builder){
        builder.Property(x => x.MessageContent).IsRequired();
        builder.HasOne(e=>e.Sender).WithMany().HasForeignKey(e=>e.SenderId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("Message_SenderId");
        builder.HasOne(e=>e.Reciever).WithMany().HasForeignKey(e=>e.RecieverId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("Message_RecieverId");
        base.Configure(builder);
    }
}