using ConfigurationManager.Core.Models.ParameterObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigurationManager.Repository.Configurations
{
    internal class NumberBoxConfiguration : IEntityTypeConfiguration<NumberBox>
    {
        public void Configure(EntityTypeBuilder<NumberBox> builder)
        {
            throw new NotImplementedException();
        }
    }
}
