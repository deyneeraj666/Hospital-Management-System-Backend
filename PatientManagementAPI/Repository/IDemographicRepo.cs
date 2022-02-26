using PatientManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagementAPI.Repository
{
    public interface IDemographicRepo
    {
        Task<Demographic> GetDemographicByPatientID(string patientId);

        Task<Demographic> CreateUpdateDemographic(Demographic demographic);


    }
}
