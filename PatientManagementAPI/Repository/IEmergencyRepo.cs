using PatientManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagementAPI.Repository
{
    public interface IEmergencyRepo
    {
        Task<EmergencyContact> GetEmergencyContactByPatientID(string patientId);
        Task<EmergencyContact> CreateUpdateEmergencyContact(EmergencyContact emergency);
    }
}
