using Allergies_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allergies_API.Repository
{
    public interface IPatientAllergyRepo
    {
        Task<IEnumerable<PatientAllergy>> GetPatientAllergiesByPatientID(string patientId);
        Task<PatientAllergy> CreatePatientAllergy(PatientAllergy allergy);
        Task<PatientAllergy> DeletePatientAllergy(int allergyId);
        
    }
}
