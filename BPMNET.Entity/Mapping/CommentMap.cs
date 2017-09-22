using BPMNET.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BPMNET.Entity.Mapping
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            DatabaseGeneratedOption option = Config.Instance.GeneratedOption;
            bool unicode = Config.Instance.UnicodeString;

            // Primary Key
            HasKey(t => new { t.CommentId });

            // Properties
            Property(p => p.CommentId).HasDatabaseGeneratedOption(option);
            Property(p => p.User).HasMaxLength(255).IsUnicode(unicode);

            // Table & Column Mappings
            ToTable(Config.Instance.Tables.Comment);
            MapToStoredProcedures();
        }
    }
}
