using JournalBusinessLogic.BindingModels;
using JournalBusinessLogic.Interfaces;
using JournalBusinessLogic.ViewModels;
using JournalDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JournalDB.Implements
{
    public class GroupStorage : IGroupStorage
    {
        public List<GroupViewModel> GetFullList()
        {
            using (var context = new JournalDb())
            {
                return context.Groups
                    .Select(rec => new GroupViewModel
                    {
                        Id = rec.Id,
                        NameGroup = rec.NameGroup
                    })
                    .ToList();
            }
        }
        public GroupViewModel GetElement(GroupBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new JournalDb())
            {
                var group = context.Groups
                    .FirstOrDefault(rec => rec.NameGroup == model.NameGroup ||
                    rec.Id == model.Id);

                return group != null ?
                    new GroupViewModel
                    {
                        Id = group.Id,
                        NameGroup = group.NameGroup
                    } :
                    null;
            }
        }
        public void Insert(GroupBindingModel model)
        {
            using (var context = new JournalDb())
            {
                context.Groups.Add(CreateModel(model, new Group()));
                context.SaveChanges();
            }
        }
        public void Update(GroupBindingModel model)
        {
            using (var context = new JournalDb())
            {
                var group = context.Groups.FirstOrDefault(rec => rec.Id == model.Id);

                if (group == null)
                {
                    throw new Exception("Группа не найдена");
                }

                CreateModel(model, group);
                context.SaveChanges();
            }
        }
        public void Delete(GroupBindingModel model)
        {
            using (var context = new JournalDb())
            {
                var group = context.Groups.FirstOrDefault(rec => rec.Id == model.Id);

                if (group == null)
                {
                    throw new Exception("Группа не найдена");
                }

                context.Groups.Remove(group);
                context.SaveChanges();
            }
        }
        private Group CreateModel(GroupBindingModel model, Group group)
        {
            group.NameGroup = model.NameGroup;
            return group;
        }
    }
}
