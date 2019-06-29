using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Diagnostics.CodeAnalysis;

namespace BpmNet.EntityFrameworkCore.Tests
{
    [ExcludeFromCodeCoverage]
    public class CustomContextFactory : IDesignTimeDbContextFactory<CustomDbContext>
    {
        public CustomDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CustomDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=BPMNET_NEW;Integrated Security=True");

            return new CustomDbContext(optionsBuilder.Options);
        }
    }
}
