using BPMNET.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace BPMNET.Entity.Mapping
{
    public class DeploymentMap : EntityTypeConfiguration<DeploymentEntity>
    {
        public DeploymentMap()
        {
            DatabaseGeneratedOption option = Config.Instance.GeneratedOption;
            bool unicode = Config.Instance.UnicodeString;

            // Primary Key
            HasKey(t => new { t.Id });

            // Properties
            Property(p => p.Id).HasDatabaseGeneratedOption(option);
            Property(p => p.DeploymentId).HasMaxLength(64).IsRequired().IsUnicode(unicode).AddColumnIndex("IX_DEPLOYMENT_ID", 0);
            Property(p => p.DeploymentName).HasMaxLength(64).IsRequired().IsUnicode(unicode).AddColumnIndex("IX_DEPLOYMENT_NAME_CATEGORY_TENANT", 0);
            //Property(p => p.Category).IsRequired().HasMaxLength(255).IsUnicode(unicode).AddColumnIndex("IX_DEPLOYMENT_NAME_CATEGORY_TENANT", 1);
            Property(p => p.TenantId).HasMaxLength(64).IsUnicode(unicode).AddColumnIndex("IX_DEPLOYMENT_NAME_CATEGORY_TENANT",1);
            Property(p => p.CreatedBy).HasMaxLength(64).IsUnicode(unicode);
            Property(p => p.ModifiedBy).HasMaxLength(64).IsUnicode(unicode);

            // Table & Column Mappings
            ToTable(Config.Instance.Tables.Deployment);
            MapToStoredProcedures();
        }
    }
}
