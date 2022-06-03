using ConfigurationManager.Core.Models.ParameterObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigurationManager.Repository.Configurations
{
    internal class TextAreaConfiguration : IEntityTypeConfiguration<TextArea>
    {
        public void Configure(EntityTypeBuilder<TextArea> builder)
        {
            throw new NotImplementedException();
        }
    }
}
