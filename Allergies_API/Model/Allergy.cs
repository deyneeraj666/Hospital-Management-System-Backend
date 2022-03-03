using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Allergies_API.Model
{
    public class Allergy
    {
        [Key]
        [MaxLength(50)]
        public string Allergy_Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Allergy_Type { get; set; }

        [Required]
        [MaxLength(50)]
        public string Allergy_Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Allergen_Source { get; set; }

        [Required]
        [MaxLength(50)]
        public string Allerginicity { get; set; }

        [Required]
        [MaxLength(100)]
        public string Iso_Forms_of_Partial_Sequence_of_Allergen { get; set; }
    }
}
