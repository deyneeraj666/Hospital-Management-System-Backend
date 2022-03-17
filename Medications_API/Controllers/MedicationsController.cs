using Medications_API.Models;
using Medications_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medications_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationsController : ControllerBase
    {
        private readonly IMedicationsRepo _medicationsRepo;
        
        public MedicationsController(IMedicationsRepo medicationRepo)
        {
            _medicationsRepo = medicationRepo;
        }
        [HttpPost]
        public async Task<ActionResult<Medications>> CreateUpdateMedications(Medications medications)
        {
            try
            {
                await _medicationsRepo.CreateUpdateMedications(medications);
            }
            catch (Exception ex)
            {

            }
            return medications;


        }       

        [HttpGet("{id}", Name = "GetMedicationsDetailsByApptID")]
        public async Task<ActionResult<IEnumerable<Medications>>> GetMedicationsDetailsByApptID(string id)
        {
            var medicationsDetails = await _medicationsRepo.GetMedicationsDetailsByApptID(id);
            //if (medicationsDetails != null)
            //{
            //    return medicationsDetails;
            //}
                return Ok(medicationsDetails);
        }
        [HttpGet("GetMedicationsDetailsByPatientID")]
        public async Task<ActionResult<Medications>> GetMedicationsDetailsByPatientID(string id)
        {
            var medicationsDetails = await _medicationsRepo.GetMedicationsDetailsByPatientID(id);
            if (medicationsDetails != null)
            {
                return medicationsDetails;
            }
            return Ok("Data not Found");
        }

    }
}
