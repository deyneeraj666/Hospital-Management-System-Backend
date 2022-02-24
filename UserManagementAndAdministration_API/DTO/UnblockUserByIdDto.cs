using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementAndAdministration_API.DTO
{
    public class UnblockUserByIdDto
    {
        [Required,EmailAddress]
        public string email { get; set; }

    }
}
