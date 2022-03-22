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
    public class ProcedureDetailsController : ControllerBase
    {
        private readonly IProceduresRepo _proceduresDetailsRepo;
        public ProcedureDetailsController(IProceduresRepo proceduresRepo)
        {
            _proceduresDetailsRepo = proceduresRepo;
            // GetallProcedures();
        }
        [HttpGet(Name = "GetallProcedures")]
        public List<ProcedureMaster> GetallProcedures()
        {
            List<ProcedureMaster> Procedurelists = _proceduresDetailsRepo.GetProcedures();
            
                return Procedurelists;
            

        }
        [HttpGet("{name}", Name = "GetProcedureNameByProcedureCode")]

        public Task<IEnumerable<string>> GetProcedureNameByProcedureCode(string name)
        {

            try
            {
                Task<IEnumerable<string>> names = _proceduresDetailsRepo.GetProcedureCodeByProcedureNameAsync(name);
                Console.WriteLine(names);
                return names;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

    }
}
