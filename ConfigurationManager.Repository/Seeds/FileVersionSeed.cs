using ConfigurationManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigurationManager.Repository.Seeds
{
    internal class FileVersionSeed : IEntityTypeConfiguration<FileVersion>
    {
        public void Configure(EntityTypeBuilder<FileVersion> builder)
        {
        }
    }
}
