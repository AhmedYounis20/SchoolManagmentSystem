namespace StudentAffairWeb.Server;
public class ClassRoomStudentConfiguration : BaseConfiguration<ClassRoomStudent>, IEntityTypeConfiguration<ClassRoomStudent>
{
    public new void Configure(EntityTypeBuilder<ClassRoomStudent> builder)
    { 

            base.Configure(builder);
        builder.HasKey(x => new { x.StudentId,x.ClassRoomId});
        builder.HasOne(e => e.Student).WithMany().HasForeignKey(e => e.StudentId).HasConstraintName("Fk-ClassRoomStudent-Student");


    }
}
