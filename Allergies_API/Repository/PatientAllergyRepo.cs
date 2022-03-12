using Allergies_API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allergies_API.Repository
{
    public class PatientAllergyRepo : IPatientAllergyRepo
    {
        private readonly AllergyDbContext _dbContext;

        public PatientAllergyRepo(AllergyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PatientAllergy> CreatePatientAllergy(PatientAllergy allergy)
        {
            if (allergy == null)
            {
                throw new ArgumentNullException(nameof(allergy));
            }
            _dbContext.Patient_Allergy_Details.Add(allergy);
            await _dbContext.SaveChangesAsync();
            return allergy;
        }


        public async Task<PatientAllergy> DeletePatientAllergy(int allergyId)
        {
            PatientAllergy patientAllergy = await _dbContext.Patient_Allergy_Details.FirstOrDefaultAsync(a => a.AllergyId == allergyId);
            _dbContext.Patient_Allergy_Details.Remove(patientAllergy);
            await _dbContext.SaveChangesAsync();
            return patientAllergy;
        }

        public async Task<IEnumerable<PatientAllergy>> GetPatientAllergiesByPatientID(string patientId)
        {
            IEnumerable<PatientAllergy> allergies = await _dbContext.Patient_Allergy_Details.Where(p => p.PatientId == patientId).ToListAsync();
            return allergies;
        }

      
    }
}
