using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diagnoses_API.Models
{
    public class DiagnosisModel
    {
        
        public int Id { get; set; }

        
        public string diag_code { get; set; }

       
        public string diag_name { get; set; }

        
        public string ddate { get; set; }

        
        public string pid { get; set; }

        public int AppointmentId { get; set; }
    }
}
