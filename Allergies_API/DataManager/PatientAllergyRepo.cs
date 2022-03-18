using Allergies_API.DTO;
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
        public async Task<PatientAllergyDto> CreatePatientAllergy(PatientAllergyDto allergy)
        {
            var newAllergy = new PatientAllergy()
            {
                PatientId=allergy.PatientId,
                AllergyId = allergy.AllergyId,
                Allergy_Name = allergy.Allergy_Name,
                Allergy_Type = allergy.Allergy_Type,
                Allergy_Description = allergy.Allergy_Description,
                Allergy_Clinical_Info = allergy.Allergy_Clinical_Info,
                IsAllergyFatal = allergy.IsAllergyFatal
            };
            _dbContext.Patient_Allergy_Details.Add(newAllergy);
            await _dbContext.SaveChangesAsync();
            return allergy;
        }


        public async Task<PatientAllergyDto> DeletePatientAllergy(int allergyId)
        {
            PatientAllergy allergy = await _dbContext.Patient_Allergy_Details.Where(p => p.AllergyId == allergyId)
                .FirstOrDefaultAsync();
            PatientAllergyDto patientAllergyDto = new PatientAllergyDto()
            {
                PatientId=allergy.PatientId,
                AllergyId=allergy.AllergyId,
                Allergy_Name = allergy.Allergy_Name,
                Allergy_Type = allergy.Allergy_Type,
                Allergy_Description = allergy.Allergy_Description,
                Allergy_Clinical_Info = allergy.Allergy_Clinical_Info,
                IsAllergyFatal = allergy.IsAllergyFatal

            };
             _dbContext.Patient_Allergy_Details.Remove(allergy);
            await _dbContext.SaveChangesAsync();

            return patientAllergyDto;

        }

        public async Task<IEnumerable<PatientAllergyDto>> GetPatientAllergiesByPatientID(string patientId)
        {
            IEnumerable<PatientAllergyDto> allergies = await _dbContext.Patient_Allergy_Details.Where(p => p.PatientId == patientId)
                .Select(i => new PatientAllergyDto()
                {
                    PatientId = i.PatientId,
                    AllergyId = i.AllergyId,
                    Allergy_Name = i.Allergy_Name,
                    Allergy_Type = i.Allergy_Type,
                    Allergy_Description = i.Allergy_Description,
                    Allergy_Clinical_Info = i.Allergy_Clinical_Info,
                    IsAllergyFatal = i.IsAllergyFatal
                }).ToListAsync();
            return allergies;
        }


    }
}
