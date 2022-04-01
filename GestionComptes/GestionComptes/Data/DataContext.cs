using Microsoft.EntityFrameworkCore;

namespace FDLsys.Data
{
    public class DataContext : DbContext 

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Sequences> Sequences { get; set; }
        public DbSet<ListesFDL> listesfdl { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
