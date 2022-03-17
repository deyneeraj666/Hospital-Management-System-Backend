using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Procedures_API.Models
{
    public class ProcedureMaster
    {
       
        [Key]
        public string ProcedureCode { get; set; }
        [Required]
        public string ProcedureName { get; set; }
    }
}
