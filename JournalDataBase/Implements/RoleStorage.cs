using JournalBusinessLogic.BindingModels;
using JournalBusinessLogic.Interfaces;
using JournalBusinessLogic.ViewModels;
using JournalDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JournalDB.Implements
{
    public class RoleStorage : IRoleStorage
    {
        public List<RoleViewModel> GetFullList()
        {
            using (var context = new JournalDb())
            {
                return context.Roles
                    .Select(rec => new RoleViewModel
                    {
                        Id = rec.Id,
                        NameRole = rec.NameRole
                    })
                    .ToList();
            }
        }
        public RoleViewModel GetElement(RoleBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new JournalDb())
            {
                var role = context.Roles
                    .FirstOrDefault(rec => rec.NameRole == model.NameRole ||
                    rec.Id == model.Id);

                return role != null ?
                    new RoleViewModel
                    {
                        Id = role.Id,
                        NameRole = role.NameRole
                    } :
                    null;
            }
        }
        public void Insert(RoleBindingModel model)
        {
            using (var context = new JournalDb())
            {
                context.Roles.Add(CreateModel(model, new Role()));
                context.SaveChanges();
            }
        }
        public void Update(RoleBindingModel model)
        {
            using (var context = new JournalDb())
            {
                var role = context.Roles.FirstOrDefault(rec => rec.Id == model.Id);

                if (role == null)
                {
                    throw new Exception("Должность не найдена");
                }

                CreateModel(model, role);
                context.SaveChanges();
            }
        }
        public void Delete(RoleBindingModel model)
        {
            using (var context = new JournalDb())
            {
                var role = context.Roles.FirstOrDefault(rec => rec.Id == model.Id);

                if (role == null)
                {
                    throw new Exception("Должность не найдена");
                }

                context.Roles.Remove(role);
                context.SaveChanges();
            }
        }
        private Role CreateModel(RoleBindingModel model, Role role)
        {
            role.NameRole = model.NameRole;
            return role;
        }
    }
}
