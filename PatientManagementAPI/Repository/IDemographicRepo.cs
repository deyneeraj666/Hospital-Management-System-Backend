using PatientManagementAPI.DTO;
using PatientManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagementAPI.Repository
{
    public interface IDemographicRepo
    {
        Task<DemographicDto> GetDemographicByPatientID(string patientId);

        Task<DemographicDto> CreateUpdateDemographic(DemographicDto demographic);


    }
}
