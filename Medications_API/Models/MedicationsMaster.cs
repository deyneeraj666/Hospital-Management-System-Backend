using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medications_API.Models
{
    public class MedicationsMaster
    {
        [Key]
        public string DrugID { get; set; }
        [Required]
        public string DrugName { get; set; }
        [Required]
        public string DrugGenericName { get; set; }
        [Required]
        public string DrugBrandName { get; set; }
        [Required]
        public string DrugForm { get; set; }
        [Required]
        public string DrugStrength { get; set; }
    }
}
