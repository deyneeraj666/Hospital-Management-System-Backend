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
        public async Task<Allergy> AddAllergy(Allergy allergy)
        {
            if (allergy == null)
            {
                throw new ArgumentNullException(nameof(allergy));
            }
            context.Allergy_Master.Add(allergy);
            await context.SaveChangesAsync();
            return allergy;
        }

        public async Task<IEnumerable<string>> GetAllAllergyTypes()
        {
            List<string> allergyTypes = await context.Allergy_Master.Select(x => x.Allergy_Type).Distinct().ToListAsync();
            return allergyTypes;
        }

        public async Task<Allergy> GetAllergyById(string allergyId)
        {
            Allergy allergy = await context.Allergy_Master.Where(a => a.Allergy_Id == allergyId).FirstOrDefaultAsync();
            return allergy;
        }

        public async Task<IEnumerable<string>> GetAllergyNamesByAllergyTypeName(string allergyType)
        {
            List<string> allergyNames = await context.Allergy_Master.Where(a => a.Allergy_Type == allergyType).Select(x=>x.Allergy_Name).Distinct().ToListAsync();
            return allergyNames;
        }
    }
}
