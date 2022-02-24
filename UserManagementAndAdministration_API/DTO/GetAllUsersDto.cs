using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementAndAdministration_API.DTO
{
    public class GetAllUsersDto:SignUpDto
    {

        public int accessFailedCount { get; set; }
       
        public DateTimeOffset? LockoutEnd { get; set; }
        
        public string Id { get; set; }
        

    }
}
