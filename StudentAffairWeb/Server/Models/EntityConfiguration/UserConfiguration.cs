namespace StudentAffairWeb.Server;

public class UserConfiguration : BaseSettingConfiguration<User>, IEntityTypeConfiguration<User> 
{
    public new void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        builder.Property(e=>e.Email).IsRequired();
    }
}