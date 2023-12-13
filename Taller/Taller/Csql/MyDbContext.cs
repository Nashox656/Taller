using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Taller.Models;

namespace Taller.Csql
{
    public class MyDbContext : DbContext
    {
        //Creamos los parametros de conexion a la bd
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        [Required]
        public DbSet<Mecanicos> Mecanicos { get; set; }
    }
}
