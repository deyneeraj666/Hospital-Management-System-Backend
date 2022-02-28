using Microsoft.EntityFrameworkCore;
using PatientManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagementAPI.Repository
{
    public class EmergencyRepo : IEmergencyRepo
    {
        private readonly PatientDbContext context;

        public EmergencyRepo(PatientDbContext _context)
        {
            context = _context;
        }
        public async Task<EmergencyContact> CreateUpdateEmergencyContact(EmergencyContact emergency)
        {
            var existingEmergency = await context.Patient_Emergency_Details.Where(p => p.PatientId == emergency.PatientId).FirstOrDefaultAsync();
            if (existingEmergency == null)
            {
                context.Patient_Emergency_Details.Add(emergency);

            }
            else
            {
                existingEmergency.FirstName = emergency.FirstName;
                existingEmergency.LastName = emergency.LastName;
                existingEmergency.Relationship = emergency.Relationship;
                existingEmergency.EmailId = emergency.EmailId;
                existingEmergency.ContactNumber = emergency.ContactNumber;
                existingEmergency.Address = emergency.Address;
                existingEmergency.PatientPortalAccess = emergency.PatientPortalAccess;

                context.Patient_Emergency_Details.Update(existingEmergency);
            }

            await context.SaveChangesAsync();
            return existingEmergency;
        }

        public async Task<EmergencyContact> GetEmergencyContactByPatientID(string patientId)
        {
            EmergencyContact emergency = await context.Patient_Emergency_Details.Where(p => p.PatientId == patientId).FirstOrDefaultAsync();
            return emergency;
        }
    }
}
