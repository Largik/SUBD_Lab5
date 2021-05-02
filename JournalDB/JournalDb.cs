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

                using (StreamReader sr = new StreamReader($"{startupPathForMigrations}\\PolyclinicDB\\DB.config.json"))
                {
                    dbConfig = sr.ReadToEnd();
                }

                ConnectionConfig connectionConfig = JsonConvert.DeserializeObject<ConnectionConfig>(dbConfig);
                optionsBuilder.UseNpgsql(connectionConfig.ConnectionString);

                base.OnConfiguring(optionsBuilder);
            }
        }
    }
}
