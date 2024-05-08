using IntegraApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegraApp.Application.Services
{
    public interface IDatabaseService
    {
        DbSet<EmpleadoModel> Empleados { get; set; }
        Task<bool> SaveAsync();
    }
}
