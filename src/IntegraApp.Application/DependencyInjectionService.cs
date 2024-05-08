using AutoMapper;
using FluentValidation;
using IntegraApp.Application.Configuration;
using IntegraApp.Application.Feature;
using IntegraApp.Application.Services.Empleado.Commands.CreateEmpleadoCommand;
using IntegraApp.Application.Services.Empleado.Commands.DeleteEmpleadoCommand;
using IntegraApp.Application.Services.Empleado.Commands.UpdateEmpleadoCommand;
using IntegraApp.Application.Services.Empleado.Queries.GetAllEmpleadoQuery;
using IntegraApp.Application.Services.Empleado.Queries.GetEmpleadoByIdQuery;
using IntegraApp.Application.Validators.Empleado;
using Microsoft.Extensions.DependencyInjection;

namespace IntegraApp.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // MAPPER SINGLETON 
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            services.AddSingleton(mapper.CreateMapper());

            // FILE MANAGER 
            services.AddSingleton<IFileManager, ImageFileManager>();

            // SERVICES 

            #region EMPLEADO

            // COMMANDS
            services.AddTransient<ICreateEmpleadoCommand, CreateEmpleadoCommand>();
            services.AddTransient<IDeleteEmpleadoCommand, DeleteEmpleadoCommand>();
            services.AddTransient<IUpdateEmpleadoCommand, UpdateEmpleadoCommand>();

            // QUERIES 
            services.AddTransient<IGetAllEmpleadoQuery, GetAllEmpleadoQuery>();
            services.AddTransient<IGetEmpleadoByIdQuery, GetEmpleadoByIdQuery>();
            #endregion

            // VALIDATOR
            services.AddScoped<IValidator<CreateEmpleadoModel>, CreateEmpleadoValidator>();
            services.AddScoped<IValidator<UpdateEmpleadoModel>, UpdateEmpleadoValidator>();

            return services;
        }
    }
}
