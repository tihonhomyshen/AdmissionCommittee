using AdmissionCommittee.Models;
using Microsoft.EntityFrameworkCore;

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
