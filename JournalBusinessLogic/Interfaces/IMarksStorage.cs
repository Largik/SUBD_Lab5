using JournalBusinessLogic.BindingModels;
using JournalBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace JournalBusinessLogic.Interfaces
{
    public interface IMarksStorage
    {
        List<MarksViewModel> GetFullList();

        List<MarksViewModel> GetFilteredList(MarksBindingModel model);

        MarksViewModel GetElement(MarksBindingModel model);

        void Insert(MarksBindingModel model);

        void Update(MarksBindingModel model);

        void Delete(MarksBindingModel model);
    }
}
