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
    public class DemographicRepo : IDemographicRepo
    {
        private readonly PatientDbContext _context;

        public DemographicRepo(PatientDbContext context)
        {
            _context = context;
        }

        public async Task<DemographicDto> CreateUpdateDemographic(DemographicDto demographic)
        {
            var existingDemo = await _context.Demographics.Where(p => p.PatientId == demographic.PatientId).FirstOrDefaultAsync();
            if (existingDemo == null)
            {
                existingDemo = new Demographic()
                {
                    PatientId = demographic.PatientId,
                    Title = demographic.Title,
                    FirstName = demographic.FirstName,
                    LastName = demographic.LastName,
                    DOB = demographic.DOB,
                    Gender = demographic.Gender,
                    Race = demographic.Race,
                    Ethnicity = demographic.Ethnicity,
                    LanguagesKnown = demographic.LanguagesKnown,
                    EmailId = demographic.EmailId,
                    HomeAddress = demographic.HomeAddress,
                    ContactNumber = demographic.ContactNumber

                };
                _context.Demographics.Add(existingDemo);

            }
            else
            {
                existingDemo.Title = demographic.Title;
                existingDemo.FirstName = demographic.FirstName;
                existingDemo.LastName = demographic.LastName;
                existingDemo.DOB = demographic.DOB;
                // existingDemo.Age = demographic.Age;
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
            demographic.Id = existingDemo.Id;
            return demographic;

        }

        public async Task<DemographicDto> GetDemographicByPatientID(string patientId)
        {
            DemographicDto demographic = await _context.Demographics.Where(p => p.PatientId == patientId)
                .Select(i=> new DemographicDto()
                {
                    Id=i.Id,
                    PatientId=i.PatientId,
                    Title=i.Title,
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    DOB = i.DOB,
                    Gender = i.Gender,
                    Race = i.Race,
                    Ethnicity = i.Ethnicity,
                    LanguagesKnown = i.LanguagesKnown,
                    EmailId = i.EmailId,
                    HomeAddress = i.HomeAddress,
                    ContactNumber = i.ContactNumber

                }).FirstOrDefaultAsync();
            return demographic;
        }
    }
}
