using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allergies_API.Model
{
    public class AllergyDbContext:DbContext
    {
        public AllergyDbContext(DbContextOptions<AllergyDbContext> options):base(options)
        {

        }
        public DbSet<Allergy> Allergy_Master { get; set; }
        public DbSet<PatientAllergy> Patient_Allergy_Details { get; set; }

    }
}
