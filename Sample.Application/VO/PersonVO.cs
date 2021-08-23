using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Sample.Hypermedia;
using Sample.Hypermedia.Abstract;

namespace Sample.Application.VO
{
    public class PersonVO : ISupportsHyperMedia
    {
        [Required]
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [Required]
        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }

        [Required]
        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        // For Ignore
        //[JsonIgnore]
        [Required]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [Required]
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [Required]
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }
        
        public List<HyperMediaLink> Links  { get; set; } = new List<HyperMediaLink>();
    }
}