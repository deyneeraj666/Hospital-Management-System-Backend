

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Diagnoses_API.Models
{
    public class DiagnosisDbContext: DbContext
    {
        public DiagnosisDbContext(DbContextOptions<DiagnosisDbContext> options) : base(options)
        {

        }

        public DbSet<DiagnosisModel> Diagnosis { get; set; }
        public DbSet<DiagnosisMaster> DiagnosisMaster { get; set; }
    }
}
