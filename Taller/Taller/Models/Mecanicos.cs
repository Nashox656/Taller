using System.ComponentModel.DataAnnotations;

namespace Taller.Models
{
    public class Mecanicos
    {
        [Key]
        public int IdMecanico { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public int Edad {  get; set; }
        public string? Domicilio { get; set; }
        public string? Titulo { get; set; }
        public string? Especialidad { get; set; }
        public int SueldoBase {  get; set; }
        public int GratTitulo { get; set; }
        public int SueldoTotal { get; set; }

    }
}
//Creamos los modelos identicos a los datos de la base de datos
//Tambien agregamos los campos que seran necesariamente requeridos y el Key para denotar la primary key en el id