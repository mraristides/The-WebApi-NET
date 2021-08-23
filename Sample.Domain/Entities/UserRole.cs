using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Domain.Entities
{
    [Table("user_has_roles")]
    public class UserRole
    {
        [Key]
        [Column("id")]
        public long Id {get; set; }

        [Column("user_id")]
        public long User_Id { get; set; }

        [Column("role_id")]
        public long Role_Id {get; set; }
        
        [NotMapped]
        public string Role { get; set; }

        [NotMapped]
        public string Description {get; set; }

        [NotMapped]
        public bool Enabled {get; set; }

    }
}