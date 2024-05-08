using IntegraApp.Application.Services;
using IntegraApp.Domain.Models;
using IntegraApp.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IntegraApp.Persistence.Database
{
    public class IntegraAppDbContext : DbContext, IDatabaseService
    {
        public IntegraAppDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<EmpleadoModel> Empleados { get; set; }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new EmpleadoConfiguration(modelBuilder.Entity<EmpleadoModel>());
        }
    }
}
