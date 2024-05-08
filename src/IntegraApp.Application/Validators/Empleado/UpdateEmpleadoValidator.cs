using FluentValidation;
using IntegraApp.Application.Services.Empleado.Commands.CreateEmpleadoCommand;
using IntegraApp.Application.Services.Empleado.Commands.UpdateEmpleadoCommand;


namespace IntegraApp.Application.Validators.Empleado
{
    public class UpdateEmpleadoValidator : AbstractValidator<UpdateEmpleadoModel>
    {
        public UpdateEmpleadoValidator()
        {
            RuleFor(e => e.Apellido).NotEmpty().WithMessage("El apellido es obligatorio.");
            RuleFor(e => e.Nombre).NotEmpty().WithMessage("El nombre es obligatorio.");
            RuleFor(e => e.Telefono).NotEmpty().WithMessage("El teléfono es obligatorio.")
                                     .Matches(@"^\(\d{3}\) \d{4}-\d{4}$").WithMessage("El teléfono debe tener el formato (XXX) XXXX-XXXX.");
            RuleFor(e => e.Correo).NotEmpty().WithMessage("El correo es obligatorio.")
                                   .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$").WithMessage("El correo no tiene un formato válido.");
            RuleFor(e => e.FechaContratacion).NotEmpty().WithMessage("La fecha de contratación es obligatoria.")
                                               .Must(BeAValidDate).WithMessage("La fecha de contratación no es válida.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return date <= DateTime.Now;
        }
    }
}
