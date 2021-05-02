using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JournalDB.Models
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int? GroupId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
        public virtual Role Role { get; set; }
        public virtual Group? Group { get; set; }

        [ForeignKey("UserId")]
        public virtual List<Discipline> Disciplines { get; set; }

        [ForeignKey("UserId")]
        public virtual List<Marks> Marks { get; set; }
    }
}
