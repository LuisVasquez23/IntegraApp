using IntegraApp.Domain.Models;

namespace IntegraApp.Application.Services.Empleado.Commands.CreateEmpleadoCommand
{
    public interface ICreateEmpleadoCommand
    {
        Task<EmpleadoModel> Execute(CreateEmpleadoModel model);
    }
}
