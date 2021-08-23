using Sample.Domain.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Domain.Entities
{
    [Table("installations")]
    public class Installation : BaseEntity
    {
        [Column("local_installation")]
        public string Local_Installation { get; set; }

        [Column("item_objeto")]
        public string Item_Objeto { get; set; }

        [Column("local_sup")]
        public string Local_Sup { get; set; }

        [Column("abc")]
        public string Abc { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("room")]
        public string Room { get; set; }

        [Column("work_center")]
        public string Work_Center { get; set; }

        [Column("tag")]
        public string Tag { get; set; }

        [Column("cost_center")]
        public string Cost_Center { get; set; }

        [Column("catalog_profile")]
        public string Catalog_Profile { get; set; }

        [Column("status_sys")]
        public string Status_Sys { get; set; }

        [Column("status_usu")]
        public string Status_Usu { get; set; }

        [Column("creation_date")]
        public string Creation_Date { get; set; }


    }
}