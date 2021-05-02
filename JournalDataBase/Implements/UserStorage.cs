using JournalBusinessLogic.BindingModels;
using JournalBusinessLogic.Interfaces;
using JournalBusinessLogic.ViewModels;
using JournalDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JournalDB.Implements
{
    public class UserStorage : IUserStorage
    {
        public List<UserViewModel> GetFullList()
        {
            using (var context = new JournalDb())
            {
                return context.Users
                    .Include(rec => rec.Role)
                    .Include(rec => rec.Group)
                    .Select(rec => new UserViewModel
                    {
                        Id = rec.Id,
                        RoleId = rec.RoleId,
                        NameRole = rec.Role.NameRole,
                        GroupId = rec.GroupId.HasValue ? rec.GroupId : null,
                        NameGroup = rec.GroupId.HasValue ? rec.Group.NameGroup : string.Empty,
                        UserName = rec.UserName,
                        Login = rec.Login,
                        Password = rec.Password
                    })
                    .ToList();
            }
        }
        public UserViewModel GetElement(UserBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new JournalDb())
            {
                var user = context.Users
                    .Include(rec => rec.Role)
                    .Include(rec => rec.Group)
                    .FirstOrDefault(rec => rec.Login == model.Login ||
                    rec.Id == model.Id);

                return user != null ?
                    new UserViewModel
                    {
                        Id = user.Id,
                        RoleId = user.RoleId,
                        NameRole = user.Role.NameRole,
                        GroupId = user.GroupId.HasValue ? user.GroupId : null,
                        NameGroup = user.GroupId.HasValue ? user.Group.NameGroup : string.Empty,
                        UserName = user.UserName,
                        Login = user.Login,
                        Password = user.Password
                    } :
                    null;
            }
        }
        public void Insert(UserBindingModel model)
        {
            using (var context = new JournalDb())
            {
                context.Users.Add(CreateModel(model, new User()));
                context.SaveChanges();
            }
        }
        public void Update(UserBindingModel model)
        {
            using (var context = new JournalDb())
            {
                var user = context.Users.FirstOrDefault(rec => rec.Id == model.Id);

                if (user == null)
                {
                    throw new Exception("Пользователь не найден");
                }

                CreateModel(model, user);
                context.SaveChanges();
            }
        }
        public void Delete(UserBindingModel model)
        {
            using (var context = new JournalDb())
            {
                var user = context.Users.FirstOrDefault(rec => rec.Id == model.Id);

                if (user == null)
                {
                    throw new Exception("Пользователь не найден");
                }

                context.Users.Remove(user);
                context.SaveChanges();
            }
        }
        private User CreateModel(UserBindingModel model, User user)
        {
            user.UserName = model.UserName;
            user.Login = model.Login;
            user.Password = model.Password;
            user.RoleId = model.RoleId;
            user.GroupId = model.GroupId.HasValue ? model.GroupId : null;
            return user;
        }
    }
}
