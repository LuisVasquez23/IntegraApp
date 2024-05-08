using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace IntegraApp.Application.Services.Empleado.Queries.GetEmpleadoByIdQuery
{
    public class GetEmpleadoByIdQuery : IGetEmpleadoByIdQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public GetEmpleadoByIdQuery(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<GetEmpleadoByIdModel> Execute(int empleadoId)
        {
            var empleado = await _databaseService.Empleados
                                                        .AsNoTracking()
                                                      .FirstOrDefaultAsync(x => x.Id == empleadoId);

            return _mapper.Map<GetEmpleadoByIdModel>(empleado);
        }
    }
}
