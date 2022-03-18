using Allergies_API.DTO;
using Allergies_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allergies_API.Repository
{
    public interface IAllergyRepo
    {
        Task<IEnumerable<string>> GetAllAllergyTypes();
        Task<AllergyDto> GetAllergyById(string allergyId);
        Task<AllergyDto> AddAllergy(AllergyDto allergy);
        Task<IEnumerable<string>> GetAllergyNamesByAllergyTypeName(string allergyType);
    }

}
