using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementAndAdministration_API.DTO;
using UserManagementAndAdministration_API.Models;

namespace UserManagementAndAdministration_API.Repository
{
    public interface IAccountRepository
    {
        Task<List<GetAllUsersDto>> GetAllUsers();
        Task<IdentityResult> SignUpAsync(SignUpDto signUpModel);
        Task<string> LoginAsync(SignInDto signInModel);
        Task ResetLockoutUser(string email);
        Task<string> ResetPasswordAsync(ChangePasswordDto usermodel);
        Task<IList<string>> GetUserRole(string email);
        Task<string> ResetPassword(string email, string otp, string newPassword);
        Task<string> SendPasswordResetCode(string email);
        Task<ApplicationUserDto> GetUserById(string Id);


    }
}
