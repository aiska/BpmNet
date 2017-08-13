
namespace BPMNET.Core
{
    interface IModel
    {

        long Id { get; set; }
        string Name { get; set; }
        string Key { get; set; }
        string Category { get; set; }
        string MetaInfo { get; set; }
        string DeploymentId { get; set; }
        string TenantId { get; set; }
        /// <summary>
        /// whether this model has editor source
        /// </summary>
        /// <returns></returns>
        bool HasEditorSource { get; set; }

        /// <summary>
        /// whether this model has editor source extra
        /// </summary>
        /// <returns></returns>
        bool HasEditorSourceExtra { get; set; }
    }
}
