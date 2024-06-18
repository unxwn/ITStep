using QuizApp.Models;
using System.Data.Entity;

namespace QuizApp.Data
{
    internal class QuizContext : DbContext
    {
        public QuizContext() : base("QuizDB") { }

        public DbSet<User> Users { get; set; }
        public DbSet<QuizResult> QuizResults { get; set; }

        public void ClearData()
        {
            foreach (User entity in Users)
                Users.Remove(entity);

            foreach (QuizResult entity in QuizResults)
                QuizResults.Remove(entity);

            SaveChanges();
        }
    }
}
