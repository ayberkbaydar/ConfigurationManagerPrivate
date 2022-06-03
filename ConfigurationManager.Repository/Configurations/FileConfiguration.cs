using ConfigurationManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using File = ConfigurationManager.Core.Models.File;

namespace ConfigurationManager.Repository.Configurations
{
    internal class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn().IsRequired();

            builder.ToTable("Files");
            builder.HasOne(x => x.Instance).WithMany(x => x.ConfigFiles).HasForeignKey(x => x.InstanceId);

        }
    }
}
