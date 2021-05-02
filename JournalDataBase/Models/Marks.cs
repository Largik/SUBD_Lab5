using System;
using System.ComponentModel.DataAnnotations;

namespace JournalDB.Models
{
    public class Marks
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DisciplineId { get; set; }

        [Required]
        public decimal Mark { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual User User { get; set; }
        public virtual Discipline Discipline { get; set; }
       
    }
}
