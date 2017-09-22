using BPMNET.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace BPMNET.Entity.Mapping
{
    public class ProcessTaskMap : EntityTypeConfiguration<ProcessTaskEntity>
    {
        public ProcessTaskMap()
        {
            DatabaseGeneratedOption option = Config.Instance.GeneratedOption;
            bool unicode = Config.Instance.UnicodeString;

            // Primary Key
            HasKey(t => new { t.Id });

            // Properties
            Property(p => p.Id).HasDatabaseGeneratedOption(option);
            //Property(p => p.Name).HasMaxLength(255).IsUnicode(unicode).AddColumnIndex("IX_TASK_NAME", 0);
            Property(p => p.ProcessInstanceId).AddColumnIndex("IX_TASK_PROCESS_INSTANCE_ID", 0).AddColumnIndex("IX_TASK_PROCESS_INSTANCE_ID_FLOW_NAME", 0);
            Property(p => p.FlowNodeId).AddColumnIndex("IX_TASK_FLOW_ID", 0);
            Property(p => p.Assignee).HasMaxLength(255).IsUnicode(unicode);
            //Property(p => p.BusinessKey).HasMaxLength(255).IsUnicode(unicode);
            //Property(p => p.Category).HasMaxLength(255).IsUnicode(unicode);
            //Property(p => p.Description).HasMaxLength(255).IsUnicode(unicode);
            //Property(p => p.ExecutionId).HasMaxLength(255).IsUnicode(unicode);
            //Property(p => p.Name).HasMaxLength(255).IsUnicode(unicode);
            //Property(p => p.Owner).HasMaxLength(255).IsUnicode(unicode);
            Property(p => p.TenantId).HasMaxLength(255).IsUnicode(unicode);
            Property(p => p.CreatedBy).HasMaxLength(255).IsUnicode(unicode);
            Property(p => p.ModifiedBy).HasMaxLength(255).IsUnicode(unicode);

            // Table & Column Mappings
            ToTable(Config.Instance.Tables.ProcessTask);
            MapToStoredProcedures();
        }
    }
}
