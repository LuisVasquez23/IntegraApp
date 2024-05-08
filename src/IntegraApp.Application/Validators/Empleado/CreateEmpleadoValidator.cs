using FluentValidation;
using IntegraApp.Application.Services.Empleado.Commands.CreateEmpleadoCommand;

namespace IntegraApp.Application.Validators.Empleado
{
    public class CreateEmpleadoValidator : AbstractValidator<CreateEmpleadoModel>
    {
        public CreateEmpleadoValidator()
        {
            RuleFor(e => e.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio.");

            RuleFor(e => e.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.");

            RuleFor(e => e.Telefono)
                .NotEmpty().WithMessage("El teléfono es obligatorio.")
                .Matches(@"^(\(\d{3}\) \d{4}-\d{4}|\d{3} \d{4}-\d{4})$").WithMessage("El teléfono debe tener el formato (XXX) XXXX-XXXX o XXX XXXX-XXXX.");
            
            RuleFor(e => e.Correo).NotEmpty().WithMessage("El correo es obligatorio.")
                                   .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$").WithMessage("El correo no tiene un formato válido.");
            
            RuleFor(e => e.FechaContratacion).NotEmpty().WithMessage("La fecha de contratación es obligatoria.")
                                               .Must(BeAValidDate).WithMessage("La fecha de contratación debe de ser menor a la fecha actual");


                                               
        }

        private bool BeAValidDate(DateTime date)
        {
            return date <= DateTime.Now;
        }
    }
}
