using JournalBusinessLogic.BindingModels;
using JournalBusinessLogic.Interfaces;
using JournalBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace JournalBusinessLogic.BusinessLogic
{
    public class MarksLogic
    {
        private readonly IMarksStorage markStorage;
        private readonly IUserStorage userStorage;
        public MarksLogic(IMarksStorage markStorage, IUserStorage userStorage)
        {
            this.markStorage = markStorage;
            this.userStorage = userStorage;
        }

        public List<MarksViewModel> Read(MarksBindingModel model)
        {
            if (model == null)
            {
                return markStorage.GetFullList();
            }

            return new List<MarksViewModel> { markStorage.GetElement(model) };
        }

        public void CreateOrUpdate(AddMarkBindingModel model)
        {
            var user = userStorage.GetElement(
                new UserBindingModel
                {
                    Id = model.UserId
                });
            if(user.NameRole != "Студент")
            {
                throw new Exception("Не выбран студент");
            }
            markStorage.Insert(new MarksBindingModel
            {
                UserId = model.UserId,
                DisciplineId = model.DisciplineId,
                Mark = model.Mark,
                Date = DateTime.Now
            });
        }

        public void Delete(MarksBindingModel model)
        {
            var mark = markStorage.GetElement(
                new MarksBindingModel
                {
                    Id = model.Id
                });

            if (mark == null)
            {
                throw new Exception("Оценка не найдена");
            }

            markStorage.Delete(model);
        }
    }
}
