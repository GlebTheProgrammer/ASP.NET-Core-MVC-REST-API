using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.DbConfiguration
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> opt) : base(opt)
        {

        }

        public DbSet<Command> Commands { get; set; }
    }
}
