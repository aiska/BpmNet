using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;

namespace BPMNET.EntityCore
{
    public class BpmDbContext : DbContext
    {
        public BpmDbContext() : base()
        { }
        public BpmDbContext(DbContextOptions<BpmDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string ConnStr = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
            optionsBuilder.UseSqlServer(ConnStr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var processInstance = modelBuilder.Entity<ProcessInstance>().ToTable("BPMNET_PROCESS_INSTANCE");
            processInstance.HasKey(c => c.ProcessInstanceId);
            processInstance.Property(t => t.ProcessInstanceName).HasColumnType("varchar(255)").IsRequired();
            processInstance.Property(t => t.BusinessKey).HasColumnType("varchar(255)");
            processInstance.Property(t => t.UserCandidates).HasColumnType("varchar(max)");
            processInstance.Property(t => t.Owner).HasColumnType("varchar(max)");
            processInstance.Property(t => t.Inserted).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()"); ;
            processInstance.Property(t => t.LastUpdated).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
            processInstance.Property(t => t.Timestamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();

            var deployment = modelBuilder.Entity<Deployment>().ToTable("BPMNET_DEPLOYMENT");
            deployment.HasKey(c => c.DeploymentId);
            deployment.Property(t => t.DeploymentName).HasColumnType("varchar(50)");
            deployment.Property(t => t.DeploymentCategory).HasColumnType("varchar(255)");
            deployment.Property(t => t.DeploymentTenantId).HasColumnType("varchar(255)");
            deployment.Property(t => t.DeploymentVersion).HasColumnType("varchar(10)");
            deployment.Property(t => t.Inserted).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()"); ;
            deployment.Property(t => t.LastUpdated).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
            deployment.Property(t => t.Timestamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();

            var bpmnDefinition = modelBuilder.Entity<BpmnDefinition>().ToTable("BPMNET_DEFINITION");
            bpmnDefinition.HasKey(c => c.Key);
            bpmnDefinition.Property(t => t.Id).HasColumnType("varchar(50)");
            bpmnDefinition.Property(t => t.Name).HasColumnType("varchar(50)");
            bpmnDefinition.HasMany(t => t.ItemDefinitions).WithOne().HasForeignKey(t => t.DefinitionKey).OnDelete(DeleteBehavior.Cascade);

            var bpmnProcess = modelBuilder.Entity<BpmnProcess>().ToTable("BPMNET_PROCESS");
            bpmnProcess.HasKey(c => c.Key);
            bpmnProcess.Property(t => t.Id).HasColumnType("varchar(255)");
            bpmnProcess.Property(t => t.Name).HasColumnType("varchar(255)");

            var processItemDefinition = modelBuilder.Entity<ProcessItemDefinition>().ToTable("BPMNET_PROCESS_ITEM");
            processItemDefinition.HasKey(c => c.Key);
            processItemDefinition.Property(t => t.ItemId).HasColumnType("varchar(255)");
            processItemDefinition.Property(t => t.ItemName).HasColumnType("varchar(255)");
            

            var processTask = modelBuilder.Entity<ProcessTask>().ToTable("BPMNET_PROCESS_TASK");
            processTask.HasKey(c => c.ProcessTaskId);
            processTask.Property(t => t.ProcessTaskName).HasColumnType("varchar(255)");
            processTask.Property(t => t.ProcessTaskOwner).HasColumnType("varchar(255)");
            processTask.Property(t => t.Inserted).ValueGeneratedOnAdd();
            processTask.Property(t => t.Inserted).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()"); ;
            processTask.Property(t => t.LastUpdated).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
            processTask.Property(t => t.Timestamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();

            var processHistory = modelBuilder.Entity<ProcessHistory>().ToTable("BPMNET_PROCESS_HISTORY");
            processHistory.HasKey(c => c.ProcessHistoryId);
            processHistory.Property(t => t.ProcessName).HasColumnType("varchar(255)");
            processHistory.Property(t => t.ProcessInstanceName).HasColumnType("varchar(255)");
            processHistory.Property(t => t.TaskName).HasColumnType("varchar(255)");
            processHistory.Property(t => t.Description).HasColumnType("varchar(max)");
            processHistory.Property(t => t.User).HasColumnType("varchar(255)");
            processHistory.Property(t => t.Inserted).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");

            var processItemVariable = modelBuilder.Entity<ProcessItemVariable>().ToTable("BPMNET_PROCESS_ITEM_VARIABLE");
            processItemVariable.HasKey(c => c.Key);
            processItemVariable.Property(t => t.VariableName).HasColumnType("varchar(255)");
            processItemVariable.Property(t => t.DataType).HasColumnType("varchar(255)");

            var bpmnActivity = modelBuilder.Entity<BpmnFlowNode>().ToTable("BPMNET_FLOW_NODE");
            bpmnActivity.HasKey(c => c.Key);
            bpmnActivity.Property(t => t.Id).HasColumnType("varchar(255)");
            bpmnActivity.Property(t => t.Name).HasColumnType("varchar(255)");

            var bpmnSequenceFlow = modelBuilder.Entity<BpmnSequenceFlow>().ToTable("BPMNET_SEQUENCE_FLOW");
            bpmnSequenceFlow.HasKey(c => c.Key);
            bpmnSequenceFlow.Property(t => t.Id).HasColumnType("varchar(255)").IsRequired();
            bpmnSequenceFlow.Property(t => t.Name).HasColumnType("varchar(255)");

            var bpmnItemDefinition = modelBuilder.Entity<BpmnItemDefinition>().ToTable("BPMNET_ITEM_DEFINITION");
            bpmnSequenceFlow.HasKey(c => c.Key);
            bpmnSequenceFlow.Property(t => t.Id).HasColumnType("varchar(255)").IsRequired();
            bpmnSequenceFlow.Property(t => t.Name).HasColumnType("varchar(255)");
        }
    }
}