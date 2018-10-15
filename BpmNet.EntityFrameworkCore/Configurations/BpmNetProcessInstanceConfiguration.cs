using BpmNet.EntityFrameworkCore.Models;
using BpmNet.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BpmNet.EntityFrameworkCore.Configurations
{
    public class BpmNetProcessInstanceConfiguration<TProcessInstance, TInstanceFlow> : IEntityTypeConfiguration<TProcessInstance>
        where TProcessInstance : class, IProcessInstance<TInstanceFlow>
        where TInstanceFlow : BpmNetInstanceFlow
    {
        public void Configure(EntityTypeBuilder<TProcessInstance> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasMany(t => t.Flows).WithOne().HasForeignKey(t => t.ProcessInstanceId);

            builder.ToTable("BPMNET_PROCESS_INSTANCE");
        }
    }
}
