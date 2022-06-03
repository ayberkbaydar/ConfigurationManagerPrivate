using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Environment = ConfigurationManager.Core.Models.Environment;

namespace ConfigurationManager.Repository.Configurations
{
    internal class EnvironmentConfiguration : IEntityTypeConfiguration<Environment>
    {
        public void Configure(EntityTypeBuilder<Environment> builder)
        {
            throw new NotImplementedException();
        }
    }
}
