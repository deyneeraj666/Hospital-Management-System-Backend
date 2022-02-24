using System.ComponentModel.DataAnnotations;

namespace UserManagementAndAdministration_API.DTO
{
    public class SignInDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
