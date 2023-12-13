using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsumirAPI.Models
{
    public class MecanicoViewModel
    {
        [Key]
        public int IdMecanico { get; set; }
        [Required]
        [DisplayName("Nombre")]
        public string? Nombre { get; set; }
        [Required]
        
        public int Edad { get; set; }
        public string? Domicilio { get; set; }
        public string? Titulo { get; set; }
        public string? Especialidad { get; set; }
        public int SueldoBase { get; set; }
        public int GratTitulo { get; set; }
        public int SueldoTotal { get; set; }
    }
}
