using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medications_API.Models
{
    public class Medications
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string PatientId { get; set; }
        [Required]
        public string AppointmentId { get; set; }
        [Required]
        public string DrugName { get; set; }

        [Required]
        public string Strength { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Frequency { get; set; }
        [Required]
        public string Form { get; set; }
        [Required]
        public string Quantity { get; set; }
        [Required]
        public string Notes { get; set; }
    }
}
