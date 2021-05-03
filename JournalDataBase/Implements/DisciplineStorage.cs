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
    public class DisciplineStorage : IDisciplineStorage
    {
        public List<DisciplineViewModel> GetFullList()
        {
            using (var context = new JournalDb())
            {
                return context.Disciplines
                    .Select(rec => new DisciplineViewModel
                    {
                        Id = rec.Id,
                        NameDiscipline = rec.NameDiscipline,
                        UserId = rec.UserId,
                        NameUser = rec.User.UserName
                    })
                    .ToList();
            }
        }
        public DisciplineViewModel GetElement(DisciplineBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new JournalDb())
            {
                var discipline = context.Disciplines
                    .Include(rec => rec.User)
                    .FirstOrDefault(rec => rec.NameDiscipline == model.NameDiscipline ||
                    rec.Id == model.Id);

                return discipline != null ?
                    new DisciplineViewModel
                    {
                        Id = discipline.Id,
                        NameDiscipline = discipline.NameDiscipline,
                        UserId = discipline.UserId,
                        NameUser = discipline.User.UserName
                    } :
                    null;
            }
        }
        public void Insert(DisciplineBindingModel model)
        {
            using (var context = new JournalDb())
            {
                context.Disciplines.Add(CreateModel(model, new Discipline()));
                context.SaveChanges();
            }
        }
        public void Update(DisciplineBindingModel model)
        {
            using (var context = new JournalDb())
            {
                var discipline = context.Disciplines.FirstOrDefault(rec => rec.Id == model.Id);

                if (discipline == null)
                {
                    throw new Exception("Дисциплина не найдена");
                }

                CreateModel(model, discipline);
                context.SaveChanges();
            }
        }
        public void Delete(DisciplineBindingModel model)
        {
            using (var context = new JournalDb())
            {
                var discipline = context.Disciplines.FirstOrDefault(rec => rec.Id == model.Id);

                if (discipline == null)
                {
                    throw new Exception("Дисциплина не найдена");
                }

                context.Disciplines.Remove(discipline);
                context.SaveChanges();
            }
        }
        private Discipline CreateModel(DisciplineBindingModel model, Discipline discipline)
        {
            discipline.NameDiscipline = model.NameDiscipline;
            discipline.UserId = model.UserId;
            return discipline;
        }
    }
}
