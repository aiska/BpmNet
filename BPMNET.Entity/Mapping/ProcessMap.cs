using BPMNET.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace BPMNET.Entity.Mapping
{
    public class ProcessMap : EntityTypeConfiguration<ProcessDefinitionEntity>
    {
        public ProcessMap()
        {
            DatabaseGeneratedOption option = Config.Instance.GeneratedOption;
            bool unicode = Config.Instance.UnicodeString;

            // Primary Key
            HasKey(t => new { t.Id });

            // Properties
            Property(p => p.Id).HasDatabaseGeneratedOption(option);
            Property(p => p.DeploymentId).IsRequired().AddColumnIndex("IX_PROCESS_DEPLOYMENT_ID", 0);
            Property(p => p.ProcessId).IsRequired().HasMaxLength(255).IsUnicode(unicode).AddColumnIndex("IX_PROCESS_ID", 0);
            Property(p => p.ProcessName).HasMaxLength(255).IsUnicode(unicode).AddColumnIndex("IX_PROCESS_NAME", 0);
            //Property(p => p.IsActive).AddColumnIndex("IX_PROCESS_ID", 1).AddColumnIndex("IX_PROCESS_NAME", 1);
            Property(p => p.CreatedBy).HasMaxLength(255).IsUnicode(unicode);
            Property(p => p.ModifiedBy).HasMaxLength(255).IsUnicode(unicode);

            // Table & Column Mappings
            ToTable(Config.Instance.Tables.BpmnProcess);
            MapToStoredProcedures();
        }
    }
}
