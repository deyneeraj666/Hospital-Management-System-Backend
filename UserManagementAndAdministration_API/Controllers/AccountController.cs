using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementAndAdministration_API.DTO;
using UserManagementAndAdministration_API.Repository;

namespace UserManagementAndAdministration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;


        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }


        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto signUpDto)
        {
            var result = await _accountRepository.SignUpAsync(signUpDto);

            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            else
            {
                List<IdentityError> errorList = result.Errors.ToList();
                string errors = "";
                foreach (var error in errorList)
                {
                    errors = errors + error.Description.ToString();
                }
                return Content(errors);
            }
        }






        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignInDto signInDto)
        {
            var result = await _accountRepository.LoginAsync(signInDto);


            if (string.IsNullOrEmpty(result))
            {

                return BadRequest("Invalid Email-Id or Password");
            }
            if (result == "Locked")
            {
                return BadRequest("Account Blocked ! Please Contact Admin Or Try again after 5  minutes");
            }

            var roles = await _accountRepository.GetUserRole(signInDto.Email);
            var claimedtoken = new AuthenticationProperties(new Dictionary<string, string>
            {
                {
                    "token",result 
                },
                {
                    "role",roles[0].ToLower()
                }
            });
            return Ok(claimedtoken);
        }



      
        [HttpGet("GetAllUsers")]
       
        public async Task<List<GetAllUsersDto>> GetAllUsers()
        {
            return await _accountRepository.GetAllUsers();
          
        }

        [HttpGet("GetUserById")]
        public async Task<ApplicationUserDto> GetUserById([FromQuery] string id)
        {
            return await _accountRepository.GetUserById(id);
        }



        [HttpPost("UnblockUser")]
        public async Task<IActionResult> Unblock(UnblockUserByIdDto userId)
        {
            await _accountRepository.ResetLockoutUser(userId.email);
            return Ok("Unblocked "+ userId.email);
        }

        [HttpPost("BlockUser")]
        public async Task<IActionResult> Block(UnblockUserByIdDto userId)
        {
            await _accountRepository.BlockUser(userId.email);
            return Ok("Blocked " + userId.email);
        }

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser(UnblockUserByIdDto userId)
        {
            await _accountRepository.DeleteUser(userId.email);
            return Ok("Deleted " + userId.email);
        }

        
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto update_user)
        {
            await _accountRepository.UpdateUser(update_user);
            return Ok("Updated ");
        }



        [HttpPost("ChangePassword")]
        public async Task<string> ResetPassword(ChangePasswordDto usermodel)
        {
            
            var result= await _accountRepository.ResetPasswordAsync(usermodel);
            if (result == "Success")
            {
                return "Password Changes Successfully";
            } 
            else if (result == "Failed") 
            {
                return "Current Password is Incorrect";
            }
            else
            {
                return "User Not Found!";
            }
        }


        [HttpPost]
        [Route("SendPasswordResetCode")]
        public async Task<IActionResult> SendPasswordResetCode(UnblockUserByIdDto user)
        {
            var result = await _accountRepository.SendPasswordResetCode(user.email);
            if(result== "Email should not be null or empty")
            {
                return NotFound("Email should not be null or empty");
            }
            else if(result == "No User Found")
            {
                return NotFound("No User Found !");
            }
            else 
            {
                return Ok("OTP Send to the Registered Email");
            }
        }

        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto user)
        {
            var result = await _accountRepository.ResetPassword(user.Email,user.OTP,user.NewPassword);
            if(result == "Email & New Password should not be null or empty")
            {
               return BadRequest("Email & New Password should not be null or empty");
            }
            else if(result == "OTP is expired, please generate the new OTP")
            {
                return Unauthorized("OTP is expired, please generate the new OTP");
            }
            else if(result == "BadRequest")
            {
                return BadRequest("OTP is Incorrect !");
            }
            else
            {
                return Ok("Success! Please Log In !");
            }
        }


    }
}
