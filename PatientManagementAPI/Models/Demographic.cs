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
        public Guid Id { get; set; }
        public string PatientId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        //public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Race { get; set; }

        [Required]
        public string Ethnicity { get; set; }

        [Required]
        public string LanguagesKnown { get; set; }

        [Required]
        public string EmailId { get; set; }

        [Required]
        public string HomeAddress { get; set; }

        [Required]
        public string ContactNumber { get; set; }
    }
}
