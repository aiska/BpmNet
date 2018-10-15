using BpmNet.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BpmNet.EntityFrameworkCore.Configurations
{
    public class BpmNetInstanceFlowConfiguration<TInstanceFlow> : IEntityTypeConfiguration<TInstanceFlow>
         where TInstanceFlow : BpmNetInstanceFlow
    {
        public void Configure(EntityTypeBuilder<TInstanceFlow> builder)
        {
            builder.HasKey(t => new { t.ProcessInstanceId, t.FlowId });

            builder.Property(t => t.FlowId).IsUnicode(false).HasMaxLength(32);
            builder.ToTable("BPMNET_INSTANCE_FLOW");
        }
    }
}
