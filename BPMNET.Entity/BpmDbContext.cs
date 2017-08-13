using BPMNET.Configuration;
using BPMNET.Core;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

namespace BPMNET.Entity
{
    public class BpmDbContext : BpmDbContext<string, ProcessInstance, ProcessDefinition, ProcessTask>
    {
        #region Constructor ...
        public BpmDbContext()
            : base(Config.Instance.ConnectionName)
        {
        }
        public BpmDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Process Instance ...
            var processInstance = modelBuilder.Entity<ProcessInstance>();
            processInstance.Property(p => p.ProcessDefinitionId)
                .HasMaxLength(64)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_PROC_INSTANCE_DEF_ID")));
            #endregion

            #region Process Definition ...
            var processDefinition = modelBuilder.Entity<ProcessDefinition>();
            processDefinition.Property(p => p.ProcessDefinitionId).HasMaxLength(64).IsUnicode(UnicodeString);
            #endregion

            #region Process Definition ...
            var processTask = modelBuilder.Entity<ProcessTask>();
            processTask.Property(p => p.ProcessTaskId).HasMaxLength(64).IsUnicode(UnicodeString);
            #endregion
        }
        #endregion
    }

    public class DeploymentDbContext<TKey, TDeployment, TProcessDefinition, TProcessItemDefinition> : 
        DefinitionDbContext<TKey, TProcessDefinition, TProcessItemDefinition>
        where TDeployment : class, IDeployment<TKey>
        where TProcessDefinition : class, IProcessDefinition<TKey>
        where TProcessItemDefinition : class, IProcessItemDefinition<TKey>
    {
        protected const string DEPLOYMENT_TABLE = "AP_DEPLOYMENT";
        protected new DatabaseGeneratedOption Option { get; private set; }
        protected new bool UnicodeString { get; private set; }

        #region Constructor ...
        public DeploymentDbContext()
            : this(Config.Instance.ConnectionName)
        {
        }
        public DeploymentDbContext(string nameOrConnectionString)
            : this(nameOrConnectionString, Config.Instance.GeneratedOption, Config.Instance.UnicodeString)
        {
        }

        protected DeploymentDbContext(string nameOrConnectionString, DatabaseGeneratedOption option, bool unicodeString) : base(nameOrConnectionString,option, unicodeString)
        {
        }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Deployment ...
            var deployment = modelBuilder.Entity<TDeployment>().ToTable(DEPLOYMENT_TABLE);
            deployment.MapToStoredProcedures();
            deployment.HasKey(t => t.DeploymentId);
            deployment.Property(p => p.Name)
                .HasMaxLength(255)
                .IsUnicode(UnicodeString)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_DEPLOY_NAME")));
            deployment.Property(p => p.TenantId).HasMaxLength(255).IsUnicode(UnicodeString);
            #endregion

        }
    }

    public class DefinitionDbContext<TKey, TProcessDefinition, TProcessItemDefinition> : DbContext
        where TProcessDefinition : class, IProcessDefinition<TKey>
        where TProcessItemDefinition : class, IProcessItemDefinition<TKey>
    {
        protected const string DEFINITION_TABLE = "AP_DEFINITION";
        protected const string ITEM_DEFINITION_TABLE = "AP_DEFINITION_ITEM";

        protected DatabaseGeneratedOption Option { get; private set; }
        protected bool UnicodeString { get; private set; }

        #region Constructor ...
        public DefinitionDbContext()
            : this(Config.Instance.ConnectionName)
        {
        }
        public DefinitionDbContext(string nameOrConnectionString)
            : this(nameOrConnectionString, Config.Instance.GeneratedOption, Config.Instance.UnicodeString)
        {
        }

        protected DefinitionDbContext(string nameOrConnectionString, DatabaseGeneratedOption option, bool unicodeString) : base(nameOrConnectionString)
        {
            Option = option;
            UnicodeString = unicodeString;
        }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Process Definition ...
            var processDefinition = modelBuilder.Entity<TProcessDefinition>().ToTable(DEFINITION_TABLE);
            processDefinition.MapToStoredProcedures();
            processDefinition.HasKey(t => t.ProcessDefinitionId);
            processDefinition.Property(p => p.Name)
                .HasMaxLength(255)
                .IsUnicode(UnicodeString)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_PROC_DEF_NAME")));
            processDefinition.Property(p => p.Description)
                .IsUnicode(UnicodeString);
            processDefinition.Property(p => p.TenantId)
                .HasMaxLength(255)
                .IsUnicode(UnicodeString);
            #endregion

            #region Item Definition ...
            var ItemDefinition = modelBuilder.Entity<TProcessItemDefinition>().ToTable(ITEM_DEFINITION_TABLE);
            ItemDefinition.MapToStoredProcedures();
            ItemDefinition.HasKey(t => t.Id);
            ItemDefinition.Ignore(t => t.UserCandidates);
            ItemDefinition.Ignore(t => t.RoleCandidates);
            #endregion
        }
    }

    public class BpmDbContext<TKey, TProcessInstance, TProcessDefinition, TProcessTask> : DbContext
    where TProcessInstance : class, IProcessInstance<TKey>
    where TProcessDefinition : class, IProcessDefinition<TKey>
    where TProcessTask : class, IProcessTask<TKey>
    {

        protected const string PROCESS_INSTANCE_TABLE = "AP_PROCESS_INSTANCE";
        protected const string PROCESS_DEFINITION_TABLE = "AP_PROCESS_DEFINITION";
        protected const string PROCESS_TASK_TABLE = "AP_PROCESS_TASK";
        protected DatabaseGeneratedOption Option { get; private set; }
        protected bool UnicodeString { get; private set; }

        #region Constructor ...
        public BpmDbContext()
            : this(Config.Instance.ConnectionName)
        {
        }
        public BpmDbContext(string nameOrConnectionString)
            : this(nameOrConnectionString, Config.Instance.GeneratedOption, Config.Instance.UnicodeString)
        {
        }

        protected BpmDbContext(string nameOrConnectionString, DatabaseGeneratedOption option, bool unicodeString) : base(nameOrConnectionString)
        {
            Option = option;
            UnicodeString = unicodeString;
        }
        #endregion

        #region DbSet ...
        //protected virtual IDbSet<TProcessInstance> ProcessInstances { get; set; }
        //protected virtual IDbSet<TProcessDefinition> ProcessDefinitions { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Process Instance ...
            var processInstance = modelBuilder.Entity<TProcessInstance>().ToTable(PROCESS_INSTANCE_TABLE);
            processInstance.MapToStoredProcedures();
            processInstance.HasKey(t => t.ProcessInstanceId);
            processInstance.Property(p => p.Name)
                .HasMaxLength(255)
                .IsUnicode(UnicodeString)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_PROC_INSTANCE_NAME")));
            processInstance.Property(p => p.ProcessDefinitionName)
                .HasMaxLength(255)
                .IsUnicode(UnicodeString);
            processInstance.Property(p => p.BusinessKey)
                .HasMaxLength(255)
                .IsUnicode(UnicodeString);
            processInstance.Property(p => p.TenantId)
                .HasMaxLength(255)
                .IsUnicode(UnicodeString);
            processInstance.Property(p => p.UserCandidates)
                .IsUnicode(UnicodeString);
            #endregion

            #region Process Definition ...
            var processDefinition = modelBuilder.Entity<TProcessDefinition>().ToTable(PROCESS_DEFINITION_TABLE);
            processDefinition.MapToStoredProcedures();
            processDefinition.HasKey(t => t.ProcessDefinitionId);
            processDefinition.Property(p => p.Name)
                .HasMaxLength(255)
                .IsUnicode(UnicodeString)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_PROC_DEF_NAME")));
            processDefinition.Property(p => p.Description)
                .IsUnicode(UnicodeString);
            processDefinition.Property(p => p.TenantId)
                .HasMaxLength(255)
                .IsUnicode(UnicodeString);
            #endregion

            #region Process Task ...
            var processTask = modelBuilder.Entity<TProcessTask>().ToTable(PROCESS_TASK_TABLE);
            processTask.MapToStoredProcedures();
            processTask.HasKey(t => t.ProcessTaskId);
            processTask.Property(p => p.Name)
                .HasMaxLength(255)
                .IsUnicode(UnicodeString)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_PROC_TASK_NAME")));
            #endregion
        }
    }
}
