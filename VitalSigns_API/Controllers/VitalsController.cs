using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VitalSigns_API.DTO;
using VitalSigns_API.Repository;

namespace VitalSigns_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitalsController : ControllerBase
    {
        private readonly IVitalRepo _vitalRepo;

        public VitalsController(IVitalRepo vitalRepo)
        {
            _vitalRepo = vitalRepo;
        }

        [HttpPost]
        public async Task<ActionResult<VitalDto>> Create(VitalDto vital)
        {
            await _vitalRepo.CreateUpdatePatientVital(vital);
            return vital;
        }

        [HttpGet("{id}", Name = "GetPatientVitalByAppointmentId")]
        public async Task<ActionResult<VitalDto>> GetPatientVitalByAppointmentId(int id)
        {
            var vital = await _vitalRepo.GetPatientVitalByAppointmentId(id);
            if (vital != null)
            {
                return vital;
            }
            return Ok("Not Found");
        }
    }
}
