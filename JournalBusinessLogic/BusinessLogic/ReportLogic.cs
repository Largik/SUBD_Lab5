using JournalBusinessLogic.BindingModels;
using JournalBusinessLogic.Interfaces;
using JournalBusinessLogic.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace JournalBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IMarksStorage _reportStorage;

        public ReportLogic(IMarksStorage logic)
        {
            _reportStorage = logic;
        }

        public List<MarksViewModel> GetOrders(ReportBindingModel model)
        {
            return _reportStorage.GetFilteredList(new MarksBindingModel
            {
                DateFrom =
           model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new MarksViewModel
            {
                Date = x.Date,
                UserName = x.UserName,
                Mark = x.Mark,
                DisciplineName = x.DisciplineName
            })
           .ToList();
        }
    }
}
