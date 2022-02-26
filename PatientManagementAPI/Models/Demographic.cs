using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagementAPI.Models
{
    public class Demographic
    {
        [Key]
        [JsonProperty("id")]

        public Guid Id { get; set; }
        [JsonProperty("patientId")]
        public string PatientId { get; set; }

        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("fname")]
        [Required]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty("lname")]
        public string LastName { get; set; }

        [Required]
        [JsonProperty("dob")]
        public DateTime DOB { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [Required]
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [Required]
        [JsonProperty("race")]
        public string Race { get; set; }

        [Required]
        [JsonProperty("ethnicity")]
        public string Ethnicity { get; set; }

        [Required]
        [JsonProperty("language")]
        public string LanguagesKnown { get; set; }

        [Required]
        [JsonProperty("email")]
        public string EmailId { get; set; }

        [Required]
        [JsonProperty("address")]
        public string HomeAddress { get; set; }

        [Required]
        [JsonProperty("contact")]
        public string ContactNumber { get; set; }
    }
}
