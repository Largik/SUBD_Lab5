using JournalBusinessLogic.BindingModels;
using JournalBusinessLogic.Interfaces;
using JournalBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace JournalBusinessLogic.BusinessLogic
{
    public class UserLogic
    {
        private readonly IUserStorage userStorage;

        public UserLogic(IUserStorage userStorage)
        {
            this.userStorage = userStorage;
        }

        public List<UserViewModel> Read(UserBindingModel model)
        {
            if (model == null)
            {
                return userStorage.GetFullList();
            }

            return new List<UserViewModel> { userStorage.GetElement(model) };
        }

        public void CreateOrUpdate(UserBindingModel model)
        {
            var user = userStorage.GetElement(
                new UserBindingModel
                {
                    Login = model.Login
                });

            if (user != null && user.Id != model.Id)
            {
                throw new Exception("Уже есть пользователь с таким логином");
            }

            if (model.Id.HasValue)
            {
                userStorage.Update(model);
            }
            else
            {
                userStorage.Insert(model);
            }
        }

        public void Delete(UserBindingModel model)
        {
            var user = userStorage.GetElement(
                new UserBindingModel
                {
                    Id = model.Id
                });

            if (user == null)
            {
                throw new Exception("Пользователь не найден");
            }

            userStorage.Delete(model);
        }
    }
}
