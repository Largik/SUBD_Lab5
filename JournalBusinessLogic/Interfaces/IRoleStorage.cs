using JournalBusinessLogic.BindingModels;
using JournalBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace JournalBusinessLogic.Interfaces
{
    public interface IRoleStorage
    {
        List<RoleViewModel> GetFullList();

        RoleViewModel GetElement(RoleBindingModel model);

        void Insert(RoleBindingModel model);

        void Update(RoleBindingModel model);

        void Delete(RoleBindingModel model);
    }
}
