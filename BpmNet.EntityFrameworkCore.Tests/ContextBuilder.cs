using BpmNet.EntityFrameworkCore.Configurations;
using BpmNet.EntityFrameworkCore.Models;
using BpmNet.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;

namespace BpmNet.EntityFrameworkCore.Tests
{

    [ExcludeFromCodeCoverage]
    public static class TestBuilder
    {
        public static readonly string PATH_SAMPLE = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"BpmnFile\sample.bpmn");
        public static readonly string GATEWAY = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"BpmnFile\gateway.bpmn");

        public static BpmNetEntityFrameworkCoreBuilder CreateBuilder(IServiceCollection services) => services.AddBpmNet().AddCore().UseEntityFrameworkCore();
        public static BpmNetEntityFrameworkCoreBuilder CreateEntityBuilder(IServiceCollection services) => services.AddBpmNet().AddCore().UseEntityFrameworkCore().UseDbContext<CustomContext>();

        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();
            services.AddOptions();

            return services;
        }

        public static IServiceCollection CreateInMemoryServices()
        {
            var services = new ServiceCollection();
            services.AddOptions();
            services.AddDbContext<CustomContext>(options =>
            {
                options.UseBpmNet();
                options.UseLazyLoadingProxies();
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                //options.UseSqlServer("Data Source=(local);Initial Catalog=BPMNET_NEW;Integrated Security=True");
            });

            return services;
        }
    }

    [ExcludeFromCodeCoverage]
    public class CustomContext : DbContext
    {
        public CustomContext(DbContextOptions options) : base(options) { }
    }

    [ExcludeFromCodeCoverage]
    public class CustomDbContext : DbContext
    {

        public CustomDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BpmNetDefinitionConfiguration());
            builder.ApplyConfiguration(new BpmNetProcessInstanceConfiguration<BpmNetProcessInstance, BpmNetInstanceFlow>());
            builder.ApplyConfiguration(new BpmNetInstanceFlowConfiguration<BpmNetInstanceFlow>());
            builder.ApplyConfiguration(new BpmNetHistoryConfiguration<BpmNetHistory>());
            builder.ApplyConfiguration(new BpmNetRootConfiguration());
            builder.ApplyConfiguration(new BpmNetProcessConfiguration());
        }
    }

    [ExcludeFromCodeCoverage]
    public class CustomDefinition : BpmNetDefinition { }

    [ExcludeFromCodeCoverage]
    public class CustomProcessInstance : IProcessInstance<CustomInstanceFlow>
    {
        public Guid Id { get; set; }
        public string ProcessId { get; set; }
        public string BussinesKey { get; set; }
        public string TenantId { get; set; }
        public InstanceStatus Status { get; set; }
        public ICollection<CustomInstanceFlow> Flows { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CustomInstanceFlow : BpmNetInstanceFlow { }

    [ExcludeFromCodeCoverage]
    public class CustomHistory : BpmNetHistory { }
}
