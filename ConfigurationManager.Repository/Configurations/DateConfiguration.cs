using ConfigurationManager.Core.Models.ParameterObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigurationManager.Repository.Configurations
{
    internal class DateConfiguration : IEntityTypeConfiguration<Date>
    {
        public void Configure(EntityTypeBuilder<Date> builder)
        {
            throw new NotImplementedException();
        }
    }
}
