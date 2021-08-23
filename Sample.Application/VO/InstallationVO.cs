using Sample.Hypermedia;
using Sample.Hypermedia.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sample.Application.VO
{
    public class InstallationVO : ISupportsHyperMedia
    {
        [Required]
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [Required]
        [JsonPropertyName("local_installation")]
        public string Local_Installation { get; set; }

        [Required]
        [JsonPropertyName("item_objeto")]
        public string Item_Objeto { get; set; }


        [Required]
        [JsonPropertyName("local_sup")]
        public string Local_Sup { get; set; }


        [Required]
        [JsonPropertyName("abc")]
        public string Abc { get; set; }


        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }


        [Required]
        [JsonPropertyName("room")]
        public string Room { get; set; }


        [Required]
        [JsonPropertyName("work_center")]
        public string Work_Center { get; set; }


        [Required]
        [JsonPropertyName("tag")]
        public string Tag { get; set; }


        [Required]
        [JsonPropertyName("cost_center")]
        public string Cost_Center { get; set; }

        
        [Required]
        [JsonPropertyName("catalog_profile")]
        public string Catalog_Profile { get; set; }


        [Required]
        [JsonPropertyName("status_sys")]
        public string Status_Sys { get; set; }


        [Required]
        [JsonPropertyName("status_usu")]
        public string Status_Usu { get; set; }

        [Required]
        [JsonPropertyName("creation_date")]
        public string Creation_Date { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}