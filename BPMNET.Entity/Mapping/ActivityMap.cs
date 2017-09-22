using BPMNET.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace BPMNET.Entity.Mapping
{
    public class ActivityMap : EntityTypeConfiguration<Activity>
    {
        public ActivityMap()
        {
            DatabaseGeneratedOption option = Config.Instance.GeneratedOption;
            bool unicode = Config.Instance.UnicodeString;

            // Primary Key
            HasKey(t => new { t.ActivityId });

            // Properties
            Property(p => p.ActivityId).HasDatabaseGeneratedOption(option);
            Property(p => p.ProcessInstanceId).AddColumnIndex("IX_ACTIVITY_PROCESS_INSTANCE", 0);
            Property(p => p.Id).HasMaxLength(255).IsUnicode(unicode).AddColumnIndex("IX_ACTIVITY_ID", 0);

            // Table & Column Mappings
            ToTable(Config.Instance.Tables.Activity);
            MapToStoredProcedures();
        }
    }
}
