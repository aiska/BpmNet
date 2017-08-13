using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

namespace BPMNET.Entity.IntKey
{
    public class BpmDbContext : BpmDbContext<int, ProcessInstance, ProcessDefinition, ProcessTask>
    {
        #region Constructor ...
        public BpmDbContext()
            : base()
        {
        }
        public BpmDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Process Instance ...
            var processInstance = modelBuilder.Entity<ProcessInstance>();
            processInstance.Property(p => p.ProcessInstanceId).HasDatabaseGeneratedOption(Option);
            processInstance.Property(p => p.ProcessDefinitionId)
                .IsOptional()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_PROC_INSTANCE_DEF_ID")));
            #endregion

            #region Process Definition ...
            var processDefinition = modelBuilder.Entity<ProcessDefinition>().ToTable(PROCESS_DEFINITION_TABLE);
            processDefinition.Property(p => p.ProcessDefinitionId).HasDatabaseGeneratedOption(Option);
            #endregion

            #region Process Definition ...
            var processTask = modelBuilder.Entity<ProcessTask>();
            processTask.Property(p => p.ProcessTaskId).HasDatabaseGeneratedOption(Option);
            #endregion
        }
    }
}
