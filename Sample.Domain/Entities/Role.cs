using Sample.Domain.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Domain.Entities
{
    [Table("roles")]
    public class Role : BaseEntity
    {
        [Column("role")]
        public string Item {get; set; }

        [Column("description")]
        public string Description {get; set; }

        [Column("enabled")]
        public bool Enabled {get; set; }

    }
}