using ConfigurationManager.Core.Models;
using File = ConfigurationManager.Core.Models.File;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigurationManager.Repository.Configurations
{
    internal class InstanceConfiguration : IEntityTypeConfiguration<Instance>
    {
        public void Configure(EntityTypeBuilder<Instance> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn().IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.ToTable("Instances");

            //builder.HasOne(x => x.).WithOne(x => x.).HasForeignKey<File>(x => x.InstanceId);
        }
    }
}
