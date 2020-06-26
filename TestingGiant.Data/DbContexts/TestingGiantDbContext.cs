using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TestingGiant.Data.Models;

namespace TestingGiant.Data.DbContexts
{
    public class TestingGiantDbContext : DbContext
    {
        public TestingGiantDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<TestingGiantDbContext>(new CreateDatabaseIfNotExists<TestingGiantDbContext>());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();            
        }

        public static TestingGiantDbContext Create()
        {
            return new TestingGiantDbContext();
        }
    }
}
