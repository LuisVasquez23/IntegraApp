using AutoMapper;
using IntegraApp.Application.Services.Empleado.Commands.CreateEmpleadoCommand;
using IntegraApp.Application.Services.Empleado.Commands.UpdateEmpleadoCommand;
using IntegraApp.Application.Services.Empleado.Queries.GetAllEmpleadoQuery;
using IntegraApp.Application.Services.Empleado.Queries.GetEmpleadoByIdQuery;
using IntegraApp.Domain.Models;

namespace IntegraApp.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            // COMMANDS
            CreateMap<EmpleadoModel, CreateEmpleadoModel>().ReverseMap();
            CreateMap<EmpleadoModel, UpdateEmpleadoModel>().ReverseMap();

            // QUERIES 
            CreateMap<EmpleadoModel, GetAllEmpleadoModel>().ReverseMap();
            CreateMap<EmpleadoModel, GetEmpleadoByIdModel>().ReverseMap();

        }
    }
}
