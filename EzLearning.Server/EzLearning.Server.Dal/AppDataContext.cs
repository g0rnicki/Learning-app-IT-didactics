using EzLearning.Server.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace EzLearning.Server.Dal
{
    public class AppDataContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Chapter> chapters { get; set; }
        public DbSet<Lesson> lessons { get; set; }
        public DbSet<ChapterTest> tests { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<QuestionAnswer> answers { get; set; }

        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }
    }
}
