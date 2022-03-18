using Allergies_API.DTO;
using Allergies_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allergies_API.Repository
{
    public interface IPatientAllergyRepo
    {
        Task<IEnumerable<PatientAllergyDto>> GetPatientAllergiesByPatientID(string patientId);
        Task<PatientAllergyDto> CreatePatientAllergy(PatientAllergyDto allergy);
        Task<PatientAllergyDto> DeletePatientAllergy(int allergyId);
        
    }
}
