using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace JournalDB.Models
{
    public class Marks
    {
        [BsonId]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DisciplineId { get; set; }

        [Required]
        public decimal Mark { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [BsonIgnore]
        public virtual User User { get; set; }

        [BsonIgnore]
        public virtual Discipline Discipline { get; set; }
       
    }
}
