using BPMNET.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BPMNET.Entity.Mapping
{
    public class ProcessFlowMap : EntityTypeConfiguration<ProcessFlowEntity>
    {
        public ProcessFlowMap()
        {
            DatabaseGeneratedOption option = Config.Instance.GeneratedOption;
            bool unicode = Config.Instance.UnicodeString;

            // Primary Key
            HasKey(t => new { t.ProcessFlowId });

            // Properties
            Property(p => p.ProcessFlowId).HasDatabaseGeneratedOption(option);

            // Table & Column Mappings
            ToTable(Config.Instance.Tables.ProcessFlow);
            MapToStoredProcedures();

        }
    }
}
