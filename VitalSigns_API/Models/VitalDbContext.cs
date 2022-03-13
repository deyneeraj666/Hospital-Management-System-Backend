using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VitalSigns_API.DTO;

namespace VitalSigns_API.Models
{
    public class VitalDbContext:DbContext
    {
        public VitalDbContext(DbContextOptions<VitalDbContext> options) : base(options)
        {

        }
        public DbSet<Vital> Patient_Vitals { get; set; }
    }
}
