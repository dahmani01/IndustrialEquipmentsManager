using CPG_Platform.Models;
using Microsoft.EntityFrameworkCore;

namespace CPG_Platform.Data
{
    public class DataContext : DbContext
    {
       
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users => Set<User>(); 
        public DbSet<Secteur> Sectors => Set<Secteur>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<Entretient> Entretients => Set<Entretient>();
        public DbSet<Machine> Machines => Set<Machine>();
        public DbSet<PieceRechange> Pieces => Set<PieceRechange>();
        public DbSet<UploadResult> Documents => Set<UploadResult>();

    }

    
}
