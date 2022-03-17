using Diagnoses_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diagnoses_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisDetailsController : Controller
    {
        private readonly IDiagnosisRepo _diagnosisDetailsRepo;
        public DiagnosisDetailsController(IDiagnosisRepo diagnosisRepo)
        {
            _diagnosisDetailsRepo = diagnosisRepo;
        }
        [HttpGet("{apptid}", Name = "GetDiagDetailsByApptID")]
        public async Task<ActionResult<DiagnosisModel>> GetDiagDetailsByApptID(string apptid)
        {
            var diagnosisDetails = await _diagnosisDetailsRepo.GetDiagDetailsByApptID(apptid);
            if (diagnosisDetails != null)
            {
                return diagnosisDetails;
            }
            return Ok("Data not Found");
        }
        [HttpGet("GetDiagDetailsByPatientID")]
        public async Task<ActionResult<DiagnosisModel>> GetDiagDetailsByPatientId(string pid)
        {
            var diagnosisDetails = await _diagnosisDetailsRepo.GetDiagDetailsByPatientID(pid);
            if (diagnosisDetails != null)
            {
                return diagnosisDetails;
            }
            return Ok("Data not Found");
        }
    }
}
