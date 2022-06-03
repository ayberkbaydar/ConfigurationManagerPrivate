using ConfigurationManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigurationManager.Repository.Seeds
{
    internal class InstanceSeed : IEntityTypeConfiguration<Instance>
    {
        public void Configure(EntityTypeBuilder<Instance> builder)
        {
            //builder.HasData(new Instance { Id=1,Name="DefaultInstance"});
        }
    }
}
