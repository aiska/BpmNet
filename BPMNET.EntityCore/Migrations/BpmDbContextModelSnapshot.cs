using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BPMNET.EntityCore.Migrations
{
    [DbContext(typeof(BpmDbContext))]
    partial class BpmDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BPMNET.EntityCore.BpmnDefinition", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DefinitionId")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DefinitionKey");

                    b.Property<string>("DefinitionName")
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("DeploymentId");

                    b.Property<DateTime>("Inserted");

                    b.Property<bool>("IsSuspended");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("ProcessDefinitionDescription");

                    b.Property<string>("ProcessDefinitionDiagramResourceName");

                    b.Property<bool>("ProcessDefinitionHasGraphicalNotation");

                    b.Property<bool>("ProcessDefinitionHasStartFormKey");

                    b.Property<string>("ProcessDefinitionResource");

                    b.Property<string>("TenantId");

                    b.Property<byte[]>("Timestamp");

                    b.Property<string>("XmlData");

                    b.HasKey("Key");

                    b.ToTable("BPMNET_DEFINITION");
                });

            modelBuilder.Entity("BPMNET.EntityCore.BpmnFlowNode", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompletionQuantity");

                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsForCompensation");

                    b.Property<int>("ItemType");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("StartQuantity");

                    b.HasKey("Key");

                    b.ToTable("BPMNET_FLOW_NODE");
                });

            modelBuilder.Entity("BPMNET.EntityCore.BpmnItemDefinition", b =>
                {
                    b.Property<string>("Id");

                    b.Property<bool>("IsCollection");

                    b.Property<int>("ItemKind");

                    b.Property<Guid>("Key");

                    b.Property<string>("Name");

                    b.Property<string>("StructureRef");

                    b.HasKey("Id");

                    b.ToTable("BPMNET_ITEM_DEFINITION");
                });

            modelBuilder.Entity("BPMNET.EntityCore.BpmnProcess", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("DefinitionKey");

                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsClosed");

                    b.Property<bool>("IsExecutable");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Key");

                    b.ToTable("BPMNET_PROCESS");
                });

            modelBuilder.Entity("BPMNET.EntityCore.BpmnSequenceFlow", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConditionExpression");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("ItemSourceRef");

                    b.Property<Guid>("ItemSourceTarget");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Key");

                    b.ToTable("BPMNET_SEQUENCE_FLOW");
                });

            modelBuilder.Entity("BPMNET.EntityCore.Deployment", b =>
                {
                    b.Property<Guid>("DeploymentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DeploymentCategory")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DeploymentName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DeploymentTenantId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DeploymentVersion")
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("Inserted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("DeploymentId");

                    b.ToTable("BPMNET_DEPLOYMENT");
                });

            modelBuilder.Entity("BPMNET.EntityCore.ProcessHistory", b =>
                {
                    b.Property<Guid>("ProcessHistoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("Inserted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("ProcessInstanceName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProcessName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("TaskName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("User")
                        .HasColumnType("varchar(255)");

                    b.HasKey("ProcessHistoryId");

                    b.ToTable("BPMNET_PROCESS_HISTORY");
                });

            modelBuilder.Entity("BPMNET.EntityCore.ProcessInstance", b =>
                {
                    b.Property<Guid>("ProcessInstanceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessKey")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("Inserted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Owner")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("ProcessInstanceName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("ProcessKey");

                    b.Property<int>("SuspensionState");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UserCandidates")
                        .HasColumnType("varchar(max)");

                    b.HasKey("ProcessInstanceId");

                    b.ToTable("BPMNET_PROCESS_INSTANCE");
                });

            modelBuilder.Entity("BPMNET.EntityCore.ProcessItemDefinition", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConditionExpression");

                    b.Property<string>("ItemId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ItemName")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("ItemSourceRef");

                    b.Property<Guid>("ItemSourceTarget");

                    b.Property<int>("ItemType");

                    b.Property<Guid>("ProcessKey");

                    b.Property<string>("itemSubjectRef");

                    b.HasKey("Key");

                    b.ToTable("BPMNET_PROCESS_ITEM");
                });

            modelBuilder.Entity("BPMNET.EntityCore.ProcessItemVariable", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DataType")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("ProcessItemKey");

                    b.Property<string>("VariableName")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Key");

                    b.ToTable("BPMNET_PROCESS_ITEM_VARIABLE");
                });

            modelBuilder.Entity("BPMNET.EntityCore.ProcessTask", b =>
                {
                    b.Property<Guid>("ProcessTaskId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Inserted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("ParentTaskId");

                    b.Property<int>("Priority");

                    b.Property<Guid>("ProcessInstanceId");

                    b.Property<Guid>("ProcessItemDefinitionId");

                    b.Property<Guid>("ProcessKey");

                    b.Property<string>("ProcessTaskName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProcessTaskOwner")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("SuspensionState");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("ProcessTaskId");

                    b.ToTable("BPMNET_PROCESS_TASK");
                });
        }
    }
}
