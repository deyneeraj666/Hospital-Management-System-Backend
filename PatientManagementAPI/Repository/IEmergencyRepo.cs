using PatientManagementAPI.DTO;
using PatientManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagementAPI.Repository
{
    public interface IEmergencyRepo
    {
        Task<EmergencyContactDto> GetEmergencyContactByPatientID(string patientId);
        Task<EmergencyContactDto> CreateUpdateEmergencyContact(EmergencyContactDto emergency);
    }
}
