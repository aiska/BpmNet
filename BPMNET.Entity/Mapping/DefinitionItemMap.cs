using BPMNET.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace BPMNET.Entity.Mapping
{
    public class DefinitionItemMap : EntityTypeConfiguration<DefinitionItemEntity>
    {
        public DefinitionItemMap()
        {
            DatabaseGeneratedOption option = Config.Instance.GeneratedOption;
            bool unicode = Config.Instance.UnicodeString;

            // Primary Key
            HasKey(t => new { t.Id });

            // Properties
            Property(p => p.Id).HasDatabaseGeneratedOption(option);
            Property(p => p.DeploymentId).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_ITEM_DEFINITION_DEFINITION_ID")));
            Property(p => p.DefinitionItemId).IsRequired().HasMaxLength(255).IsUnicode(unicode).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_ITEM_DEFINITION_ID")));
            //Property(p => p.Incoming).HasMaxLength(255).IsUnicode(unicode);
            //Property(p => p.Outgoing).HasMaxLength(255).IsUnicode(unicode);
            Property(p => p.StructureRef).HasMaxLength(255).IsUnicode(unicode);
            //Property(p => p.SourceRef).HasMaxLength(255).IsUnicode(unicode);
            //Property(p => p.TargetRef).HasMaxLength(255).IsUnicode(unicode);
            //Property(p => p.CompletionQuantity).HasMaxLength(255).IsUnicode(unicode);
            //Property(p => p.StartQuantity).HasMaxLength(255).IsUnicode(unicode);
            //Property(p => p.Users).IsUnicode(unicode);
            //Property(p => p.Roles).IsUnicode(unicode);
            //Ignore(t => t.UserCandidates);
            //Ignore(t => t.RoleCandidates);

            // Table & Column Mappings
            ToTable(Config.Instance.Tables.DefinitionItem);
            MapToStoredProcedures();
        }
    }
}
