using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Taller.Models;

namespace ConsumirAPI.Models
{
    public partial class MecanicoContext : DbContext
    {
        // Otras propiedades y métodos de la clase

        public virtual DbSet<MecanicoViewModel> Mecanicos { get; set; }

        // Método para listar mecánicos por ID
        public class MyDbContext : DbContext
        {
            public MyDbContext(DbContextOptions options) : base(options)
            {
            }
            [Required]
            public DbSet<Mecanicos> Mecanicos { get; set; }
        }

        // Otras configuraciones del modelo

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
