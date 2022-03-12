using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagementAndAdministration_API.DTO
{
    public class SignUpDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        public  string Role { get; set; }

        public string EmpId { get; set; }
    }
}
