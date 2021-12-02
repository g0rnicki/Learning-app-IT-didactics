using EzLearning.Server.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace EzLearning.Server.Dal
{
    public class AppDataContext : DbContext
    {
        public DbSet<User> users { get; set; }

        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }
    }
}
