using Microsoft.EntityFrameworkCore;
using Procedures_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procedures_API.Repository
{
    public class ProceduresRepo: IProceduresRepo
    {
        private readonly ProceduresDbContext _context;

        public ProceduresRepo(ProceduresDbContext context)
        {
            _context = context;
        }
        public async Task<ProceduresModel> CreateUpdateProcedures(ProceduresModel procedure)
        {
            var _existingProc = await _context.Procedures.Where(p => p.Id == procedure.Id).FirstOrDefaultAsync();
            try
            {
                
                if (_existingProc == null)
                {
                    await _context.Procedures.AddAsync(procedure);
                    
                }
                else
                {
                    _existingProc.PatientId = procedure.PatientId;
                    _existingProc.ProcedureCode = procedure.ProcedureCode;
                    _existingProc.ProcedureName = procedure.ProcedureName;
                    _existingProc.Date = procedure.Date;
                    _existingProc.AppointmentId = procedure.AppointmentId;
                    await _context.Procedures.AddAsync(_existingProc);
                }

                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }
            return _existingProc;
        }

        public async Task<ProceduresModel> GeProceduresDetailsByPatientID(string patientId)
        {
            //throw new NotImplementedException();
            ProceduresModel proceduresModel = await _context.Procedures.Where(p => p.PatientId == patientId).FirstOrDefaultAsync();
            return proceduresModel;

        }
        public async Task<ProceduresModel> GeProceduresDetailsByApptID(string apptID)
        {
            //throw new NotImplementedException();
            ProceduresModel proceduresModel = await _context.Procedures.Where(p => p.AppointmentId == apptID).FirstOrDefaultAsync();
            return proceduresModel;

        }
        public List<ProcedureMaster> GetProcedures()
        {
            List<ProceduresModel> procedures=_context.Procedures.ToList();
            List<ProcedureMaster> procedureMaster = _context.ProceduresMaster.ToList();
            return procedureMaster;
        }
    }
}
