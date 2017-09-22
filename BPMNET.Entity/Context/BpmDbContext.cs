using BPMNET.Configuration;
using BPMNET.Entity.Mapping;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace BPMNET.Entity
{
    public class BpmDbContext : DbContext
    {
        #region Constructor ...
        public BpmDbContext()
            : this(Config.Instance.ConnectionName)
        {
        }
        public BpmDbContext(string nameOrConnectionString)
            : this(nameOrConnectionString, DatabaseGeneratedOption.Identity, false)
        {
        }

        protected BpmDbContext(string nameOrConnectionString, DatabaseGeneratedOption option, bool unicodeString) : base(nameOrConnectionString)
        {
            Config.DefaultDatabaseGeneratedOption = option;
            Config.DefaultUnicodeString = unicodeString;
        }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DeploymentMap());
            modelBuilder.Configurations.Add(new DefinitionMap());
            modelBuilder.Configurations.Add(new DefinitionItemMap());
            //modelBuilder.Configurations.Add(new DefinitionVariableMap());
            modelBuilder.Configurations.Add(new ProcessMap());
            modelBuilder.Configurations.Add(new ProcessInstanceMap());
            modelBuilder.Configurations.Add(new ProcessTaskMap());
            modelBuilder.Configurations.Add(new ProcessVariablesMap());
            modelBuilder.Configurations.Add(new CommentMap());
            //modelBuilder.Configurations.Add(new DataObjectMap());
            modelBuilder.Configurations.Add(new FlowNodeMap());
            modelBuilder.Configurations.Add(new SequenceFlowMap());
            //modelBuilder.Configurations.Add(new ApprovalMap());
            //modelBuilder.Configurations.Add(new ActivityMap());
            modelBuilder.Configurations.Add(new ProcessFlowMap());
        }
    }
}
