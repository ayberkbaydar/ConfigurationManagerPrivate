using ConfigurationManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigurationManager.Repository.Configurations
{
    internal class ParameterValueConfiguration : IEntityTypeConfiguration<ParameterValue>
    {
        public void Configure(EntityTypeBuilder<ParameterValue> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn().IsRequired();

            builder.ToTable("ParameterValues");
            builder.HasOne(x => x.Draft).WithMany(x => x.Values).HasForeignKey(x => x.DraftId);
        }
    }
}
