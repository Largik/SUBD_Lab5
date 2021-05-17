using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JournalDB.Models
{
    public class Discipline
    {
        [BsonId]
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required]
        public string NameDiscipline { get; set; }
        
        [BsonIgnore]
        public virtual User User { get; set; }

        [BsonIgnore]
        [ForeignKey("DisciplineId")]
        public virtual List<Marks> Marks { get; set; }
    }
}
