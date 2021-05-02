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
    public class MarksStorage : IMarksStorage
    {
        public List<MarksViewModel> GetFullList()
        {
            using (var context = new JournalDb())
            {
                return context.Marks
                    .Select(rec => new MarksViewModel
                    {
                        Id = rec.Id,
                        UserId = rec.UserId,
                        UserName = rec.User.UserName,
                        DisciplineId = rec.DisciplineId,
                        DisciplineName = rec.Discipline.NameDiscipline,
                        Mark = rec.Mark,
                        Date = rec.Date,
                    })
                    .ToList();
            }
        }

        public List<MarksViewModel> GetFilteredList(MarksBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new JournalDb())
            {
                return context.Marks
                    .Include(rec => rec.User)
                    .Include(rec => rec.Discipline)
                    .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.Date.Date == model.Date.Date)
                    || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.Date.Date >= model.DateFrom.Value.Date && rec.Date.Date <= model.DateTo.Value.Date))
                    .ToList()
                    .Select(rec => new MarksViewModel
                    {
                        Id = rec.Id,
                        UserId = rec.UserId,
                        DisciplineId = rec.DisciplineId,
                        UserName = rec.User.UserName,
                        DisciplineName = rec.Discipline.NameDiscipline,
                        Mark = rec.Mark,
                        Date = rec.Date,
                    })
                    .ToList();
            }
        }

        public MarksViewModel GetElement(MarksBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new JournalDb())
            {
                var mark = context.Marks
                    .Include(rec => rec.User)
                    .Include(rec => rec.Discipline)
                    .FirstOrDefault(rec => rec.Id == model.Id);

                return mark != null ?
                    new MarksViewModel
                    {
                        Id = mark.Id,
                        UserId = mark.UserId,
                        UserName = mark.User.UserName,
                        DisciplineId = mark.DisciplineId,
                        DisciplineName = mark.Discipline.NameDiscipline,
                        Mark = mark.Mark,
                        Date = mark.Date,
                    } :
                    null;
            }
        }
        public void Insert(MarksBindingModel model)
        {
            using (var context = new JournalDb())
            {
                context.Marks.Add(CreateModel(model, new Marks()));
                context.SaveChanges();
            }
        }
        public void Update(MarksBindingModel model)
        {
            using (var context = new JournalDb())
            {
                var mark = context.Marks.FirstOrDefault(rec => rec.Id == model.Id);

                if (mark == null)
                {
                    throw new Exception("Оценка не найдена");
                }

                CreateModel(model, mark);
                context.SaveChanges();
            }
        }
        public void Delete(MarksBindingModel model)
        {
            using (var context = new JournalDb())
            {
                var mark = context.Marks.FirstOrDefault(rec => rec.Id == model.Id);

                if (mark == null)
                {
                    throw new Exception("Оценка не найдена");
                }

                context.Marks.Remove(mark);
                context.SaveChanges();
            }
        }
        private Marks CreateModel(MarksBindingModel model, Marks mark)
        {
            mark.Mark = model.Mark;
            mark.Date = model.Date;
            mark.UserId = model.UserId;
            mark.DisciplineId = model.DisciplineId;
            return mark;
        }
    }
}
