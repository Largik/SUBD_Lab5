using JournalDB.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace LAb7.Contexts
{
    public class RedisContext
    {
        public void Convert()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");

            IDatabase db = redis.GetDatabase();

            using (JournalDataBase context = new JournalDataBase())
            {
                db.StringSet("marks", JsonSerializer.Serialize(context.Marks));

                var marksList = JsonSerializer.Deserialize<List<Marks>>(db.StringGet("marks"));
                Console.WriteLine("\nЗахэшированные данные: ");
                foreach (var marks in marksList)
                {
                    Console.WriteLine(marks.Mark);
                }
            }

            using (JournalDataBase context = new JournalDataBase())
            {
                db.StringSet("roles", JsonSerializer.Serialize(context.Roles));

                var roleList = JsonSerializer.Deserialize<List<Role>>(db.StringGet("roles"));
                Console.WriteLine("\nЗахэшированные данные: ");
                foreach (var role in roleList)
                {
                    Console.WriteLine(role.NameRole);
                }
            }

            using (JournalDataBase context = new JournalDataBase())
            {
                db.StringSet("groups", JsonSerializer.Serialize(context.Groups));

                var roleList = JsonSerializer.Deserialize<List<Group>>(db.StringGet("groups"));
                Console.WriteLine("\nЗахэшированные данные: ");
                foreach (var role in roleList)
                {
                    Console.WriteLine(role.NameGroup);
                }
            }
        }
    }
}
