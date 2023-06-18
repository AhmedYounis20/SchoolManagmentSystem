namespace StudentAffairWeb.Server;

public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Base
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasValueGenerator<GuidValueGenerator>();       
    
    }
}
