using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentScheduling_API.DTO;

namespace AppointmentScheduling_API.Models
{
    public class AppointmentContext:DbContext
    {
        public AppointmentContext(DbContextOptions<AppointmentContext> option):base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Appointment>()
                         .HasIndex(entity => new { entity.id }).IsUnique(true);
        }
        public DbSet<Appointment> AppointmentDetails { get; set; }
        //public DbSet<ApplicationUser> ApplicationUserDetails { get; set; }

    }
}
