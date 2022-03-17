using Microsoft.AspNetCore.Mvc;
using Procedures_API.Models;
using Procedures_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procedures_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProceduresController : ControllerBase
    {
        private readonly IProceduresRepo _proceduresRepo;
        public ProceduresController(IProceduresRepo proceduresRepo)
        {
            _proceduresRepo = proceduresRepo;
           // GetallProcedures();
        }
        [HttpPost]

        public async Task<ActionResult<ProceduresModel>> CreateUpdateProcedures(ProceduresModel procedure)
        {
            try
            {
                await _proceduresRepo.CreateUpdateProcedures(procedure);
            }
            catch(Exception ex)
            {
                
            }
            return procedure;



        }
        [HttpGet("{id}", Name = "GetProcDetailsByPatientId")]
        public async Task<ActionResult<ProceduresModel>> GeProceduresDetailsByPatientID(string id)
        {
            var proceduresDetails = await _proceduresRepo.GeProceduresDetailsByPatientID(id);
            if (proceduresDetails != null)
            {
                return proceduresDetails;
            }
            return Ok("Data not Found");
        }
        [HttpGet( Name="GetallProcedures")]
        public List<ProcedureMaster> GetallProcedures()
        {
            List<ProcedureMaster> Procedurelists =  _proceduresRepo.GetProcedures();
            if (Procedurelists.Count > 0)
            {
                return Procedurelists;
            }
            else
            {
                return null;

            }
          
        }
        [HttpGet("{id}", Name = "GeProceduresDetailsByApptID")]
        public async Task<ActionResult<ProceduresModel>> GeProceduresDetailsByApptID(string id)
        {
            var proceduresDetails = await _proceduresRepo.GeProceduresDetailsByApptID(id);
            if (proceduresDetails != null)
            {
                return proceduresDetails;
            }
            return Ok("Data not Found");
        }
    }
}
