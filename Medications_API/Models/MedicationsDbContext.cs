using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Medications_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Medications_API.Models
{
    public class MedicationsDbContext:DbContext
    {
        public MedicationsDbContext(DbContextOptions<MedicationsDbContext> options) : base(options)
        {
           
        }

        public DbSet<Medications> Medications { get; set; }
        public DbSet<MedicationsMaster> MedicationsMaster { get; set; }
    }
}
