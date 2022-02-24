using System.ComponentModel.DataAnnotations;

namespace UserManagementAndAdministration_API.DTO
{
    public class ChangePasswordDto:SignInDto
    {
        [Required]
        public string NewPassword { get; set; }
    }
}
