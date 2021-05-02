using System.ComponentModel;

namespace JournalBusinessLogic.ViewModels
{
    public class RoleViewModel
    {
        public int Id { get; set; }

        [DisplayName("Наименование должности")]
        public string NameRole { get; set; }
    }
}
