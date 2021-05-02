using JournalBusinessLogic.BindingModels;
using JournalBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace JournalBusinessLogic.Interfaces
{
    public interface IGroupStorage
    {
        List<GroupViewModel> GetFullList();

        GroupViewModel GetElement(GroupBindingModel model);

        void Insert(GroupBindingModel model);

        void Update(GroupBindingModel model);

        void Delete(GroupBindingModel model);
    }
}
