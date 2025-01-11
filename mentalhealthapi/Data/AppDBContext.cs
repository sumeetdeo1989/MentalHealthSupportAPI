using mentalhealthapi.Models;
using Microsoft.EntityFrameworkCore;

namespace mentalhealthapi.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) 
        {
        
        }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
