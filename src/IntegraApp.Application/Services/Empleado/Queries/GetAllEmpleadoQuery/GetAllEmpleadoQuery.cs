using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace IntegraApp.Application.Services.Empleado.Queries.GetAllEmpleadoQuery
{
    public class GetAllEmpleadoQuery : IGetAllEmpleadoQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public GetAllEmpleadoQuery(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<List<GetAllEmpleadoModel>> Execute()
        {
            var empleados = await _databaseService.Empleados.AsNoTracking().ToListAsync();
            return _mapper.Map<List<GetAllEmpleadoModel>>(empleados);
        }
    }
}
