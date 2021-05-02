using System.ComponentModel;

namespace JournalBusinessLogic.ViewModels
{
    public class DisciplineViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [DisplayName("Дисциплина")]
        public string NameDiscipline { get; set; }

        [DisplayName("Преподаватель")]
        public string NameUser { get; set; }
    }
}
