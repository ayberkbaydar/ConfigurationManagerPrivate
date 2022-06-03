using ConfigurationManager.Core.Models.ParameterObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigurationManager.Repository.Configurations
{
    internal class TextBoxConfiguration : IEntityTypeConfiguration<TextBox>
    {
        public void Configure(EntityTypeBuilder<TextBox> builder)
        {
            throw new NotImplementedException();
        }
    }
}
