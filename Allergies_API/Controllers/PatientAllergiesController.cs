using Allergies_API.DTO;
using Allergies_API.Model;
using Allergies_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allergies_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAllergiesController : ControllerBase
    {
        private readonly IPatientAllergyRepo _allergyRepo;

        public PatientAllergiesController(IPatientAllergyRepo allergyRepo)
        {
            _allergyRepo = allergyRepo;
        }

        [HttpPost]
        public async Task<ActionResult<PatientAllergyDto>> Add(PatientAllergyDto allergy)
        {
            await _allergyRepo.CreatePatientAllergy(allergy);
            return Ok(allergy);
        }

        [HttpGet("{patientId}", Name = "GetPatientAllergies")]
        public async Task<ActionResult<IEnumerable<PatientAllergyDto>>> GetPatientAllergies(string patientId)
        {
            IEnumerable<PatientAllergyDto> patientAllergies = await _allergyRepo.GetPatientAllergiesByPatientID(patientId);
            return Ok(patientAllergies);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PatientAllergyDto>> DeletePatientAllergy(int id)
        {
            PatientAllergyDto patientAllergy = await _allergyRepo.DeletePatientAllergy(id);
            return Ok(patientAllergy);
        }
    }
}
