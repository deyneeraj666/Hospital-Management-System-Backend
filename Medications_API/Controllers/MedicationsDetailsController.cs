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

            return medicinelists;

        }
        [HttpGet("{name}", Name = "GetDrugDetailsByDrugNameAsync")]
        public List<MedicationsMaster> GetDrugDetailsByDrugNameAsync( string name)
        {
            List<MedicationsMaster> medicinelists = _medicationsDetailsRepo.GetDrugDetailsByDrugNameAsync(name);

            return medicinelists;

        }

    }
}
