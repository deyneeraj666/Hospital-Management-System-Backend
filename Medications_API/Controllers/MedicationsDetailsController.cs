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
    public class MedicationsDetailsController : ControllerBase
    {
        private readonly IMedicationsRepo _medicationsDetailsRepo;

        public MedicationsDetailsController(IMedicationsRepo medicationRepo)
        {
            _medicationsDetailsRepo = medicationRepo;
        }
        [HttpGet(Name = "GetMedications")]
        public List<MedicationsMaster> GetMedications()
        {
            List<MedicationsMaster> medicinelists = _medicationsDetailsRepo.GetMedications();
            //if (medicinelists.Count > 0)
            //{
            //    return medicinelists;
            //}
            //else
            //{
            //    return null;

            //}
            return medicinelists;

        }
        //[HttpGet("{id}", Name = "GetMedicationsDetailsByApptID")]
        //public async Task<ActionResult<Medications>> GetMedicationsDetailsByApptID(string id)
        //{
        //    var medicationsDetails = await _medicationsDetailsRepo.GetMedicationsDetailsByApptID(id);
        //    if (medicationsDetails != null)
        //    {
        //        return medicationsDetails;
        //    }
        //    return Ok("Data not Found");
        //}

        //[HttpGet("GetMedicationsDetailsByPatientID")]
        //public async Task<ActionResult<Medications>> GetMedicationsDetailsByPatientID(string id)
        //{
        //    var medicationsDetails = await _medicationsDetailsRepo.GetMedicationsDetailsByPatientID(id);
        //    if (medicationsDetails != null)
        //    {
        //        return medicationsDetails;
        //    }
        //    return Ok("Data not Found");
        //}
    }
}
