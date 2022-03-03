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
    public class AllergiesController : ControllerBase
    {
        private readonly IAllergyRepo _allergyRepo;

        public AllergiesController(IAllergyRepo allergyRepo)
        {
            _allergyRepo = allergyRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAllergies()
        {
            var types= await _allergyRepo.GetAllAllergies();
            return Ok(types);

        }

        //[HttpGet("{id}", Name = "GetAllergyByAllergyId")]
        //public async Task<ActionResult<Allergy>> GetAllergyByAllergyId(string id)
        //{
        //    var allergy = await _allergyRepo.GetAllergyById(id);
        //    if (allergy != null)
        //    {
        //        return allergy;
        //    }
        //    return Ok("Not Found");
        //}

        [HttpPost]
        public async Task<ActionResult<Allergy>> Add(Allergy allergy)
        {
            await _allergyRepo.AddAllergy(allergy);
            return Ok(allergy);
        }

        [HttpGet("{name}", Name = "GetAllergyNamesByAllergyTypeName")]

        public async Task<ActionResult<IEnumerable<string>>> GetAllergyNamesByAllergyTypeName(string name)
        {
            var names = await _allergyRepo.GetAllergyNamesByAllergyTypeName(name);
            return Ok(names);
        }


    }
}
