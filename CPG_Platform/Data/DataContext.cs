using CPG_Platform.Models;
using Microsoft.EntityFrameworkCore;

namespace CPG_Platform.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DbContext> options) : base(options)
        {

        }

        DbSet<User> Users => Set<User>(); 
        DbSet<Secteur> Sectors => Set<Secteur>();
        DbSet<Service> Services => Set<Service>();
        DbSet<Entretient> Entretients => Set<Entretient>();
        DbSet<Machine> Machines => Set<Machine>();
        DbSet<PieceRechange> Pieces => Set<PieceRechange>();
        DbSet<UploadResult> Documents => Set<UploadResult>();

    }

    
}
