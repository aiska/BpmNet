using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BpmNet.EntityFrameworkCore.Tests
{
    public class CreateDbTest
    {
        //[Fact]
        public void CreateDatabase()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=BPMNET_NEW;Integrated Security=True");
            var context = new CustomDbContext(optionsBuilder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
