using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;
using UserManagementAndAdministration_API.DTO;
using UserManagementAndAdministration_API.Models;
using UserManagementAndAdministration_API.Repository;
using EmailService;

namespace UserManagementAndAdministration_API.DataManager
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _databaseContext;

        public AccountRepository(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 IConfiguration configuration,
                                 RoleManager<IdentityRole> roleManager,
                                 IEmailSender emailSender,
                                 ApplicationDbContext databaseContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _emailSender = emailSender;
            _databaseContext = databaseContext;
        }

        public async Task<List<GetAllUsersDto>> GetAllUsers()
        {
            var user = _userManager.Users.ToList();
            var result = new List<GetAllUsersDto>();
            foreach (var item in user)
            {
                var role = await GetUserRole(item.Email);

               
                
                result.Add(new GetAllUsersDto 
                {
                    EmpId =item.EmpId,
                    Title=item.Title,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    Dob = item.Dob,
                    accessFailedCount = item.AccessFailedCount,
                    Status= item.LockoutEnd==null?"Active":"Blocked",
                    Id =item.Id,
                    Role = role[0]  
                    
                });
            }
            return result;
        }


        public async Task<string> LoginAsync(SignInDto signInDto)
        {
           
            var result = await _signInManager.PasswordSignInAsync(signInDto.Email, signInDto.Password, false, true);
            
            if (result.IsLockedOut)
            {
                return "Locked";
            }
            if (!result.Succeeded)
            {
               
                return null;
            }
            await ResetLockoutUser(signInDto.Email);
            
            var user =  _userManager.Users.Where(x => x.Email == signInDto.Email).ToList();
            var roles = await GetUserRole(signInDto.Email);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, signInDto.Email,signInDto.Password),
                new Claim("Email", signInDto.Email),
                new Claim("FirstName", user[0].FirstName),
                new Claim("LastName", string.IsNullOrEmpty(user[0].LastName)?"":user[0].LastName),
                new Claim("Id", user[0].Id),
                new Claim("Role", roles[0]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("EmpId", user[0].EmpId)
            };
            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Key"]));

            var Token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddMinutes(1000),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    

        public async Task<IdentityResult> SignUpAsync(SignUpDto SignUpDto)
        {

            var user = new ApplicationUser()
            {
                Title = SignUpDto.Title,
                FirstName = SignUpDto.FirstName,
                LastName = SignUpDto.LastName,
                Email = SignUpDto.Email,
                PhoneNumber = SignUpDto.PhoneNumber,
                Dob = SignUpDto.Dob,
                UserName = SignUpDto.Email,
                EmpId = SignUpDto.Role == "Patient" ? "PAT" + RandomNumberGeneartor.Generate(100000, 999999)+ SignUpDto.FirstName.Substring(0,3).ToUpper() : "EMP" + RandomNumberGeneartor.Generate(100000, 999999)+ SignUpDto.FirstName.Substring(0, 3).ToUpper()

            };
            
            var result = await _userManager.CreateAsync(user, SignUpDto.Password);
            await _userManager.AddToRoleAsync(user, SignUpDto.Role);
            return result;
        }




        public async Task ResetLockoutUser(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user != null)
            {
                await _userManager.ResetAccessFailedCountAsync(user);
                await _userManager.SetLockoutEndDateAsync(user, null);
            }
            
        }


        public async Task BlockUser(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user != null)
            {
                await _userManager.SetLockoutEndDateAsync(user, DateTime.Now.AddDays(30));
            }

        }


        public async Task DeleteUser(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }

        }

        public async Task<IdentityResult> UpdateUser(UpdateUserDto update_user)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(update_user.id);
            user.UserName = update_user.Email;
            user.Title = update_user.Title;
            user.FirstName = update_user.FirstName;
            user.LastName = update_user.LastName;
            user.Dob = update_user.Dob;
            user.Email = update_user.Email;
            user.PhoneNumber = update_user.PhoneNumber;
            user.EmpId = update_user.Role == "Patient" ? "PAT" + RandomNumberGeneartor.Generate(100000, 999999) + user.FirstName.Substring(0, 3).ToUpper() : "EMP" + RandomNumberGeneartor.Generate(100000, 999999) + user.FirstName.Substring(0, 3).ToUpper();
            return await _userManager.UpdateAsync(user);
        }


        public async Task<string> ResetPasswordAsync(ChangePasswordDto usermodel)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(usermodel.Email);
            if (user == null)
            {
                return "NotFound!";
            }
            var result = await _userManager.ChangePasswordAsync(user, usermodel.Password, usermodel.NewPassword);
            if (!result.Succeeded)
            {
                return "Failed";
            }
            return "Success";
        }

        public async Task<IList<string>> GetUserRole(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }





        public async Task<string> SendPasswordResetCode(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return "Email should not be null or empty";
            }
            var user = await _userManager.FindByNameAsync(email);
            if (user == null)
            {
                return "No User Found";
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            int otp = RandomNumberGeneartor.Generate(100000, 999999);
            var resetPassword = new ResetPassword()
            {
                Email = email,
                OTP = otp.ToString(),
                Token = token,
                InsertDateTimeUTC = DateTime.UtcNow
            };
            await _databaseContext.AddAsync(resetPassword);
            await _databaseContext.SaveChangesAsync();

            var message = new Message(new string[] { email }, "Account Recovery", "Hello  "
                + user.FirstName + "," + "<br> Please find the OTP below valid for 5 Minutes.<br>" + "OTP:<b>"
                + otp + "</b>" + "<br>Thanks!");
            _emailSender.SendEmail(message);

            return "Token sent successfully in email";
        }



        public async Task<string> ResetPassword(string email, string otp, string newPassword)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(newPassword))
            {
                return "Email & New Password should not be null or empty";
            }


            var user = await _userManager.FindByNameAsync(email);


            var resetPasswordDetails = _databaseContext.ResetPassword
                .Where(rp => rp.OTP == otp && rp.Email == user.Email)
                .OrderByDescending(rp => rp.InsertDateTimeUTC)
                .FirstOrDefault();
            if (resetPasswordDetails == null)
            {
                return "BadRequest";
            }

            var expirationDateTimeUtc = resetPasswordDetails.InsertDateTimeUTC.AddMinutes(5);

            if (expirationDateTimeUtc < DateTime.UtcNow)
            {
                return "OTP is expired, please generate the new OTP";
            }

            var res = await _userManager.ResetPasswordAsync(user, resetPasswordDetails.Token, newPassword);

            if (!res.Succeeded)
            {
                return "BadRequest";
            }
            _databaseContext.Remove(user);
            return "Success";
        }
        public async Task<ApplicationUserDto> GetUserById(string Id)
        {
            var objUser = await _userManager.FindByIdAsync(Id);
            if (objUser != null)
            {
                var user = new ApplicationUserDto();
                user.FirstName = objUser.FirstName;
                user.LastName = objUser.LastName;
                user.Email = objUser.Email;
                user.PhoneNumber = objUser.PhoneNumber;
                user.Dob = objUser.Dob;
                user.AccessFailedCount = objUser.AccessFailedCount;
                user.LockoutEnd = objUser.LockoutEnd;
                user.EmpId = objUser.EmpId;
                user.Id = objUser.Id;
                

                return user;
            }
            else
            {
                return new ApplicationUserDto();
            }
        }
    }
}
