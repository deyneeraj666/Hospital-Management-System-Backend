using Procedures_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procedures_API.Repository
{
    public interface IProceduresRepo
    {
        Task<ProceduresModel> GeProceduresDetailsByPatientID(string patientId);

        Task<ProceduresModel> CreateUpdateProcedures(ProceduresModel procedure);
        List<ProcedureMaster> GetProcedures();
        Task<IEnumerable<ProceduresModel>> GeProceduresDetailsByApptID(int apptID);
    }
}
