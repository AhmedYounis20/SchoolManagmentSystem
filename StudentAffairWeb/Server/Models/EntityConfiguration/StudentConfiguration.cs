namespace StudentAffairWeb.Server;

public class StudentConfiguration : BaseSettingConfiguration<Student>, IEntityTypeConfiguration<Student> 
{
    public new void Configure(EntityTypeBuilder<Student> builder)
    {
        base.Configure(builder);
        builder.Property(e=>e.Birthdate).IsRequired();
        builder.Property(e=>e.Phone).IsRequired();

    
    }
}
