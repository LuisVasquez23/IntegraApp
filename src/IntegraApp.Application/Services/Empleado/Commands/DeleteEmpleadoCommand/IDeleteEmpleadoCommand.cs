namespace IntegraApp.Application.Services.Empleado.Commands.DeleteEmpleadoCommand
{
    public interface IDeleteEmpleadoCommand
    {
        Task<bool> Execute(int EmpleadoId);
    }
}
