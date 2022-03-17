using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Procedures_API.Models
{
    public class ProceduresDbContext: DbContext
    {
        public ProceduresDbContext(DbContextOptions<ProceduresDbContext> options) : base(options)
        {

        }

        public DbSet<ProceduresModel> Procedures { get; set; }
        public DbSet<ProcedureMaster> ProceduresMaster { get; set; }
    }
}
