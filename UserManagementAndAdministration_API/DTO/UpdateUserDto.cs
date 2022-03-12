using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementAndAdministration_API.DTO
{
    public class UpdateUserDto
    {
        [Required]
        public string id { get; set; }
        public string Title { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public String FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        
        
    }
}
