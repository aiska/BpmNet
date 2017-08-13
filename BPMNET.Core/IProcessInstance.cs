namespace BPMNET.Core
{
    public interface IProcessInstance<TKey> : IProcessInstanceKey<TKey>
    {
        /// <summary>
        /// Returns the name of this process instance. 
        /// </summary>
        string Name { get; set; }

        TKey ProcessDefinitionId { get; set; }

        ///// <summary>
        ///// The process definition of the process instance.
        ///// </summary>
        string ProcessDefinitionName { get; set; }

        ///// <summary>
        ///// The processInstance Id of the process definition of the process instance.
        ///// </summary>
        //long deploymentId { get; set; }

        /// <summary>
        /// The business Key of this process instance.
        /// </summary>
        string BusinessKey { get; set; }
        /// <summary>
        /// The tenant identifier of this process instance
        /// </summary>
        string TenantId { get; set; }
        /// <summary>
        /// returns true if the process instance is suspended
        /// </summary>
        ESuspensionState SuspensionState { get; set; }

        string UserCandidates { get; set; }

        string Owner { get; set; }

        ///// <summary>
        ///// Returns the process variables if requested in the process instance query
        ///// </summary>
        //Dictionary<string, object> ProcessVariables { get; set; }
        //ICollection<TIdentityLinkEntity> IdentityLinks { get; set; }
    }
}
