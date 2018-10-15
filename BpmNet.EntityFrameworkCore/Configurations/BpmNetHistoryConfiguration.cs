using BpmNet.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BpmNet.EntityFrameworkCore.Configurations
{
    public class BpmNetHistoryConfiguration<THistory> : IEntityTypeConfiguration<THistory>
        where THistory : class, IBpmNetHistory
    {
        public void Configure(EntityTypeBuilder<THistory> builder)
        {
            builder.HasKey(t => t.Id);

            builder.ToTable("BPMNET_HISTORY");
        }
    }
}
