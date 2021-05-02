using JournalBusinessLogic.BindingModels;
using JournalBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace JournalBusinessLogic.Interfaces
{
    public interface IUserStorage
    {
        List<UserViewModel> GetFullList();

        UserViewModel GetElement(UserBindingModel model);

        void Insert(UserBindingModel model);

        void Update(UserBindingModel model);

        void Delete(UserBindingModel model);
    }
}
