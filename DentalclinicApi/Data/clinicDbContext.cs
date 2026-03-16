using DentalclinicApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalClinicAPI.Data
{
    public class ClinicDbContext : DbContext
    {
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
    }
}
