namespace JournalBusinessLogic.BindingModels
{
    public class UserBindingModel
    {
        public int? Id { get; set; }
        public string UserName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int? GroupId { get; set; }
    }
}
