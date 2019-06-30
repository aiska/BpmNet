using BpmNet.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BpmNet.EntityFrameworkCore.Configurations
{
    public class BpmNetProcessConfiguration : IEntityTypeConfiguration<BpmNetProcess>
    {
        public void Configure(EntityTypeBuilder<BpmNetProcess> builder)
        {
            //Key
            builder.HasKey(t => t.Id);

            // Table
            builder.ToTable("BPMNET_PROCESS");
        }
    }
}
