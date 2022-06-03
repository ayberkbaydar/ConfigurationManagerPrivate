using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using File = ConfigurationManager.Core.Models.File;

namespace ConfigurationManager.Repository.Seeds
{
    internal class FileSeed : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.HasData(new File { Id = 1 });
        }
    }
}
