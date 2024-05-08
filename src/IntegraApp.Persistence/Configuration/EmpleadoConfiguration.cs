using IntegraApp.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegraApp.Persistence.Configuration
{
    public class EmpleadoConfiguration
    {
        public EmpleadoConfiguration(EntityTypeBuilder<EmpleadoModel> entityBuilder)
        {
            // PK
            entityBuilder.HasKey(x => x.Id);

            entityBuilder.Property(x => x.Apellido).IsRequired();
            entityBuilder.Property(x => x.Nombre).IsRequired();
            entityBuilder.Property(x => x.Telefono);
            entityBuilder.Property(x => x.Correo);
            entityBuilder.Property(x => x.FotoPath);
            entityBuilder.Property(x => x.FechaContratacion).IsRequired();
            
        }
    }
}
