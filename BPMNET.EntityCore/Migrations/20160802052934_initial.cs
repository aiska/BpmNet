using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BPMNET.EntityCore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BPMNET_DEFINITION",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    DefinitionId = table.Column<string>(type: "varchar(50)", nullable: true),
                    DefinitionKey = table.Column<string>(nullable: true),
                    DefinitionName = table.Column<string>(type: "varchar(50)", nullable: true),
                    DeploymentId = table.Column<Guid>(nullable: false),
                    Inserted = table.Column<DateTime>(nullable: false),
                    IsSuspended = table.Column<bool>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    ProcessDefinitionDescription = table.Column<string>(nullable: true),
                    ProcessDefinitionDiagramResourceName = table.Column<string>(nullable: true),
                    ProcessDefinitionHasGraphicalNotation = table.Column<bool>(nullable: false),
                    ProcessDefinitionHasStartFormKey = table.Column<bool>(nullable: false),
                    ProcessDefinitionResource = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true),
                    Timestamp = table.Column<byte[]>(nullable: true),
                    XmlData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPMNET_DEFINITION", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "BPMNET_FLOW_NODE",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    CompletionQuantity = table.Column<int>(nullable: false),
                    Id = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsForCompensation = table.Column<bool>(nullable: false),
                    ItemType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true),
                    StartQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPMNET_FLOW_NODE", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "BPMNET_ITEM_DEFINITION",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsCollection = table.Column<bool>(nullable: false),
                    ItemKind = table.Column<int>(nullable: false),
                    Key = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StructureRef = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPMNET_ITEM_DEFINITION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BPMNET_PROCESS",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    DefinitionKey = table.Column<Guid>(nullable: false),
                    Id = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsClosed = table.Column<bool>(nullable: false),
                    IsExecutable = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPMNET_PROCESS", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "BPMNET_SEQUENCE_FLOW",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    ConditionExpression = table.Column<string>(nullable: true),
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    ItemSourceRef = table.Column<Guid>(nullable: false),
                    ItemSourceTarget = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPMNET_SEQUENCE_FLOW", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "BPMNET_DEPLOYMENT",
                columns: table => new
                {
                    DeploymentId = table.Column<Guid>(nullable: false),
                    DeploymentCategory = table.Column<string>(type: "varchar(255)", nullable: true),
                    DeploymentName = table.Column<string>(type: "varchar(50)", nullable: true),
                    DeploymentTenantId = table.Column<string>(type: "varchar(255)", nullable: true),
                    DeploymentVersion = table.Column<string>(type: "varchar(10)", nullable: true),
                    Inserted = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    LastUpdated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPMNET_DEPLOYMENT", x => x.DeploymentId);
                });

            migrationBuilder.CreateTable(
                name: "BPMNET_PROCESS_HISTORY",
                columns: table => new
                {
                    ProcessHistoryId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", nullable: true),
                    Inserted = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ProcessInstanceName = table.Column<string>(type: "varchar(255)", nullable: true),
                    ProcessName = table.Column<string>(type: "varchar(255)", nullable: true),
                    TaskName = table.Column<string>(type: "varchar(255)", nullable: true),
                    User = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPMNET_PROCESS_HISTORY", x => x.ProcessHistoryId);
                });

            migrationBuilder.CreateTable(
                name: "BPMNET_PROCESS_INSTANCE",
                columns: table => new
                {
                    ProcessInstanceId = table.Column<Guid>(nullable: false),
                    BusinessKey = table.Column<string>(type: "varchar(255)", nullable: true),
                    Inserted = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    LastUpdated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Owner = table.Column<string>(type: "varchar(max)", nullable: true),
                    ProcessInstanceName = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProcessKey = table.Column<Guid>(nullable: false),
                    SuspensionState = table.Column<int>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UserCandidates = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPMNET_PROCESS_INSTANCE", x => x.ProcessInstanceId);
                });

            migrationBuilder.CreateTable(
                name: "BPMNET_PROCESS_ITEM",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    ConditionExpression = table.Column<string>(nullable: true),
                    ItemId = table.Column<string>(type: "varchar(255)", nullable: true),
                    ItemName = table.Column<string>(type: "varchar(255)", nullable: true),
                    ItemSourceRef = table.Column<Guid>(nullable: false),
                    ItemSourceTarget = table.Column<Guid>(nullable: false),
                    ItemType = table.Column<int>(nullable: false),
                    ProcessKey = table.Column<Guid>(nullable: false),
                    itemSubjectRef = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPMNET_PROCESS_ITEM", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "BPMNET_PROCESS_ITEM_VARIABLE",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    DataType = table.Column<string>(type: "varchar(255)", nullable: true),
                    ProcessItemKey = table.Column<Guid>(nullable: false),
                    VariableName = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPMNET_PROCESS_ITEM_VARIABLE", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "BPMNET_PROCESS_TASK",
                columns: table => new
                {
                    ProcessTaskId = table.Column<Guid>(nullable: false),
                    Inserted = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    LastUpdated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ParentTaskId = table.Column<Guid>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    ProcessInstanceId = table.Column<Guid>(nullable: false),
                    ProcessItemDefinitionId = table.Column<Guid>(nullable: false),
                    ProcessKey = table.Column<Guid>(nullable: false),
                    ProcessTaskName = table.Column<string>(type: "varchar(255)", nullable: true),
                    ProcessTaskOwner = table.Column<string>(type: "varchar(255)", nullable: true),
                    SuspensionState = table.Column<int>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPMNET_PROCESS_TASK", x => x.ProcessTaskId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BPMNET_DEFINITION");

            migrationBuilder.DropTable(
                name: "BPMNET_FLOW_NODE");

            migrationBuilder.DropTable(
                name: "BPMNET_ITEM_DEFINITION");

            migrationBuilder.DropTable(
                name: "BPMNET_PROCESS");

            migrationBuilder.DropTable(
                name: "BPMNET_SEQUENCE_FLOW");

            migrationBuilder.DropTable(
                name: "BPMNET_DEPLOYMENT");

            migrationBuilder.DropTable(
                name: "BPMNET_PROCESS_HISTORY");

            migrationBuilder.DropTable(
                name: "BPMNET_PROCESS_INSTANCE");

            migrationBuilder.DropTable(
                name: "BPMNET_PROCESS_ITEM");

            migrationBuilder.DropTable(
                name: "BPMNET_PROCESS_ITEM_VARIABLE");

            migrationBuilder.DropTable(
                name: "BPMNET_PROCESS_TASK");
        }
    }
}
