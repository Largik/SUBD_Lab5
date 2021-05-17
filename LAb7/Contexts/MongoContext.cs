using MongoDB.Driver;
using System;
using Microsoft.EntityFrameworkCore;
using JournalDB.Models;

namespace LAb7.Contexts
{
    public class MongoContext
    {
        public void Convert()
        {
            MongoClient dbClient = new MongoClient("mongodb://127.0.0.1:27017");

            dbClient.DropDatabase("JournalDb");

            var db = dbClient.GetDatabase("JournalDb");

            var roles = db.GetCollection<Role>("role");
            var groups = db.GetCollection<Group>("group");
            var users = db.GetCollection<User>("user");
            var marks = db.GetCollection<Marks>("marks");
            var disciplines = db.GetCollection<Discipline>("discipline");

            using (JournalDataBase context = new JournalDataBase())
            {  

                foreach (var group in context.Groups)
                {
                    groups.InsertOne(group);
                    Console.WriteLine("Группа " + group.NameGroup + " добавлена в соответсвующую коллекцию");
                }

                foreach (var role in context.Roles)
                {
                    roles.InsertOne(role);
                    Console.WriteLine("Должность " + role.NameRole + " добавлена в соответсвующую коллекцию");
                }

                var userList = context.Users
                    .Include(rec => rec.Group)
                    .Include(rec => rec.Role);
                foreach (var user in userList)
                {
                    users.InsertOne(user);
                    Console.WriteLine("Пользователь " + user.Login + " добавлен в соответсвующую коллекцию");
                }

                var disciplineList = context.Disciplines
                    .Include(rec => rec.User);
                foreach (var discipline in disciplineList)
                {
                    disciplines.InsertOne(discipline);
                    Console.WriteLine("Дисциплина " + discipline.NameDiscipline + " добавлена в соответсвующую коллекцию");
                }

                var marksList = context.Marks
                 .Include(rec => rec.User)
                 .Include(rec => rec.Discipline);
                foreach (var mark in marksList)
                {
                    marks.InsertOne(mark);
                    Console.WriteLine("Оценка " + mark.Mark + " добавлена в соответсвующую коллекцию");
                }
            }
        }
    }
}
