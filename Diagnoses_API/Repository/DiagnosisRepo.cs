using Diagnoses_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diagnoses_API.Repository
{
    public class DiagnosisRepo:IDiagnosisRepo
    {
        private readonly DiagnosisDbContext _context;

        public DiagnosisRepo(DiagnosisDbContext context)
        {
            _context = context;
        }
        public async Task<DiagnosisModel> AddDiagnosisDetails(DiagnosisModel diagnosis)
        {
             var _existingDiag = await _context.Diagnosis.Where(p => p.Id == diagnosis.Id).FirstOrDefaultAsync();
            try
            {
               
                if (_existingDiag == null)
                {
                    await _context.Diagnosis.AddAsync(diagnosis);
                    
                }
                else
                {
                    _existingDiag.pid = diagnosis.pid;
                    _existingDiag.diag_code = diagnosis.diag_code;
                    _existingDiag.diag_name = diagnosis.diag_name;
                    _existingDiag.ddate = diagnosis.ddate;
                    _existingDiag.AppointmentId = diagnosis.AppointmentId;
                    await _context.Diagnosis.AddAsync(_existingDiag);
                }
                await _context.SaveChangesAsync();
                
            }
            catch(Exception ex)
            {
                
            }
            return _existingDiag;
        }

        public List<DiagnosisMaster> GetAllDiagnosis()
        {
            List<DiagnosisMaster> diagnosisMaster = _context.DiagnosisMaster.ToList();
            return diagnosisMaster;
        }

        public async Task<DiagnosisModel> GetDiagDetailsByPatientID(string patientId)
        {
            //throw new NotImplementedException();
            DiagnosisModel diagnosisModel = await _context.Diagnosis.Where(p => p.pid == patientId).FirstOrDefaultAsync();
            return diagnosisModel;

        }
        public async Task<IEnumerable<DiagnosisModel>> GetDiagDetailsByApptID(int apptId)
        {
            //throw new NotImplementedException();
            List<DiagnosisModel> diagnosisModel = await _context.Diagnosis.Where(p => p.AppointmentId == apptId).Distinct().ToListAsync();
            return diagnosisModel;

        }

        public async void DeleteDiagDetails(string Id)
        {
            DiagnosisModel diagnosisModel = await _context.Diagnosis.Where(p => p.pid == Id).FirstOrDefaultAsync();

            _context.Diagnosis.Remove(diagnosisModel);
        }

        public List<string> GetDiagosisCodeByDiagnosisNameAsync(string name)
        {
            var diagCode =  _context.DiagnosisMaster.Where(a => a.diag_name == name).Select(x => x.diag_code).Distinct().ToList();
            return diagCode;
        }

        
    }
}
