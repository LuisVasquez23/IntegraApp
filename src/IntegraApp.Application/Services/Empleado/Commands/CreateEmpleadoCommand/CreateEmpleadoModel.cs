using Microsoft.AspNetCore.Http;

namespace IntegraApp.Application.Services.Empleado.Commands.CreateEmpleadoCommand
{
    public class CreateEmpleadoModel
    {
        public string? Apellido { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? FotoPath { get; set; }
        public DateTime FechaContratacion { get; set; }
    }
}
