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
    public class DiagnosisController : ControllerBase
    {

        private readonly IDiagnosisRepo _diagnosisRepo;
        public DiagnosisController(IDiagnosisRepo diagnosisRepo)
        {
            _diagnosisRepo = diagnosisRepo;
        }
        [HttpPost]

        public async Task<ActionResult<DiagnosisModel>> AddDiagnosisDetails(DiagnosisModel diagnosis)
        {
            try
            {
                await _diagnosisRepo.AddDiagnosisDetails(diagnosis);
            }
            catch (Exception ex)
            {

            }
            return diagnosis;


        }
        [HttpGet("{apptid}", Name = "GetDiagDetailsByApptID")]
        public async Task<ActionResult<IEnumerable<DiagnosisModel>>> GetDiagDetailsByApptID(string apptid)
        {
            var diagnosisDetails = await _diagnosisRepo.GetDiagDetailsByApptID(apptid);
            //if (diagnosisDetails != null)
            //{
            //    return diagnosisDetails;
            //}
            return Ok(diagnosisDetails);
        }
        [HttpGet("GetDiagDetailsByPatientID")]
        public async Task<ActionResult<DiagnosisModel>> GetDiagDetailsByPatientId(string pid)
        {
            var diagnosisDetails = await _diagnosisRepo.GetDiagDetailsByPatientID(pid);
            if (diagnosisDetails != null)
            {
                return diagnosisDetails;
            }
            return Ok("Data not Found");
        }
                
        [HttpDelete]
        public void DeleteDiagDetails(string patientId)
        {
            _diagnosisRepo.DeleteDiagDetails(patientId);
            
            
        }
        
    }
}
