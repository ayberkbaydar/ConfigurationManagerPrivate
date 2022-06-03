using ConfigurationManager.Core.Models.ParameterObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigurationManager.Repository.Configurations
{
    internal class JsonConfiguration : IEntityTypeConfiguration<Json>
    {
        public void Configure(EntityTypeBuilder<Json> builder)
        {
            throw new NotImplementedException();
        }
    }
}
