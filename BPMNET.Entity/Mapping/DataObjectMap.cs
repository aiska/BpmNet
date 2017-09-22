using BPMNET.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace BPMNET.Entity.Mapping
{
    public class DataObjectMap : EntityTypeConfiguration<DataObject>
    {
        public DataObjectMap()
        {
            DatabaseGeneratedOption option = Config.Instance.GeneratedOption;
            bool unicode = Config.Instance.UnicodeString;

            // Primary Key
            HasKey(t => new { t.DataObjectId });

            // Properties
            Property(p => p.DataObjectId).HasDatabaseGeneratedOption(option);
            Property(p => p.Id).HasMaxLength(255).IsUnicode(unicode).IsRequired().HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_DATA_OBJECT_ID")));
            Property(p => p.Name).HasMaxLength(255).IsUnicode(unicode).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_DATA_OBJECT_NAME")));
            Property(p => p.ItemSubjectRef).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_DATA_OBJECT_ITEM_SUBJECT_REF")));

            // Table & Column Mappings
            ToTable(Config.Instance.Tables.DataObject);
            MapToStoredProcedures();
        }
    }
}
