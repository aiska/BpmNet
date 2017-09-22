using BPMNET.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace BPMNET.Entity.Mapping
{
    public class SequenceFlowMap : EntityTypeConfiguration<SequenceFlowEntity>
    {
        public SequenceFlowMap()
        {
            DatabaseGeneratedOption option = Config.Instance.GeneratedOption;
            bool unicode = Config.Instance.UnicodeString;

            // Primary Key
            HasKey(t => new { t.Id });

            // Properties
            Property(p => p.Id).HasDatabaseGeneratedOption(option);
            Property(p => p.SequenceFlowId).IsRequired().HasMaxLength(64).IsUnicode(unicode).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_SEQUENCE_FLOW_ID")));
            Property(p => p.SequenceFlowName).HasMaxLength(64).IsUnicode(unicode).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_SEQUENCE_FLOW_NAME")));
            Property(p => p.SourceRef).HasMaxLength(64).IsUnicode(unicode).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_SEQUENCE_SOURCE_REF")));
            Property(p => p.TargetRef).HasMaxLength(64).IsUnicode(unicode).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_SEQUENCE_TARGET_REF")));

            // Table & Column Mappings
            ToTable(Config.Instance.Tables.SequenceFlow);
            MapToStoredProcedures();
        }
    }
}
