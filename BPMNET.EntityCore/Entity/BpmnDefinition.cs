using System;
using System.Collections.Generic;

namespace BPMNET.EntityCore
{
    public class BpmnDefinition : IAuditTrail, IBaseElement
    {
        public BpmnDefinition()
        {
            Key = Guid.NewGuid();
            ItemDefinitions = new List<BpmnItemDefinition>();
        }
        public Guid Key { get; set; }
        public Guid DeploymentId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string DefinitionKey { get; set; }
        public string XmlData { get; set; }
        public string ProcessDefinitionDescription { get; set; }
        public string ProcessDefinitionResource { get; set; }
        public string ProcessDefinitionDiagramResourceName { get; set; }
        public bool ProcessDefinitionHasStartFormKey { get; set; }
        public bool ProcessDefinitionHasGraphicalNotation { get; set; }
        public bool IsSuspended { get; set; }
        public string TenantId { get; set; }
        public DateTime Inserted { get; set; }
        public DateTime LastUpdated { get; set; }
        public byte[] Timestamp { get; set; }

        public ICollection<BpmnItemDefinition> ItemDefinitions { get; set; }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = (Key != null) ? Key.GetHashCode() : 0;
                // Suitable nullity checks etc, of course :)
                hash = (DeploymentId != null) ? hash * 17 + DeploymentId.GetHashCode() : hash;
                hash = (Name != null) ? hash * 17 + Name.GetHashCode() : hash;
                hash = (DefinitionKey != null) ? hash * 17 + DefinitionKey.GetHashCode() : hash;
                hash = (ProcessDefinitionDescription != null) ? hash * 17 + ProcessDefinitionDescription.GetHashCode() : hash;
                hash = (ProcessDefinitionResource != null) ? hash * 17 + ProcessDefinitionResource.GetHashCode() : hash;
                hash = (ProcessDefinitionDiagramResourceName != null) ? hash * 17 + ProcessDefinitionDiagramResourceName.GetHashCode() : hash;
                hash = hash * 17 + ProcessDefinitionHasStartFormKey.GetHashCode();
                hash = hash * 17 + ProcessDefinitionHasGraphicalNotation.GetHashCode();
                hash = hash * 17 + IsSuspended.GetHashCode();
                hash = (TenantId != null) ? hash * 17 + TenantId.GetHashCode() : hash;
                return hash;
            }
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as BpmnDefinition);
        }
        public bool Equals(BpmnDefinition other)
        {
            // Check for null
            if (ReferenceEquals(other, null))
                return false;

            // Check for same reference
            if (ReferenceEquals(this, other))
                return true;

            // Not Check DeploymentId, because generated Guid

            // Check for same value
            return ((DeploymentId == null && other.DeploymentId == null) || (DeploymentId != null && other.DeploymentId != null && DeploymentId.Equals(other.DeploymentId))) &&
                ((Name == null && other.Name == null) || (Name != null && other.Name != null && Name.Equals(other.Name))) &&
                ((DefinitionKey == null && other.DefinitionKey == null) || (DefinitionKey != null && other.DefinitionKey != null && DefinitionKey.Equals(other.DefinitionKey))) &&
                ((ProcessDefinitionDescription == null && other.ProcessDefinitionDescription == null) || (ProcessDefinitionDescription != null && other.ProcessDefinitionDescription != null && ProcessDefinitionDescription.Equals(other.ProcessDefinitionDescription))) &&
                ((ProcessDefinitionDiagramResourceName == null && other.ProcessDefinitionDiagramResourceName == null) || (ProcessDefinitionDiagramResourceName != null && other.ProcessDefinitionDiagramResourceName != null && ProcessDefinitionDiagramResourceName.Equals(other.ProcessDefinitionDiagramResourceName))) &&
                (ProcessDefinitionHasStartFormKey.Equals(other.ProcessDefinitionHasStartFormKey)) &&
                (ProcessDefinitionHasGraphicalNotation.Equals(other.ProcessDefinitionHasGraphicalNotation)) &&
                (IsSuspended.Equals(other.IsSuspended)) &&
                ((TenantId == null && other.TenantId == null) || (TenantId != null && other.TenantId != null && TenantId.Equals(other.TenantId)));
        }
    }
}
