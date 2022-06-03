using ConfigurationManager.Core.Models.ParameterObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigurationManager.Repository.Configurations
{
    internal class ComboBoxConfiguration : IEntityTypeConfiguration<ComboBox>
    {
        public void Configure(EntityTypeBuilder<ComboBox> builder)
        {
            throw new NotImplementedException();
        }
    }
}
