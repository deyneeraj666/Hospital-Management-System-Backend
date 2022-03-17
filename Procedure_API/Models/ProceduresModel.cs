using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Procedures_API.Models
{
    public class ProceduresModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string PatientId { get; set; }
        [Required]
        public string AppointmentId { get; set; }

        [Required]
        public string ProcedureName { get; set; }

        [Required]
        public string ProcedureCode { get; set; }

        [Required]
        public string Date { get; set; }
    }
}
