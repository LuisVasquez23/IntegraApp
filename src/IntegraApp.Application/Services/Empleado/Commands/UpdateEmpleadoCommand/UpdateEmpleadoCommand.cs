using AutoMapper;
using IntegraApp.Domain.Models;

namespace IntegraApp.Application.Services.Empleado.Commands.UpdateEmpleadoCommand
{
    public class UpdateEmpleadoCommand : IUpdateEmpleadoCommand
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public UpdateEmpleadoCommand(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<bool> Execute(UpdateEmpleadoModel model)
        {
            // obteniendo la entidad para luego actualizar
            var entity = _mapper.Map<EmpleadoModel>(model);

            // Actualizando el empleado
            _databaseService.Empleados.Update(entity);

            return await _databaseService.SaveAsync();

        }
    }
}
