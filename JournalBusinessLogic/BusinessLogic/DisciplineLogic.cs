using JournalBusinessLogic.BindingModels;
using JournalBusinessLogic.Interfaces;
using JournalBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace JournalBusinessLogic.BusinessLogic
{
    public class DisciplineLogic
    {
        private readonly IDisciplineStorage disciplineStorage;
        private readonly IUserStorage userStorage;

        public DisciplineLogic(IDisciplineStorage disciplineStorage, IUserStorage userStorage)
        {
            this.disciplineStorage = disciplineStorage;
            this.userStorage = userStorage;
        }

        public List<DisciplineViewModel> Read(DisciplineBindingModel model)
        {
            if (model == null)
            {
                return disciplineStorage.GetFullList();
            }

            return new List<DisciplineViewModel> { disciplineStorage.GetElement(model) };
        }

        public void CreateOrUpdate(DisciplineBindingModel model)
        {
            var discipline = disciplineStorage.GetElement(
                new DisciplineBindingModel
                {
                    NameDiscipline = model.NameDiscipline
                });

            var user = userStorage.GetElement(
                new UserBindingModel
                {
                    Id = model.UserId
                });

            if (discipline != null && discipline.Id != model.Id)
            {
                throw new Exception("Уже есть такая дисциплина");
            }

            if(user.NameRole != "Преподаватель")
            {
                throw new Exception("Не выбран преподаватель");
            }

            if (model.Id.HasValue)
            {
                disciplineStorage.Update(model);
            }
            else
            {
                disciplineStorage.Insert(model);
            }
        }

        public void Delete(DisciplineBindingModel model)
        {
            var discipline = disciplineStorage.GetElement(
                new DisciplineBindingModel
                {
                    Id = model.Id
                });

            if (discipline == null)
            {
                throw new Exception("Дисциплина не найден");
            }

            disciplineStorage.Delete(model);
        }
    }
}
