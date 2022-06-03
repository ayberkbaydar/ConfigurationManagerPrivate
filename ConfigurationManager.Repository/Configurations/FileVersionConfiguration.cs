using ConfigurationManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigurationManager.Repository.Configurations
{
    internal class FileVersionConfiguration : IEntityTypeConfiguration<FileVersion>
    {
        public void Configure(EntityTypeBuilder<FileVersion> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn().IsRequired();

            builder.HasOne(x => x.File).WithMany(x => x.Versions).HasForeignKey(x => x.FileId);
            builder.HasOne(x => x.Draft).WithOne(x => x.FileVersion).HasForeignKey<Draft>(x => x.FileVersionId);
        }
    }
}
