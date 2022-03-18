using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allergies_API.DTO
{
    public class PatientAllergyDto
    {
      
        public int AllergyId { get; set; }
        public string PatientId { get; set; }
        public string Allergy_Type { get; set; }
        public string Allergy_Name { get; set; }
        public string Allergy_Description { get; set; }
        public string Allergy_Clinical_Info { get; set; }
        public string IsAllergyFatal { get; set; }
    }
}
