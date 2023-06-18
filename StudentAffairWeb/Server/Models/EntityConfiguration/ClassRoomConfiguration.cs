namespace StudentAffairWeb.Server;

public class ClassRoomConfiguration : BaseSettingConfiguration<ClassRoom>,IEntityTypeConfiguration<ClassRoom>
{
    public override   void Configure(EntityTypeBuilder<ClassRoom> builder)
    {
        base.Configure(builder);
        builder.ToTable("ClassRooms");
        builder.HasOne(e => e.Subject).WithMany().HasForeignKey(e => e.SubjectId).HasConstraintName("FK-ClassRoom-Subject");
        builder.HasOne(e => e.Teacher).WithMany().HasForeignKey(e => e.TeacherId).HasConstraintName("FK-ClassRoom-Teacher");
        builder.HasMany(e => e.ClassRoomStudents).WithOne().HasForeignKey(e=>e.ClassRoomId).HasConstraintName("FK-ClassRoom-Student");
    }
}
