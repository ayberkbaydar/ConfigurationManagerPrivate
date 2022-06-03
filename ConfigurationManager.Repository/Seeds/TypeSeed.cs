using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Type = ConfigurationManager.Core.Models.Type;

namespace ConfigurationManager.Repository.Seeds
{
    internal class TypeSeed : IEntityTypeConfiguration<Type>
    {
        public void Configure(EntityTypeBuilder<Type> builder)
        {
            builder.HasData(new Type { Id = 1, Name = "None" },
                            new Type { Id = 2, Name = "ConfigurationAdmin" },
                            new Type { Id = 3, Name = "InstanceAdmin" });
        }
    }
}
