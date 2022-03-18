using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VitalSigns_API.DTO;
using VitalSigns_API.Models;
using VitalSigns_API.Repository;

namespace VitalSigns_API.DataManager
{
    public class VitalRepo : IVitalRepo
    {
        private readonly VitalDbContext _context;

        public VitalRepo(VitalDbContext context)
        {
            _context = context;
        }


        public async Task<VitalDto> CreateUpdatePatientVital(VitalDto vital)
        {
            var existingVital = await _context.Patient_Vitals.Where(v => v.AppointmentId == vital.AppointmentId).FirstOrDefaultAsync();

            if (existingVital == null)
            {
                existingVital = new Vital()
                {
                    PatientId = vital.PatientId,
                    AppointmentId = vital.AppointmentId,
                    Height = vital.Height,
                    Weight = vital.Weight,
                    Temperature = vital.Temperature,
                    Systolic = vital.Systolic,
                    Diastolic = vital.Diastolic,
                    RespiratoryRate = vital.RespiratoryRate

                };
                _context.Patient_Vitals.Add(existingVital);

            }
            else
            {
                existingVital.PatientId = vital.PatientId;
                existingVital.AppointmentId = vital.AppointmentId;
                existingVital.Height = vital.Height;
                existingVital.Weight = vital.Weight;
                existingVital.Temperature = vital.Temperature;
                existingVital.Systolic = vital.Systolic;
                existingVital.Diastolic = vital.Diastolic;
                existingVital.RespiratoryRate = vital.RespiratoryRate;

                _context.Patient_Vitals.Update(existingVital);
            }


            await _context.SaveChangesAsync();
            vital.Id = existingVital.Id;

            return vital;
        }

        public async Task<VitalDto> GetPatientVitalByAppointmentId(int apptId)
        {
            VitalDto vital = await _context.Patient_Vitals.Where(p => p.AppointmentId == apptId).Select(i => new VitalDto()
            {
                Id = i.Id,
                PatientId = i.PatientId,
                AppointmentId = i.AppointmentId,
                Height = i.Height,
                Weight = i.Weight,
                Temperature = i.Temperature,
                Systolic = i.Systolic,
                Diastolic = i.Diastolic,
                RespiratoryRate = i.RespiratoryRate
            }).FirstOrDefaultAsync();

            return vital;
        }
    }
}
