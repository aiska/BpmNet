using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace BPMNET.Entity.Mapping
{
    internal static class ModelBuilderExtensions
    {
        public static StringPropertyConfiguration AddColumnIndex(this StringPropertyConfiguration config, string indexName, int columnOrder, bool unique = false, bool clustered = false)
        {
            var indexAttribute = new IndexAttribute(indexName, columnOrder) { IsUnique = unique, IsClustered = clustered };
            var indexAnnotation = new IndexAnnotation(indexAttribute);

            return config.HasColumnAnnotation(IndexAnnotation.AnnotationName, indexAnnotation);
        }

        public static PrimitivePropertyConfiguration AddColumnIndex(this PrimitivePropertyConfiguration property, string indexName, int columnOrder, bool unique = false, bool clustered = false)
        {
            var indexAttribute = new IndexAttribute(indexName, columnOrder) { IsUnique = unique, IsClustered = clustered };
            var indexAnnotation = new IndexAnnotation(indexAttribute);

            return property.HasColumnAnnotation(IndexAnnotation.AnnotationName, indexAnnotation);
        }
    }
}
