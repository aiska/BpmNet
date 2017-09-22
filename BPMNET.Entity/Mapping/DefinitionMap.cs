using BPMNET.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace BPMNET.Entity.Mapping
{
    public class DefinitionMap : EntityTypeConfiguration<DefinitionEntity>
    {
        public DefinitionMap()
        {
            DatabaseGeneratedOption option = Config.Instance.GeneratedOption;
            bool unicode = Config.Instance.UnicodeString;

            // Primary Key
            HasKey(t => new { t.DefinitionId });

            // Properties
            Property(p => p.DefinitionId).HasDatabaseGeneratedOption(option);
            Property(p => p.DeploymentId).AddColumnIndex("IX_DEFINITION_DEPLOYMENT_ID",0);
            Property(p => p.Id).HasMaxLength(255).IsRequired().IsUnicode(unicode).AddColumnIndex("IX_DEFINITION_ID", 0) ;
            Property(p => p.Name).HasMaxLength(255).IsUnicode(unicode).AddColumnIndex("IX_DEFINITION_NAME",0);
            //Property(p => p.DiagramResourceName).HasMaxLength(255).IsUnicode(unicode);
            Property(p => p.Name).HasMaxLength(255).IsUnicode(unicode);
            Property(p => p.Description).IsUnicode(unicode);
            //Property(p => p.Resource).HasMaxLength(255).IsUnicode(unicode);
            //Property(p => p.TenantId).HasMaxLength(255).IsUnicode(unicode);
            Property(p => p.Exporter).HasMaxLength(255).IsUnicode(unicode);
            Property(p => p.ExporterVersion).HasMaxLength(255).IsUnicode(unicode);
            Property(p => p.ExpressionLanguage).HasMaxLength(255).IsUnicode(unicode);
            Property(p => p.TypeLanguage).HasMaxLength(255).IsUnicode(unicode);
            Property(p => p.TargetNamespace).HasMaxLength(255).IsUnicode(unicode);
            Property(p => p.CreatedBy).HasMaxLength(255).IsUnicode(unicode);
            Property(p => p.ModifiedBy).HasMaxLength(255).IsUnicode(unicode);

            // Table & Column Mappings
            ToTable(Config.Instance.Tables.Definition);
            MapToStoredProcedures();
        }
    }
}
