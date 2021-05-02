using System;
using System.ComponentModel;

namespace JournalBusinessLogic.ViewModels
{
    public class MarksViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DisciplineId { get; set; }

        [DisplayName("Оценка")]
        public decimal Mark { get; set; }

        [DisplayName("Дата выставления")]
        public DateTime Date { get; set; }

        [DisplayName("Студент")]
        public string UserName { get; set; }

        [DisplayName("Дисциплина")]
        public string DisciplineName { get; set; }
    }
}
