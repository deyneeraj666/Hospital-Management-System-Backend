using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientManagementAPI.Models;
using PatientManagementAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemographicsController : ControllerBase
    {
        private readonly IDemographicRepo _demographicRepo;

        public DemographicsController(IDemographicRepo demogrphicRepo)
        {
            _demographicRepo = demogrphicRepo;
        }


        [HttpGet("{id}", Name = "GetDemographicByPatientId")]
        public async Task<ActionResult<Demographic>> GetDemographicByPatientId(string id)
        {
            var demographic = await _demographicRepo.GetDemographicByPatientID(id);
            if (demographic != null)
            {
                return demographic;
            }
            return Ok("Not");
        }

        [HttpPost]

        public async Task<ActionResult<Demographic>> Create(Demographic demographic)
        {
            await _demographicRepo.CreateUpdateDemographic(demographic);
            return demographic;


        }
    }
}
