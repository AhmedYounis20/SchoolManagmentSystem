namespace StudentAffairWeb.Server;

public class BaseSettingConfiguration<TEntity> : BaseConfiguration<TEntity>,IEntityTypeConfiguration<TEntity> where TEntity : BaseSetting
{
    public virtual new void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
        builder.Property(e=>e.Name).IsRequired();
     
    
    }
}
