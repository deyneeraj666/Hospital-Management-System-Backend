using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allergies_API.DTO
{
    public class AllergyDto
    {
      
        public string Allergy_Id { get; set; }
        public string Allergy_Type { get; set; }
        public string Allergy_Name { get; set; }
        public string Allergen_Source { get; set; }
        public string Allerginicity { get; set; }
        public string Iso_Forms_of_Partial_Sequence_of_Allergen { get; set; }
    }
}
