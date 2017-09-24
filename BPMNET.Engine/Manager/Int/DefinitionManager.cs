using BPMNET.Entity;
using BPMNET.Entity.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMNET.Engine.Manager.Int
{
    public class DefinitionManager : DefinitionManager<int, ProcessDefinitionStore, DeploymentEntity>
    {
        public DefinitionManager(ProcessDefinitionStore definitionStore) : base(definitionStore)
        {
        }
    }
}
