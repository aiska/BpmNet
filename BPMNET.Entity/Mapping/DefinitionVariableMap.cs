using BPMNET.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace BPMNET.Entity.Mapping
{
    public class DefinitionVariableMap : EntityTypeConfiguration<DefinitionVariable>
    {
        public DefinitionVariableMap()
        {
            DatabaseGeneratedOption option = Config.Instance.GeneratedOption;
            bool unicode = Config.Instance.UnicodeString;

            // Primary Key
            HasKey(t => new { t.DefinitionVariableId });

            // Properties
            Property(p => p.DefinitionVariableId).HasDatabaseGeneratedOption(option);
            Property(p => p.DefinitionId).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_DEFINITION_VARIABLE_DEFINITION_ID")));
            Property(p => p.VariableName).HasMaxLength(255).IsRequired().IsUnicode(unicode).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_DEFINITION_VARIABLE_NAME")));

            // Table & Column Mappings
            ToTable(Config.Instance.Tables.DefinitionVariable);
            MapToStoredProcedures();
        }
    }
}
