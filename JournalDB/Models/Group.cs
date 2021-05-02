using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JournalDB.Models
{
    public class Group
    {
        public int Id { get; set; }

        [Required]
        public string NameGroup { get; set; }

        [ForeignKey("GroupId")]
        public virtual List<User> Users { get; set; }
    }
}
