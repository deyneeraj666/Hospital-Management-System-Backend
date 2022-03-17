using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagementAPI.DTO
{
    public class DemographicDto
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Ethnicity { get; set; }
        public string LanguagesKnown { get; set; }
        public string EmailId { get; set; }
        public string HomeAddress { get; set; }
        public string ContactNumber { get; set; }
    }
}
