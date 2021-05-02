using JournalDB.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.IO;

namespace JournalDB
{
    public class JournalDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                string startupPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
                string startupPathForMigrations = Directory.GetParent(Environment.CurrentDirectory).FullName;

                string dbConfig;

                using (StreamReader sr = new StreamReader($"{startupPathForMigrations}\\JournalDataBase\\Db.json"))
                {
                    dbConfig = sr.ReadToEnd();
                }

                ConnectionConfig connectionConfig = JsonConvert.DeserializeObject<ConnectionConfig>(dbConfig);
                optionsBuilder.UseNpgsql(connectionConfig.ConnectionString);

                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discipline>().HasIndex(u => u.NameDiscipline).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Login).IsUnique();
            modelBuilder.Entity<Role>().HasIndex(u => u.NameRole).IsUnique();
            modelBuilder.Entity<Group>().HasIndex(u => u.NameGroup).IsUnique();
            modelBuilder.Entity<Marks>().HasIndex(u => u.UserId);
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Marks> Marks { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }
    }
}
