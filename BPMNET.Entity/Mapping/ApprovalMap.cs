using BPMNET.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BPMNET.Entity.Mapping
{
    public class ApprovalMap : EntityTypeConfiguration<Approval>
    {
        public ApprovalMap()
        {
            DatabaseGeneratedOption option = Config.Instance.GeneratedOption;
            bool unicode = Config.Instance.UnicodeString;

            // Primary Key
            HasKey(t => new { t.ApprovalId });

            // Properties
            Property(p => p.ApprovalId).HasDatabaseGeneratedOption(option);
            Property(p => p.Assignee).HasMaxLength(255).IsUnicode(unicode);
            Property(p => p.Group).HasMaxLength(255).IsUnicode(unicode);

            // Table & Column Mappings
            ToTable(Config.Instance.Tables.Approval);
            MapToStoredProcedures();
        }
    }
}
