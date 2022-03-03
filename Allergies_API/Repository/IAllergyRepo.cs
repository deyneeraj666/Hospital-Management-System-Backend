using Allergies_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allergies_API.Repository
{
    public interface IAllergyRepo
    {
        Task<IEnumerable<string>> GetAllAllergies();
        Task<Allergy> GetAllergyById(string allergyId);
        Task<Allergy> AddAllergy(Allergy allergy);
        Task<IEnumerable<string>> GetAllergyNamesByAllergyTypeName(string allergyType);
    }

}
