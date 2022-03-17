using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientManagementAPI.DTO;
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
    public class EmergencyDetailsController : ControllerBase
    {
        private readonly IEmergencyRepo _emergencyRepo;

        public EmergencyDetailsController(IEmergencyRepo emergencyRepo)
        {
            _emergencyRepo = emergencyRepo;
        }

        [HttpGet("{id}", Name = "GetEmergencyDetailByPatientId")]
        public async Task<ActionResult<EmergencyContactDto>> GetEmergencyDetailByPatientId(string id)
        {
            var emergency = await _emergencyRepo.GetEmergencyContactByPatientID(id);
            if (emergency != null)
            {
                return emergency;
            }
            return Ok("Not Found");
        }

        [HttpPost]
        public async Task<ActionResult<EmergencyContactDto>> Create(EmergencyContactDto emergency)
        {
            await _emergencyRepo.CreateUpdateEmergencyContact(emergency);
            return emergency;


        }
    }
}
