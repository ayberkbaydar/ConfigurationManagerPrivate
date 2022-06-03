using ConfigurationManager.Core.Models.ParameterObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigurationManager.Repository.Configurations
{
    internal class CheckBoxConfiguration : IEntityTypeConfiguration<CheckBox>
    {
        public void Configure(EntityTypeBuilder<CheckBox> builder)
        {
            throw new NotImplementedException();
        }
    }
}
