using ConfigurationManager.Core.Models.ParameterObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigurationManager.Repository.Configurations
{
    internal class SwitchConfiguration : IEntityTypeConfiguration<Switch>
    {
        public void Configure(EntityTypeBuilder<Switch> builder)
        {
            throw new NotImplementedException();
        }
    }
}
