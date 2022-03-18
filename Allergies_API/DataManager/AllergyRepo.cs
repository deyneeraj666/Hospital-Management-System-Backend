using Allergies_API.DTO;
using Allergies_API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allergies_API.Repository
{
    public class AllergyRepo : IAllergyRepo
    {
        private readonly AllergyDbContext context;

        public AllergyRepo(AllergyDbContext _context)
        {
            context = _context;
        }
        public async Task<AllergyDto> AddAllergy(AllergyDto allergy)
        {
            var newAllergy = new Allergy()
            {
                Allergy_Id=allergy.Allergy_Id,
                Allergy_Name=allergy.Allergy_Name,
                Allergy_Type=allergy.Allergy_Type,
                Allergen_Source=allergy.Allergen_Source,
                Allerginicity=allergy.Allerginicity,
                Iso_Forms_of_Partial_Sequence_of_Allergen=allergy.Iso_Forms_of_Partial_Sequence_of_Allergen
            };
            context.Allergy_Master.Add(newAllergy);
            await context.SaveChangesAsync();
            return allergy;
        }

        public async Task<IEnumerable<string>> GetAllAllergyTypes()
        {
            List<string> allergyTypes = await context.Allergy_Master.Select(x => x.Allergy_Type).Distinct().ToListAsync();
            return allergyTypes;
        }

        public async Task<AllergyDto> GetAllergyById(string allergyId)
        {
            AllergyDto allergy = await context.Allergy_Master.Where(a => a.Allergy_Id == allergyId).Select(i=> new AllergyDto()
            {
                Allergy_Id=i.Allergy_Id,
                Allergy_Name=i.Allergy_Name,
                Allergy_Type = i.Allergy_Type,
                Allergen_Source = i.Allergen_Source,
                Allerginicity = i.Allerginicity,
                Iso_Forms_of_Partial_Sequence_of_Allergen = i.Iso_Forms_of_Partial_Sequence_of_Allergen

            }).FirstOrDefaultAsync();
            return allergy;
        }

        public async Task<IEnumerable<string>> GetAllergyNamesByAllergyTypeName(string allergyType)
        {
            List<string> allergyNames = await context.Allergy_Master.Where(a => a.Allergy_Type == allergyType).Select(x=>x.Allergy_Name).Distinct().ToListAsync();
            return allergyNames;
        }
    }
}
