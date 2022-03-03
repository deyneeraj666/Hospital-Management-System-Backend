using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Allergies_API.Model
{
    public class PatientAllergy
    {
        [Key]
        public Guid Id { get; set; }
        public string PatientId { get; set; }
        public string AllergyId { get; set; }

        [MaxLength(50)]
        public string Allergy_Type { get; set; }

        [MaxLength(50)]
        public string Allergy_Name { get; set; }

        [MaxLength(500)]
        public string Allergy_Description { get; set; }

        [MaxLength(500)]
        public string Allergy_Clinical_Info { get; set; }
        public string IsAllergyFatal { get; set; }
    }
}
