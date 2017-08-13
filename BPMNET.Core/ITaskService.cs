
using System;
using System.Collections.Generic;
using System.IO;
namespace BPMNET.Core
{
    /// <summary>
    /// https://github.com/Activiti/Activiti/blob/master/modules/activiti-engine/src/main/java/org/activiti/engine/TaskService.java
    /// Service which provides access to {@link Task} and form related operations.
    /// </summary>
    /// <typeparam name="TProcessTask"></typeparam>
    /// <typeparam name="TIdentityLink"></typeparam>
    public interface ITaskService<TKey, TProcessTask, TIdentityLink, TVariableInstance, TComment, TProcessEvent, TAttachment>
        where TProcessTask : IProcessTask<TKey>
        where TIdentityLink : IIdentityLink<TKey>
        where TVariableInstance : IVariableInstance
        where TComment : IComment<TKey>
        where TProcessEvent : IProcessEvent
        where TAttachment : IAttachment<TKey>
    {
        /// <summary>
        /// Creates a new task that is not related to any process instance.
        /// The returned task is transient and must be saved with <see cref="saveTask"/> 'manually'.
        /// </summary>
        /// <returns></returns>
        TProcessTask NewTask();

        /// <summary>
        /// create a new task with a user defined task id
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        TProcessTask NewTask(string taskId);

        /// <summary>
        /// Saves the given task to the persistent data store. If the task is already
        /// present in the persistent store, it is updated.
        /// After a new task has been saved, the task instance passed into this method
        /// is updated with the id of the newly created task.
        /// </summary>
        /// <param name="task"></param>
        void SaveTask(TProcessTask task);

        /// <summary>
        /// Deletes the given task, not deleting historic information that is related to this task.
        /// @param taskId The id of the task that will be deleted, cannot be null. If no task
        /// exists with the given taskId, the operation is ignored.
        /// @throws ActivitiObjectNotFoundException when the task with given id does not exist.
        /// @throws ActivitiException when an error occurs while deleting the task or in case the task is part
        /// </summary>
        /// <param name="taskId"></param>
        void DeleteTask(string taskId);

        /// <summary>
        /// Deletes all tasks of the given collection, not deleting historic information that is related 
        /// to these tasks.
        /// <paramref name="taskIds"/> The id's of the tasks that will be deleted, cannot be null. All
        /// id's in the list that don't have an existing task will be ignored.
        /// @throws ActivitiObjectNotFoundException when one of the task does not exist.
        /// @throws ActivitiException when an error occurs while deleting the tasks or in case one of the tasks
        /// </summary>
        /// <param name="taskIds"></param>
        void DeleteTask(ICollection<string> taskIds);

        /// <summary>
        /// Deletes the given task.
        /// @param taskId The id of the task that will be deleted, cannot be null. If no task
        /// exists with the given taskId, the operation is ignored.
        /// @param cascade If cascade is true, also the historic information related to this task is deleted.
        /// @throws ActivitiObjectNotFoundException when the task with given id does not exist.
        /// @throws ActivitiException when an error occurs while deleting the task or in case the task is part
        /// of a running process.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="cascade"></param>
        void DeleteTask(string taskId, bool cascade);

        /// <summary>
        /// Deletes all tasks of the given collection.
        /// @param taskIds The id's of the tasks that will be deleted, cannot be null. All
        /// id's in the list that don't have an existing task will be ignored.
        /// @param cascade If cascade is true, also the historic information related to this task is deleted.
        /// @throws ActivitiObjectNotFoundException when one of the tasks does not exist.
        /// @throws ActivitiException when an error occurs while deleting the tasks or in case one of the tasks
        /// is part of a running process.
        /// </summary>
        /// <param name="taskIds"></param>
        /// <param name="cascade"></param>
        void DeleteTask(ICollection<string> taskIds, bool cascade);

        /// <summary>
        /// Deletes the given task, not deleting historic information that is related to this task..
        /// @param taskId The id of the task that will be deleted, cannot be null. If no task
        /// exists with the given taskId, the operation is ignored.
        /// @param deleteReason reason the task is deleted. Is recorded in history, if enabled.
        /// @throws ActivitiObjectNotFoundException when the task with given id does not exist.
        /// @throws ActivitiException when an error occurs while deleting the task or in case the task is part
        /// of a running process
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="deleteReason"></param>
        void DeleteTask(string taskId, string deleteReason);

        /// <summary>
        /// Deletes all tasks of the given collection, not deleting historic information that is related to these tasks.
        /// @throws ActivitiObjectNotFoundException when one of the tasks does not exist.
        /// @throws ActivitiException when an error occurs while deleting the tasks or in case one of the tasks
        /// </summary>
        /// <param name="taskIds">
        /// The id's of the tasks that will be deleted, cannot be null. All
        /// id's in the list that don't have an existing task will be ignored.
        /// </param>
        /// <param name="deleteReason">reason the task is deleted. Is recorded in history, if enabled.</param>
        void DeleteTask(ICollection<string> taskIds, string deleteReason);

        /// <summary>
        /// Claim responsibility for a task: the given user is made assignee for the task.
        /// The difference with {@link #setAssignee(string, string)} is that here 
        /// a check is done if the task already has a user assigned to it.
        /// No check is done whether the user is known by the identity component.
        /// @throws ActivitiObjectNotFoundException when the task doesn't exist.
        /// @throws ActivitiTaskAlreadyClaimedException when the task is already claimed by another user.
        /// </summary>
        /// <param name="taskId">task to claim, cannot be null.</param>
        /// <param name="userId">user that claims the task. When userId is null the task is unclaimed,
        /// assigned to no one.
        /// </param>
        void ClaimTask(string taskId, string userId);

        /// <summary>
        /// A shortcut to {@link #claim} with null user in order to unclaim the task
        /// @throws ActivitiObjectNotFoundException when the task doesn't exist. 
        /// </summary>
        /// <param name="taskId">task to unclaim, cannot be null.</param>
        void Unclaim(string taskId);

        /// <summary>
        /// Called when the task is successfully executed.
        /// @param taskId the id of the task to complete, cannot be null.
        /// @throws ActivitiObjectNotFoundException when no task exists with the given id.
        /// @throws ActivitiException when this task is {@link DelegationState#PENDING} delegation.
        /// </summary>
        /// <param name="taskId"></param>
        void Complete(string taskId);

        /// <summary>
        /// Delegates the task to another user. This means that the assignee is set 
        /// and the delegation state is set to <see cref="DelegationState"/> {@link DelegationState#PENDING}.
        /// If no owner is set on the task, the owner is set to the current assignee
        /// of the task.
        /// @throws ActivitiObjectNotFoundException when no task exists with the given id.
        /// </summary>
        /// <param name="taskId">The id of the task that will be delegated.</param>
        /// <param name="userId">The id of the user that will be set as assignee.</param>
        void DelegateTask(string taskId, string userId);

        /// <summary>
        /// Marks that the assignee is done with this task and that it can be send back to the owner.  
        /// Can only be called when this task is {@link DelegationState#PENDING} delegation.
        /// After this method returns, the {@link Task#getDelegationState() delegationState} is set to {@link DelegationState#RESOLVED}.
        /// @param taskId the id of the task to resolve, cannot be null.
        /// @throws ActivitiObjectNotFoundException when no task exists with the given id.
        /// </summary>
        /// <param name="taskId"></param>
        void ResolveTask(string taskId);

        /// <summary>
        /// Marks that the assignee is done with this task providing the required
        /// variables and that it can be sent back to the owner. Can only be called
        /// when this task is {@link DelegationState#PENDING} delegation. After this
        /// method returns, the {@link Task#getDelegationState() delegationState} is
        /// set to {@link DelegationState#RESOLVED}.
        /// @throws ProcessEngineException When no task exists with the given id.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="variables"></param>
        void ResolveTask(string taskId, Dictionary<string, object> variables);

        /// <summary>
        /// Called when the task is successfully executed, 
        /// and the required task parameters are given by the end-user.
        /// @throws ActivitiObjectNotFoundException when no task exists with the given id.
        /// </summary>
        /// <param name="taskId">the id of the task to complete, cannot be null.</param>
        /// <param name="variables">task parameters. May be null or empty.</param>
        void Complete(string taskId, Dictionary<string, object> variables);

        /// <summary>
        /// Called when the task is successfully executed, 
        /// and the required task paramaters are given by the end-user.
        /// @throws ActivitiObjectNotFoundException when no task exists with the given id.
        /// </summary>
        /// <param name="taskId">the id of the task to complete, cannot be null.</param>
        /// <param name="variables">task parameters. May be null or empty.</param>
        /// <param name="localScope">If true, the provided variables will be stored task-local, 
        /// instead of process instance wide (which is the default for {@link #complete(string, Map)}).
        /// </param>
        void Complete(string taskId, Dictionary<string, object> variables, bool localScope);

        /// <summary>
        /// Changes the assignee of the given task to the given userId.
        /// No check is done whether the user is known by the identity component.
        /// @param taskId id of the task, cannot be null.
        /// @param userId id of the user to use as assignee.
        /// @throws ActivitiObjectNotFoundException when the task or user doesn't exist.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="userId"></param>
        void setAssignee(string taskId, string userId);

        /// <summary>
        /// Transfers ownership of this task to another user.
        /// No check is done whether the user is known by the identity component.
        /// @param taskId id of the task, cannot be null.
        /// @param userId of the person that is receiving ownership.
        /// @throws ActivitiObjectNotFoundException when the task or user doesn't exist.
        /// </summary>
        /// <param name="taskId">id of the task, cannot be null.</param>
        /// <param name="userId">userId of the person that is receiving ownership.</param>
        void setOwner(string taskId, string userId);

        /// <summary>
        /// Retrieves the {@link IdentityLink}s associated with the given task.
        /// Such an {@link IdentityLink} informs how a certain identity (eg. group or user)
        /// is associated with a certain task (eg. as candidate, assignee, etc.)
        /// </summary>
        /// <param name="taskId">id of the task, cannot be null.</param>
        /// <returns></returns>
        ICollection<TIdentityLink> GetIdentityLinksForTask(string taskId);

        /// <summary>
        /// Convenience shorthand for {@link #addUserIdentityLink(string, string, string)}; with type {@link IdentityLinkType#CANDIDATE}
        /// @throws ActivitiObjectNotFoundException when the task or user doesn't exist.
        /// </summary>
        /// <param name="taskId">id of the task, cannot be null.</param>
        /// <param name="userId">id of the user to use as candidate, cannot be null.</param>
        /// <returns></returns>
        void AddCandidateUser(string taskId, string userId);

        /// <summary>
        /// Convenience shorthand for {@link #addGroupIdentityLink(string, string, string)}; with type {@link IdentityLinkType#CANDIDATE}
        /// @throws ActivitiObjectNotFoundException when the task or group doesn't exist.
        /// </summary>
        /// <param name="taskId">id of the task, cannot be null.</param>
        /// <param name="groupId">id of the group to use as candidate, cannot be null.</param>
        void AddCandidateGroup(string taskId, string groupId);

        /// <summary>
        /// Involves a user with a task. The type of identity link is defined by the
        /// given identityLinkType.
        /// @throws ActivitiObjectNotFoundException when the task or user doesn't exist.
        /// </summary>
        /// <param name="taskId">id of the task, cannot be null.</param>
        /// <param name="userId">userId id of the user involve, cannot be null.</param>
        /// <param name="identityLinkType">type of identityLink, cannot be null (@see {@link IdentityLinkType}).</param>
        void AddUserIdentityLink(string taskId, string userId, EIdentityLinkType identityLinkType);

        /// <summary>
        /// Involves a group with a task. The type of identityLink is defined by the
        /// given identityLink.
        /// @param taskId id of the task, cannot be null.
        /// @param groupId id of the group to involve, cannot be null.
        /// @param identityLinkType type of identity, cannot be null (@see {@link IdentityLinkType}).
        /// @throws ActivitiObjectNotFoundException when the task or group doesn't exist.
        /// </summary>
        /// <param name="taskId">id of the task, cannot be null.</param>
        /// <param name="groupId">id of the group to involve, cannot be null.</param>
        /// <param name="identityLinkType">type of identity, cannot be null <see cref="EIdentityLinkType"/>.</param>
        void AddGroupIdentityLink(string taskId, string groupId, EIdentityLinkType identityLinkType);

        /// <summary>
        /// Convenience shorthand for {@link #deleteUserIdentityLink(string, string, string)}; with type {@link IdentityLinkType#CANDIDATE}
        /// @param taskId id of the task, cannot be null.
        /// @param userId id of the user to use as candidate, cannot be null.
        /// @throws ActivitiObjectNotFoundException when the task or user doesn't exist.
        /// </summary>
        /// <param name="taskId">id of the task, cannot be null.</param>
        /// <param name="userId">userId id of the user to use as candidate, cannot be null.</param>
        void DeleteCandidateUser(string taskId, string userId);

        /// <summary>
        /// Convenience shorthand for {@link #deleteGroupIdentityLink(string, string, string)}; with type {@link IdentityLinkType#CANDIDATE}
        /// @throws ActivitiObjectNotFoundException when the task or group doesn't exist.
        /// </summary>
        /// <param name="taskId">id of the task, cannot be null.</param>
        /// <param name="groupId">id of the group to use as candidate, cannot be null.</param>
        void DeleteCandidateGroup(string taskId, string groupId);

        /// <summary>
        /// Removes the association between a user and a task for the given identityLinkType.
        /// @throws ActivitiObjectNotFoundException when the task or user doesn't exist.
        /// </summary>
        /// <param name="taskId">id of the task, cannot be null.</param>
        /// <param name="userId">id of the user involve, cannot be null.</param>
        /// <param name="identityLinkType">type of identityLink, cannot be null (@see {@link IdentityLinkType}).</param>
        void DeleteUserIdentityLink(string taskId, string userId, EIdentityLinkType identityLinkType);

        /// <summary>
        /// Removes the association between a group and a task for the given identityLinkType.
        /// @throws ActivitiObjectNotFoundException when the task or group doesn't exist.
        /// </summary>
        /// <param name="taskId">id of the task, cannot be null.</param>
        /// <param name="groupId">the group to involve, cannot be null.</param>
        /// <param name="identityLinkType">type of identity, cannot be null (@see {@link IdentityLinkType}).</param>
        void deleteGroupIdentityLink(string taskId, string groupId, EIdentityLinkType identityLinkType);

        /// <summary>
        /// Changes the priority of the task.
        /// Authorization: actual owner / business admin
        /// @param taskId id of the task, cannot be null.
        /// @param priority the new priority for the task.
        /// @throws ActivitiObjectNotFoundException when the task doesn't exist.
        /// </summary>
        /// <param name="taskId">id of the task, cannot be null.</param>
        /// <param name="priority">priority the new priority for the task.</param>
        void setPriority(string taskId, int priority);

        /// <summary>
        ///  Changes the due date of the task
        ///  @param taskId id of the task, cannot be null.
        ///  @param dueDate the new due date for the task
        ///  @throws ActivitiException when the task doesn't exist.
        /// </summary>
        /// <param name="taskId">id of the task, cannot be null.</param>
        /// <param name="dueDate">the new due date for the task</param>
        void setDueDate(string taskId, DateTime dueDate);

        /// <summary>
        /// set variable on a task.  If the variable is not already existing, it will be created in the 
        /// most outer scope.  This means the process instance in case this task is related to an 
        /// execution.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="variableName"></param>
        /// <param name="value"></param>
        void setVariable(string taskId, string variableName, object value);

        /// <summary>
        /// set variables on a task.  If the variable is not already existing, it will be created in the 
        /// most outer scope.  This means the process instance in case this task is related to an 
        /// execution.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="variables"></param>
        void setVariables(string taskId, Dictionary<string, object> variables);

        /// <summary>
        /// set variable on a task.  If the variable is not already existing, it will be created in the task.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="variableName"></param>
        /// <param name="value"></param>
        void setVariableLocal(string taskId, string variableName, object value);

        /// <summary>
        /// set variables on a task.  If the variable is not already existing, it will be created in the task.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="variables"></param>
        void setVariablesLocal(string taskId, Dictionary<string, object> variables);

        /// <summary>
        /// get a variables and search in the task scope and if available also the execution scopes.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="variableName"></param>
        /// <returns></returns>
        object getVariable(string taskId, string variableName);

        /// <summary>
        /// get a variables and search in the task scope and if available also the execution scopes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="taskId"></param>
        /// <param name="variableName"></param>
        /// <returns></returns>
        T getVariable<T>(string taskId, string variableName);

        /// <summary>
        /// checks whether or not the task has a variable defined with the given name, in the task scope and if available also the execution scopes.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="variableName"></param>
        /// <returns></returns>
        bool hasVariable(string taskId, string variableName);

        /// <summary>
        /// checks whether or not the task has a variable defined with the given name.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="variableName"></param>
        /// <returns></returns>
        object getVariableLocal(string taskId, string variableName);

        /// <summary>
        /// checks whether or not the task has a variable defined with the given name, local task scope only.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="variableName"></param>
        /// <returns></returns>
        bool hasVariableLocal(string taskId, string variableName);

        /// <summary>
        /// get all variables and search in the task scope and if available also the execution scopes. 
        /// If you have many variables and you only need a few, consider using {@link #getVariables(string, Collection)} 
        /// for better performance.
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        Dictionary<string, object> getVariables(string taskId);

        /// <summary>
        /// get all variables and search only in the task scope.
        /// If you have many task local variables and you only need a few, consider using {@link #getVariablesLocal(string, Collection)} 
        /// for better performance.
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        Dictionary<string, object> getVariablesLocal(string taskId);

        /// <summary>
        /// get values for all given variableNames and search only in the task scope.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="variableNames"></param>
        /// <returns></returns>
        Dictionary<string, object> getVariables(string taskId, ICollection<string> variableNames);

        /// <summary>
        /// get a variable on a task 
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="variableNames"></param>
        /// <returns></returns>
        Dictionary<string, object> getVariablesLocal(string taskId, ICollection<string> variableNames);

        /// <summary>
        /// get all variables and search only in the task scope.
        /// </summary>
        /// <param name="taskIds"></param>
        /// <returns></returns>
        List<TVariableInstance> getVariableInstancesLocalByTaskIds(ICollection<string> taskIds);

        /// <summary>
        ///  Removes the variable from the task.
        ///  When the variable does not exist, nothing happens.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="variableName"></param>
        void removeVariable(string taskId, string variableName);

        /// <summary>
        /// Removes the variable from the task (not considering parent scopes).
        /// When the variable does not exist, nothing happens.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="variableName"></param>
        void removeVariableLocal(string taskId, string variableName);

        /// <summary>
        /// Removes all variables in the given collection from the task.
        /// Non existing variable names are simply ignored.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="variableNames"></param>
        void removeVariables(string taskId, ICollection<string> variableNames);

        /// <summary>
        /// Removes all variables in the given collection from the task (not considering parent scopes).
        /// Non existing variable names are simply ignored.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="variableNames"></param>
        void removeVariablesLocal(string taskId, ICollection<string> variableNames);

        /// <summary>
        /// Add a comment to a task and/or process instance.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="processInstanceId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        TComment addComment(string taskId, string processInstanceId, string message);

        /// <summary>
        /// Add a comment to a task and/or process instance with a custom type.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="processInstanceId"></param>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        TComment addComment(string taskId, string processInstanceId, string type, string message);

        /// <summary>
        /// Returns an individual comment with the given id. Returns null if no comment exists with the given id.
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        TComment getComment(string commentId);

        /// <summary>
        /// Removes all comments from the provided task
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="processInstanceId"></param>
        void deleteTaskComments(string taskId);

        /// <summary>
        /// Removes all comments from the provided process instance
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="processInstanceId"></param>
        void deleteProcessInstanceComments(string processInstanceId);

        /// <summary>
        /// Removes an individual comment with the given id.
        /// @throws ActivitiObjectNotFoundException when no comment exists with the given id. 
        /// </summary>
        /// <param name="commentId"></param>
        void deleteComment(string commentId);

        /// <summary>
        /// The comments related to the given task.
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        ICollection<TComment> getTaskComments(string taskId);

        /// <summary>
        /// The comments related to the given task of the given type.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        ICollection<TComment> getTaskComments(string taskId, string type);

        /// <summary>
        /// All comments of a given type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        ICollection<TComment> getCommentsByType(string type);

        /// <summary>
        /// The comments related to the given process instance.
        /// </summary>
        /// <param name="processInstanceId"></param>
        /// <returns></returns>
        ICollection<TComment> getProcessInstanceComments(string processInstanceId);

        ICollection<TProcessEvent> getTaskEvents(string taskId);

        TProcessEvent getEvent(string eventId);

        /** Add a new attachment to a task and/or a process instance and use an input stream to provide the content */
        TAttachment createAttachment(string attachmentType, string taskId, string processInstanceId, string attachmentName, string attachmentDescription, Stream content);

        /** Add a new attachment to a task and/or a process instance and use an url as the content */
        TAttachment createAttachment(string attachmentType, string taskId, string processInstanceId, string attachmentName, string attachmentDescription, string url);

        /** Update the name and decription of an attachment */
        void saveAttachment(TAttachment attachment);

        /** Retrieve a particular attachment */
        TAttachment getAttachment(string attachmentId);

        /** Retrieve stream content of a particular attachment */
        Stream getAttachmentContent(string attachmentId);

        /** The list of attachments associated to a task */
        List<TAttachment> getTaskAttachments(string taskId);

        /** The list of attachments associated to a process instance */
        List<TAttachment> getProcessInstanceAttachments(string processInstanceId);

        /** Delete an attachment */
        void deleteAttachment(string attachmentId);

        /** The list of subtasks for this parent task */
        List<TProcessTask> getSubTasks(string parentTaskId);
    }
}
