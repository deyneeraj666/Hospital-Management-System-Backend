﻿using Diagnoses_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diagnoses_API
{
    public interface IDiagnosisRepo
    {
        Task<DiagnosisModel> GetDiagDetailsByPatientID(string patientId);

        Task<DiagnosisModel> AddDiagnosisDetails(DiagnosisModel diagnosis);
        List<DiagnosisMaster> GetAllDiagnosis();
        Task<DiagnosisModel> GetDiagDetailsByApptID(string apptId);
        void DeleteDiagDetails(string patientId);
        string GetDiagosisCodeByDiagnosisNameAsync(string name);
    }
}
