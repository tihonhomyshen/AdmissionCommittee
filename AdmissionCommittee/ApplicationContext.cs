using AdmissionCommittee.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionCommittee
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Entrant> Entrants { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=admissioncommittee.db");
        }
    }
}
