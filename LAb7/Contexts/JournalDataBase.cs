using Microsoft.EntityFrameworkCore;
using JournalDB.Models;

namespace LAb7.Contexts
{
    public class JournalDataBase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Journaldb;Username=postgres;Password=981025");
                }
                base.OnConfiguring(optionsBuilder);
            }
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Marks> Marks { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }
    }
}
