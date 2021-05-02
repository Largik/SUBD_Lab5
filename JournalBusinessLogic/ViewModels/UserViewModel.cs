using System.ComponentModel;

namespace JournalBusinessLogic.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int? GroupId { get; set; }

        [DisplayName("Пользователь")]
        public string UserName { get; set; }

        [DisplayName("Логин")]
        public string Login { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }

        [DisplayName("Должность")]
        public string NameRole { get; set; }

        [DisplayName("Группа")]
        public string NameGroup { get; set; }
    }
}
