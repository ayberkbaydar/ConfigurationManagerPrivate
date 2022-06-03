using ConfigurationManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigurationManager.Repository.Configurations
{
    internal class DraftConfiguration : IEntityTypeConfiguration<Draft>
    {
        public void Configure(EntityTypeBuilder<Draft> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn().IsRequired();

            builder.ToTable("Drafts");

            builder.HasOne(x => x.User).WithOne(x => x.Draft).HasForeignKey<Draft>(x => x.UserId);
            builder.HasOne(x => x.Section).WithOne(x => x.Draft).HasForeignKey<Draft>(x => x.SectionId);
            builder.HasOne(x => x.FileVersion).WithOne(x => x.Draft).HasForeignKey<Draft>(x => x.FileVersionId);
        }
    }
}
