using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Type = ConfigurationManager.Core.Models.Type;

namespace ConfigurationManager.Repository.Configurations
{
    internal class TypeConfiguration : IEntityTypeConfiguration<Type>
    {
        public void Configure(EntityTypeBuilder<Type> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn().IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.ToTable("Types");
        }
    }
}
