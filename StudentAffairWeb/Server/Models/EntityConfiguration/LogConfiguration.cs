namespace StudentAffairWeb.Server;

public class LogConfiguration: BaseConfiguration<LogEntity>, IEntityTypeConfiguration<LogEntity>
{
    public new void Configure(EntityTypeBuilder<LogEntity> builder){
        base.Configure(builder);
    }
}