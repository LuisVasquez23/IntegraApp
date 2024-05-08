using Microsoft.EntityFrameworkCore;

namespace IntegraApp.Application.Services.Empleado.Commands.DeleteEmpleadoCommand
{
    public class DeleteEmpleadoCommand : IDeleteEmpleadoCommand
    {
        private readonly IDatabaseService _databaseService;

        public DeleteEmpleadoCommand(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<bool> Execute(int EmpleadoId)
        {
            var empleado = await _databaseService.Empleados.FirstOrDefaultAsync(x => x.Id == EmpleadoId);

            if (empleado == null)
            {
                return false;
            }

            _databaseService.Empleados.Remove(empleado);

            return await _databaseService.SaveAsync();
        }
    }
}
