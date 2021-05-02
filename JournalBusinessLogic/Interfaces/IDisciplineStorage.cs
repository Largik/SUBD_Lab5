using JournalBusinessLogic.BindingModels;
using JournalBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace JournalBusinessLogic.Interfaces
{
    public interface IDisciplineStorage
    {
        List<DisciplineViewModel> GetFullList();

        DisciplineViewModel GetElement(DisciplineBindingModel model);

        void Insert(DisciplineBindingModel model);

        void Update(DisciplineBindingModel model);

        void Delete(DisciplineBindingModel model);
    }
}
