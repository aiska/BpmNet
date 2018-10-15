using Microsoft.EntityFrameworkCore;

namespace BpmNet.Api.Tests
{
    public class BpmNetContext : DbContext
    {
        public BpmNetContext(DbContextOptions options) : base(options) { }
    }
}
