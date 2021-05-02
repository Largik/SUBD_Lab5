using System;

namespace JournalBusinessLogic.BindingModels
{
    public class MarksBindingModel
    {
        public int? Id { get; set; }
        public decimal Mark { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int DisciplineId { get; set; }
        public DateTime? DateTo { get; set; }
        public DateTime? DateFrom { get; set; }
    }
}
