
using BPMNET.Bpmn;
using BPMNET.Exception;
using Ciloci.Flee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BPMNET.EntityCore.Manager
{


    public class ProcessManager
    {
        ProcessInstanceStore procInsStore;
        BpmnProcessStore procStore;
        ProcessItemDefinitionStore itemDefStore;
        ProcessHistoryStore hisStore;
        ProcessTaskStore taskStore;
        public ProcessManager(DbContext context)
        {
            procInsStore = new ProcessInstanceStore(context);
            procStore = new BpmnProcessStore(context);
            itemDefStore = new ProcessItemDefinitionStore(context);
            hisStore = new ProcessHistoryStore(context);
            taskStore = new ProcessTaskStore(context);
        }



        public bool StartProcess(Guid processKey, string processInstanceName, string user)
        {
            bool result = false;
            if (string.IsNullOrWhiteSpace(processInstanceName))
                throw new BpmnVariableEmptyException("processInstanceName");

            BpmnProcess proc = procStore.FindById(processKey);
            if (proc == null)
                throw new BpmnProcessNotFoundException(string.Format("Bpmn Process with key: '{0}' not found.", processKey.ToString()));

            ProcessInstance pi = new ProcessInstance();
            pi.ProcessKey = processKey;
            pi.ProcessInstanceName = processInstanceName;
            pi.Owner = user;

            //Add to history
            AddHistory(proc.Name, pi.ProcessInstanceName, "", string.Format("User: {0} Started Process '{1}'", user, proc.Name), user);

            ProcessItemDefinition[] startedItem = itemDefStore.GetStartEvent(processKey).ToArray();
            if (startedItem != null)
            {
                foreach (var started in startedItem)
                {
                    Guid[] nextItems = itemDefStore.GetSequenceFlow(started.Key).ToArray();
                    if (nextItems != null)
                    {
                        foreach (var item in nextItems)
                        {
                            ProcessItemDefinition def = itemDefStore.FindById(item);
                            if (def != null && IsTask(def.ItemType))
                            {
                                ProcessTask t = new ProcessTask();
                                t.ProcessKey = proc.Key;
                                t.ProcessInstanceId = pi.ProcessInstanceId;
                                t.ProcessItemDefinitionId = def.Key;
                                t.ProcessTaskName = def.ItemName;
                                taskStore.Create(t);
                                //Add to history
                                AddHistory(proc.Name, pi.ProcessInstanceName, t.ProcessTaskName, string.Format("User: {0} Created Task '{1}'", user, proc.Name), user);
                            }
                        }
                    }
                }
            }

            return result;
        }

        private bool IsTask(ProcessItemType type)
        {
            return type == ProcessItemType.UserTask ||
                type == ProcessItemType.ManualTask;
        }

        private ProcessItemDefinition StartFlow(Guid processKey)
        {
            return itemDefStore.Entities.FirstOrDefault(t => t.ItemType.Equals(Bpmn.ProcessItemType.StartEvent) && t.ProcessKey.Equals(processKey));
        }

        private void AddHistory(string processName, string processInstanceName, string taskName, string description, string user)
        {
            ProcessHistory history = new ProcessHistory();
            history.ProcessName = processName;
            history.ProcessInstanceName = processInstanceName;
            history.TaskName = taskName;
            history.Description = description;
            history.User = user;
            hisStore.Create(history);
        }
    }
}
