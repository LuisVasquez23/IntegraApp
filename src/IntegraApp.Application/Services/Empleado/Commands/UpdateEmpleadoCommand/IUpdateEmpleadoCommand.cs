namespace IntegraApp.Application.Services.Empleado.Commands.UpdateEmpleadoCommand
{
    public interface IUpdateEmpleadoCommand
    {
        Task<bool> Execute(UpdateEmpleadoModel model);
    }
}
