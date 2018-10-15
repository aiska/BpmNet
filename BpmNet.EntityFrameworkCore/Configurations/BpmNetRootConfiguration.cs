using BpmNet.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BpmNet.EntityFrameworkCore.Configurations
{
    public class BpmNetRootConfiguration : IEntityTypeConfiguration<BpmNetRoot>
    {
        public void Configure(EntityTypeBuilder<BpmNetRoot> builder)
        {
            builder.HasDiscriminator(t => t.Type)
                .HasValue<BpmNetProcess>("Process");
        }
    }
}
