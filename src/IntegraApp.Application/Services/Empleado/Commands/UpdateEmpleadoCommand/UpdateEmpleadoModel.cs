namespace IntegraApp.Application.Services.Empleado.Commands.UpdateEmpleadoCommand
{
    public class UpdateEmpleadoModel
    {
        public int Id { get; set; }
        public string? Apellido { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? FotoPath { get; set; }
        public DateTime FechaContratacion { get; set; }
    }
}
