using Microsoft.EntityFrameworkCore;
using practicaMVC.Models;
namespace practicaMVC.Models
{
    public class equipoDbContext : DbContext
    {
        public equipoDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<marcas> marcas { get; set; }
        public DbSet<carreras> carreras { get; set; }
        public DbSet<usuarios> usuarios { get; set; }

        public DbSet<tipo_equipo> tipo_equipo { get; set; }
        public DbSet<facultades>facultades { get; set; }
        public DbSet<estados_reserva> estados_reserva { get; set; }

        public DbSet<estados_equipo> estados_equipo { get; set; }
    }
}
