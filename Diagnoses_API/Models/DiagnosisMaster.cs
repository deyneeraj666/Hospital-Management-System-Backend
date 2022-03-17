using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diagnoses_API.Models
{
    public class DiagnosisMaster
    {
        [Key]
        public string diag_code { get; set; }

        [Required]
        public string diag_name { get; set; }
    }
}
