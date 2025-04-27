using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Veterinaria.Models;

namespace Veterinaria.Data
{
    public class VeterinariaDBcontex : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Veterinaria;Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        public DbSet<Dueño> Dueños { get; set; }
        public DbSet<Raza> Razas { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }

    }
}
