using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VitalSigns_API.DTO;

namespace VitalSigns_API.Repository
{
    public interface IVitalRepo
    {
        Task<VitalDto> GetPatientVitalByAppointmentId(int apptId);
        Task<VitalDto> CreateUpdatePatientVital(VitalDto vital);
    }
}
