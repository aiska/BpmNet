using BPMNET.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace BPMNET.Entity.Mapping
{
    public class ProcessVariablesMap : EntityTypeConfiguration<ProcessVariableEntity>
    {
        public ProcessVariablesMap()
        {
            DatabaseGeneratedOption option = Config.Instance.GeneratedOption;
            bool unicode = Config.Instance.UnicodeString;

            // Primary Key
            HasKey(t => new { t.ProcessVariablesId });

            // Properties
            Property(p => p.ProcessVariablesId).HasDatabaseGeneratedOption(option);
            Property(p => p.ProcessInstanceId).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_PROCESS_VARIABLE_INSTANCE_ID")));

            // Table & Column Mappings
            ToTable(Config.Instance.Tables.ProcessVariables);
            MapToStoredProcedures();

        }
    }
}
