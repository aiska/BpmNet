using BPMNET.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace BPMNET.Entity.Mapping
{
    public class ProcessInstanceMap : EntityTypeConfiguration<ProcessInstanceEntity>
    {
        public ProcessInstanceMap()
        {
            DatabaseGeneratedOption option = Config.Instance.GeneratedOption;
            bool unicode = Config.Instance.UnicodeString;

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(p => p.Id).HasDatabaseGeneratedOption(option);
            //Property(p => p.ProcessInstanceId).AddColumnIndex("IX_PROCESS_INSTANCE_ID", 0, false, false);
            //Property(p => p.ProcessInstanceId).HasMaxLength(255).IsFixedLength().IsUnicode(unicode);
            Property(p => p.TenantId).HasMaxLength(255).IsUnicode(unicode).AddColumnIndex("IX_PROCESS_INSTANCE_ID", 1);
            Property(p => p.BusinessKey).HasMaxLength(255).IsUnicode(unicode);
            Property(p => p.ProcessId).HasMaxLength(255).IsUnicode(unicode);
            Property(p => p.CreatedBy).HasMaxLength(255).IsUnicode(unicode);
            Property(p => p.ModifiedBy).HasMaxLength(255).IsUnicode(unicode);

            // Table & Column Mappings
            ToTable(Config.Instance.Tables.ProcessInstance);
            MapToStoredProcedures();
        }
    }
}
