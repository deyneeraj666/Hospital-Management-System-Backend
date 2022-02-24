using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementAndAdministration_API.Models
{
    public class ResetPassword
    {
        [Key]
        public int Id { get; set; }

        //[StringLength(450)]
        //public string UserId { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(5000)]
        public string Token { get; set; }

        [StringLength(10)]
        public string OTP { get; set; }

        public DateTime InsertDateTimeUTC { get; set; }

        //[ForeignKey(nameof(UserId))]
        //public IdentityUser User { get; set; }
    }
}
