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

        [HttpGet(Name = "GetAllDiagnosis")]
        public List<DiagnosisMaster> GetAllDiagnosis()
        {
            List<DiagnosisMaster> diaglists = _diagnosisDetailsRepo.GetAllDiagnosis();
            if (diaglists.Count > 0)
            {
                return diaglists;
            }
            else
            {
                return null;

            }

        }
        [HttpGet("{name}", Name = "GetDiagosisNameByDiagnosisCode")]

        public string GetDiagosisNameByDiagnosisCode(string name)
        {
            var names = _diagnosisDetailsRepo.GetDiagosisCodeByDiagnosisNameAsync(name);
            return names;
        }
    }
}
