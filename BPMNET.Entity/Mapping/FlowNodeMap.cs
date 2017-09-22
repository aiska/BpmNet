using BPMNET.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace BPMNET.Entity.Mapping
{
    public class FlowNodeMap : EntityTypeConfiguration<FlowNodeEntity>
    {
        public FlowNodeMap()
        {
            DatabaseGeneratedOption option = Config.Instance.GeneratedOption;
            bool unicode = Config.Instance.UnicodeString;

            // Primary Key
            HasKey(t => new { t.Id });

            // Properties
            Property(p => p.Id).HasDatabaseGeneratedOption(option);
            //Property(p => p.ProcessId).IsRequired().AddColumnIndex("IX_FLOW_NODE_PROCESS_ID", 0).AddColumnIndex("IX_FLOW_NODE_ITEM_TYPE", 0);
            Property(p => p.FlowNodeId).IsRequired().HasMaxLength(255).IsUnicode(unicode).AddColumnIndex("IX_FLOW_NODE_ID", 0);
            Property(p => p.Name).HasMaxLength(255).IsUnicode(unicode).AddColumnIndex("IX_FLOW_NODE_NAME", 0);
            Property(p => p.ItemType).AddColumnIndex("IX_FLOW_NODE_ITEM_TYPE", 1);
            Property(p => p.Users).IsUnicode(unicode);
            Property(p => p.Roles).IsUnicode(unicode);
            Ignore(t => t.UserCandidates);
            Ignore(t => t.RoleCandidates);

            // Table & Column Mappings
            ToTable(Config.Instance.Tables.FlowNode);
            MapToStoredProcedures();
        }
    }
}
