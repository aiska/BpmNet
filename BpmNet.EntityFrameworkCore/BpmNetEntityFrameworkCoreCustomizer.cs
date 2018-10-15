using BpmNet.EntityFrameworkCore.Models;
using BpmNet.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace BpmNet.EntityFrameworkCore
{
    public class BpmNetEntityFrameworkCoreCustomizer<TInstance, TInstanceFlow, THistory> : RelationalModelCustomizer
        where TInstance : class, IProcessInstance<TInstanceFlow>
        where TInstanceFlow : BpmNetInstanceFlow
        where THistory : BpmNetHistory

    {
        public BpmNetEntityFrameworkCoreCustomizer(ModelCustomizerDependencies dependencies) : base(dependencies) { }

        public override void Customize(ModelBuilder modelBuilder, DbContext context)
        {
            // Register the BpmNet entity sets.
            modelBuilder.UseBpmNet<TInstance, TInstanceFlow, THistory>();

            base.Customize(modelBuilder, context);
        }
    }
}
