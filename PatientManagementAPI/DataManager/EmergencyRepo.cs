using Microsoft.EntityFrameworkCore;
using PatientManagementAPI.DTO;
using PatientManagementAPI.Models;
using PatientManagementAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagementAPI.DataManager
{
    public class EmergencyRepo : IEmergencyRepo
    {
        private readonly PatientDbContext context;

        public EmergencyRepo(PatientDbContext _context)
        {
            context = _context;
        }
        public async Task<EmergencyContactDto> CreateUpdateEmergencyContact(EmergencyContactDto emergency)
        {
            var existingEmergency = await context.Patient_Emergency_Details.Where(p => p.PatientId == emergency.PatientId).FirstOrDefaultAsync();
            if (existingEmergency == null)
            {
                existingEmergency = new EmergencyContact()
                {
                    PatientId= emergency.PatientId,
                    FirstName=emergency.FirstName,
                    LastName=emergency.LastName,
                    Relationship=emergency.Relationship,
                    EmailId=emergency.EmailId,
                    Address=emergency.Address,
                    ContactNumber=emergency.ContactNumber,
                    PatientPortalAccess=emergency.PatientPortalAccess
                };
                context.Patient_Emergency_Details.Add(existingEmergency);

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
            emergency.Id = existingEmergency.Id;
            return emergency;
        }

        public async Task<EmergencyContactDto> GetEmergencyContactByPatientID(string patientId)
        {
            EmergencyContactDto emergency = await context.Patient_Emergency_Details.Where(p => p.PatientId == patientId)
                .Select(i=> new EmergencyContactDto()
                {
                    Id=i.Id,
                    PatientId=i.PatientId,
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    Relationship = i.Relationship,
                    EmailId = i.EmailId,
                    Address = i.Address,
                    ContactNumber = i.ContactNumber,
                    PatientPortalAccess = i.PatientPortalAccess
                }).FirstOrDefaultAsync();
            return emergency;
        }
    }
}
