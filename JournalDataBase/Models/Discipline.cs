using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JournalDB.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required]
        public string NameDiscipline { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("DisciplineId")]
        public virtual List<Marks> Marks { get; set; }
    }
}
