using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagementAPI.Models
{
    public class PatientDbContext :DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
        {

        }

        public DbSet<Demographic> Demographics { get; set; }

        public DbSet<EmergencyContact> Patient_Emergency_Details { get; set; }

    }
}
