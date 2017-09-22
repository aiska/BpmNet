using BPMNET.Core;
using System;

namespace BPMNET.Entity
{
    public class DefinitionEntity : IDefinition<int>, IAuditTrail
    {
        public DefinitionEntity()
        {
            IsActive = true;
            UtcCreatedDate = DateTime.Now;
        }
        public int DefinitionId { get; set; }
        public int DeploymentId { get; set; }
        public string Description { get; set; }
        //public string DiagramResourceName { get; set; }
        //public bool HasGraphicalNotation { get; set; }
        //public bool HasStartFormKey { get; set; }
        //public bool IsSuspended { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        //public string Resource { get; set; }
        //public string TenantId { get; set; }
        public bool IsActive { get; set; }
        public string Exporter { get; set; }
        public string ExporterVersion { get; set; }
        public string ExpressionLanguage { get; set; }
        public string TypeLanguage { get; set; }
        public string TargetNamespace { get; set; }
        public DateTime UtcCreatedDate { get; set; }
        public DateTime? UtcModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        //public override int GetHashCode()
        //{
        //    unchecked // Overflow is fine, just wrap
        //    {
        //        int hash = DefinitionId.GetHashCode();
        //        // Suitable nullity checks etc, of course :)
        //        hash = hash * 17 + UtcCreatedDate.GetHashCode();
        //        hash = hash * 17 + DeploymentId.GetHashCode();
        //        hash = hash * 17 + IsActive.GetHashCode();
        //        hash = (Description != null) ? hash * 17 + Description.GetHashCode() : hash;
        //        //hash = (DiagramResourceName != null) ? hash * 17 + DiagramResourceName.GetHashCode() : hash;
        //        hash = (Id != null) ? hash * 17 + Id.GetHashCode() : hash;
        //        hash = (Name != null) ? hash * 17 + Name.GetHashCode() : hash;
        //        //hash = (Resource != null) ? hash * 17 + Resource.GetHashCode() : hash;
        //        //hash = (TenantId != null) ? hash * 17 + TenantId.GetHashCode() : hash;
        //        hash = (Exporter != null) ? hash * 17 + Exporter.GetHashCode() : hash;
        //        hash = (ExporterVersion != null) ? hash * 17 + ExporterVersion.GetHashCode() : hash;
        //        hash = (ExpressionLanguage != null) ? hash * 17 + ExpressionLanguage.GetHashCode() : hash;
        //        hash = (TypeLanguage != null) ? hash * 17 + TypeLanguage.GetHashCode() : hash;
        //        hash = (TargetNamespace != null) ? hash * 17 + TargetNamespace.GetHashCode() : hash;
        //        //hash = hash * 17 + HasGraphicalNotation.GetHashCode();
        //        //hash = hash * 17 + HasStartFormKey.GetHashCode();
        //        //hash = hash * 17 + IsSuspended.GetHashCode();
        //        hash = hash * 17 + UtcCreatedDate.GetHashCode();
        //        hash = (UtcModifiedDate != null) ? hash * 17 + UtcModifiedDate.GetHashCode() : hash;
        //        return hash;
        //    }
        //}
        //public override bool Equals(object obj)
        //{
        //    return Equals(obj as Definition);
        //}
        //public bool Equals(Definition other)
        //{
        //    // Check for null
        //    if (ReferenceEquals(other, null))
        //        return false;

        //    // Check for same reference
        //    if (ReferenceEquals(this, other))
        //        return true;

        //    // Check for same value
        //    return DeploymentId.Equals(other.DeploymentId) &&
        //        ((Description == null && other.Description == null) || (Description != null && other.Description != null && Description.Equals(other.Description))) &&
        //        //((DiagramResourceName == null && other.DiagramResourceName == null) || (DiagramResourceName != null && other.DiagramResourceName != null && DiagramResourceName.Equals(other.DiagramResourceName))) &&
        //        //HasGraphicalNotation == other.HasGraphicalNotation &&
        //        IsActive == other.IsActive &&
        //        ((Id == null && other.Id == null) || (Id != null && other.Id != null && Id.Equals(other.Id))) &&
        //        ((Name == null && other.Name == null) || (Name != null && other.Name != null && Name.Equals(other.Name))) &&
        //        //((Resource == null && other.Resource == null) || (Resource != null && other.Resource != null && Resource.Equals(other.Resource))) &&
        //        //((TenantId == null && other.TenantId == null) || (TenantId != null && other.TenantId != null && TenantId.Equals(other.TenantId))) &&
        //        ((Exporter == null && other.Exporter == null) || (Exporter != null && other.Exporter != null && Exporter.Equals(other.Exporter))) &&
        //        ((ExporterVersion == null && other.ExporterVersion == null) || (ExporterVersion != null && other.ExporterVersion != null && ExporterVersion.Equals(other.ExporterVersion))) &&
        //        ((ExpressionLanguage == null && other.ExpressionLanguage == null) || (ExpressionLanguage != null && other.ExpressionLanguage != null && ExpressionLanguage.Equals(other.ExpressionLanguage))) &&
        //        ((TypeLanguage == null && other.TypeLanguage == null) || (TypeLanguage != null && other.TypeLanguage != null && TypeLanguage.Equals(other.TypeLanguage))) &&
        //        //HasStartFormKey == other.HasStartFormKey &&
        //        //IsSuspended == other.IsSuspended &&
        //        ((TargetNamespace == null && other.TargetNamespace == null) || (TargetNamespace != null && other.TargetNamespace != null && TargetNamespace.Equals(other.TargetNamespace)));
        //}
    }
}
