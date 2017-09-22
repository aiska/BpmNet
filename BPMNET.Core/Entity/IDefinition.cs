namespace BPMNET.Core
{
    public interface IDefinition<TKey>
    {
        /// <summary>
        /// The Deployment Id in which this process definition is contained.
        /// </summary>
        /// <returns></returns>
        TKey DefinitionId { get; set; }

        /// <summary>
        /// The Deployment Id in which this process definition is contained.
        /// </summary>
        /// <returns></returns>
        TKey DeploymentId { get; set; }

        /// <summary>
        /// label used for display purposes
        /// </summary>
        /// <returns></returns>
        string Name { get; set; }

        /// <summary>
        /// unique name for all versions this process definitions
        /// </summary>
        /// <returns></returns>
        string Id { get; set; }

        /// <summary>
        /// description of this process
        /// </summary>
        /// <returns></returns>
        string Description { get; set; }

        /// <summary>
        ///   json process info
        /// </summary>
        //string Resource { get; set; }

        /// <summary>
        /// The resource name in the processInstance of the diagram image (if any).
        /// </summary>
        /// <returns></returns>
        //string DiagramResourceName { get; set; }

        /// <summary>
        /// Does this process definition has a {@link FormService#getStartFormData(string) CreateProcessInstanceAsync form Key}.
        /// </summary>
        /// <returns></returns>
        //bool HasStartFormKey { get; set; }

        /// <summary>
        /// Does this process definition has a graphical notation defined (such that a diagram can be generated)?
        /// </summary>
        /// <returns></returns>
        //bool HasGraphicalNotation { get; set; }

        /// <summary>
        /// Returns true if the process definition is in suspended state.
        /// </summary>
        /// <returns></returns>
        //bool IsSuspended { get; set; }

        /// <summary>
        /// The tenant identifier of this process definition
        /// </summary>
        /// <returns></returns>
        //string TenantId { get; set; }
        //ICollection<TProcessItemDefinitionEntity> Items { get; set; }

        bool IsActive { get; set; }

    }
}
