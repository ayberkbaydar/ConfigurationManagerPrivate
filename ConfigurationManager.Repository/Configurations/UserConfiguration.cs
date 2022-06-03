using ConfigurationManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigurationManager.Repository.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn().IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(250);

            builder.ToTable("Users");

            builder.HasOne(x => x.Instance).WithMany(x => x.Users).HasForeignKey(x => x.InstanceId);
            builder.HasOne(x => x.Type).WithMany(x => x.Users).HasForeignKey(x=>x.TypeId);
        }
    }
}
