using System.ComponentModel;

namespace JournalBusinessLogic.ViewModels
{
    public class GroupViewModel
    {
        public int Id { get; set; }

        [DisplayName("Наименование группы")]
        public string NameGroup { get; set; }
    }
}
