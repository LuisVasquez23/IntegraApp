using AutoMapper;
using IntegraApp.Domain.Models;

namespace IntegraApp.Application.Services.Empleado.Commands.CreateEmpleadoCommand
{
    public class CreateEmpleadoCommand : ICreateEmpleadoCommand
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;


        public CreateEmpleadoCommand(IDatabaseService databaseService , IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<EmpleadoModel> Execute(CreateEmpleadoModel model)
        {
            // Mapper la entidad para luego crear
            var entity = _mapper.Map<EmpleadoModel>(model);

            await _databaseService.Empleados.AddAsync(entity);

            // Guardando entididad
            await _databaseService.SaveAsync();

            return entity;

        }
    }
}
