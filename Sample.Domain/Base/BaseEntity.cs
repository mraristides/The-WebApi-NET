using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Domain.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}