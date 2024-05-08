namespace IntegraApp.WebApi.ViewModels.Empleado
{
    public class CreateEmpleadoViewModel
    {
        public string? Apellido { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public DateTime FechaContratacion { get; set; }
        public IFormFile? Archivo { get; set; }
    }
}
