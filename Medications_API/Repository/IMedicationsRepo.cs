using Medications_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medications_API.Repository
{
    public interface IMedicationsRepo
    {
        Task<Medications> GetMedicationsDetailsByPatientID(string patientId);

        Task<Medications> CreateUpdateMedications(Medications medications);
        List<MedicationsMaster> GetMedications();
        Task<IEnumerable<Medications>> GetMedicationsDetailsByApptID(int appId);
        //List<string> GetMedicationsDetailsByApptID(string appId);

        List<MedicationsMaster> GetDrugDetailsByDrugNameAsync(string name);
    }


}
