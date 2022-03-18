using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagementAPI.DTO
{
    public class EmergencyContactDto
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Relationship { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string PatientPortalAccess { get; set; }
    }
}
