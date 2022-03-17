using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diagnoses_API.Models
{
    public class DiagnosisModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string diag_code { get; set; }

        [Required]
        public string diag_name { get; set; }

        [Required]
        public string ddate { get; set; }

        [Required]
        public string pid { get; set; }

        [Required]
        public string AppointmentId { get; set; }
    }
}
