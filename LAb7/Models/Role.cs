using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JournalDB.Models
{
    public class Role
    {
        [BsonId]
        public int Id { get; set; }

        [Required]
        public string NameRole { get; set; }

        [BsonIgnore]
        [ForeignKey("RoleId")]
        public virtual List<User> Users { get; set; }
    }
}
