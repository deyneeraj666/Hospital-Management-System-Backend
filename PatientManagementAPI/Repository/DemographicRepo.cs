using Microsoft.EntityFrameworkCore;
using PatientManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagementAPI.Repository
{
    public class DemographicRepo : IDemographicRepo
    {
        private readonly PatientDbContext _context;

        public DemographicRepo(PatientDbContext context)
        {
            _context = context;
        }

        public async Task<Demographic> CreateUpdateDemographic(Demographic demographic)
        {
            var existingDemo = await _context.Demographics.Where(p => p.PatientId == demographic.PatientId).FirstOrDefaultAsync();
            if(existingDemo==null)
            {
                _context.Demographics.Add(demographic);

            }
            else
            {
                existingDemo.Title = demographic.Title;
                existingDemo.FirstName = demographic.FirstName;
                existingDemo.LastName = demographic.LastName;
                existingDemo.DOB = demographic.DOB;
                existingDemo.Age = demographic.Age;
                existingDemo.Gender = demographic.Gender;
                existingDemo.Race = demographic.Race;
                existingDemo.Ethnicity = demographic.Ethnicity;
                existingDemo.LanguagesKnown = demographic.LanguagesKnown;
                existingDemo.EmailId = demographic.EmailId;
                existingDemo.HomeAddress = demographic.HomeAddress;
                existingDemo.ContactNumber = demographic.ContactNumber;

                _context.Demographics.Update(existingDemo);
            }

            await _context.SaveChangesAsync();
            return existingDemo;

        }

        public async Task<Demographic> GetDemographicByPatientID(string patientId)
        {
            Demographic demographic = await _context.Demographics.Where(p => p.PatientId == patientId).FirstOrDefaultAsync();
            return demographic;
        }
    }
}
