namespace StudentAffairWeb.Server;

public class TeacherConfiguration : BaseSettingConfiguration<Teacher>,IEntityTypeConfiguration<Teacher> 
{
    public new void Configure(EntityTypeBuilder<Teacher> builder)
    {
   
    }
}
