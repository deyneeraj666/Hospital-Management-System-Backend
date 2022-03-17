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
        [HttpGet("GetProcDetailsByPatientId")]
        public async Task<ActionResult<ProceduresModel>> GeProceduresDetailsByPatientID(string id)
        {
            var proceduresDetails = await _proceduresRepo.GeProceduresDetailsByPatientID(id);
            if (proceduresDetails != null)
            {
                return proceduresDetails;
            }
            return Ok("Data not Found");
        }
        
        [HttpGet("{id}", Name = "GeProceduresDetailsByApptID")]
        public async Task<ActionResult<IEnumerable<ProceduresModel>>> GeProceduresDetailsByApptID(string id)
        {
            var proceduresDetails = await _proceduresRepo.GeProceduresDetailsByApptID(id);
            //if (proceduresDetails != null)
            //{
            //    return proceduresDetails;
            //}
            return Ok(proceduresDetails);
        }
    }
}
