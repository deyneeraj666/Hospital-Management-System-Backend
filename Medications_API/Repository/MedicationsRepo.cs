using Medications_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medications_API.Repository
{
    public class MedicationsRepo : IMedicationsRepo
    {
        private readonly MedicationsDbContext _context;

        public MedicationsRepo(MedicationsDbContext context)
        {
            _context = context;
        }
        public async Task<Medications> CreateUpdateMedications(Medications medications)
        {
            var _existingMedi = await _context.Medications.Where(p => p.Id == medications.Id).FirstOrDefaultAsync();
            try
            {
               
                if (_existingMedi == null)
                {
                    await _context.Medications.AddAsync(medications);
                }
                else
                {
                    _existingMedi.PatientId = medications.PatientId;
                    _existingMedi.DrugName = medications.DrugName;
                    _existingMedi.Strength = medications.Strength;
                    _existingMedi.Date = medications.Date;
                    _existingMedi.Frequency = medications.Frequency;
                    _existingMedi.Form = medications.Form;
                    _existingMedi.Quantity = medications.Quantity;
                    _existingMedi.Notes = medications.Notes;
                    _existingMedi.AppointmentId = medications.AppointmentId;
                    await  _context.Medications.AddAsync(_existingMedi);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            return _existingMedi;
        }

        public async Task<Medications> GetMedicationsDetailsByPatientID(string patientId)
        {
            Medications medicaionsModel = await _context.Medications.Where(p => p.PatientId == patientId).FirstOrDefaultAsync();
            return medicaionsModel;
        }
        public async Task<Medications> GetMedicationsDetailsByApptID(string appId)
        {
            Medications medicaionsModel = await _context.Medications.Where(p => p.AppointmentId == appId).FirstOrDefaultAsync();
            return medicaionsModel;
        }
        public List<MedicationsMaster> GetMedications()
        {
            //List<ProceduresModel> procedures = _context.Procedures.ToList();
            List<MedicationsMaster> medicationMaster = _context.MedicationsMaster.ToList();
            return medicationMaster;
        }
    }
}
