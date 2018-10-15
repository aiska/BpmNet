using BpmNet.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BpmNet.EntityFrameworkCore.Configurations
{
    public class BpmNetDefinitionConfiguration : IEntityTypeConfiguration<BpmNetDefinition>
    {
        public void Configure(EntityTypeBuilder<BpmNetDefinition> builder)
        {
            // Key
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).IsUnicode(false).HasMaxLength(32);

            // Table
            builder.ToTable("BPMNET_DEFINITION");
        }
    }
}
