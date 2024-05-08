using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegraApp.Domain.Models
{
    [Table("Empleados")]
    public class EmpleadoModel
    {
        [Key]
        public int Id { get; set; } 
        public string? Apellido { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? FotoPath { get; set; } 
        public DateTime FechaContratacion { get; set; }
    }
}
