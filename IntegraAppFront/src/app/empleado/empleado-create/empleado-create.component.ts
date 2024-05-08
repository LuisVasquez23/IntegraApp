import { Component } from '@angular/core';
import { CreateEmpleado } from '../../models/Empleado/create-empleado.model';
import { EmpleadoService } from '../empleado.service';

@Component({
  selector: 'app-empleado-create',
  templateUrl: './empleado-create.component.html',
  styleUrl: './empleado-create.component.css',
})
export class EmpleadoCreateComponent {
  empleado: CreateEmpleado = new CreateEmpleado(
    null,
    null,
    null,
    null,
    new Date(),
    null
  );

  submitted = false;

  constructor(private empleadoService: EmpleadoService) { }
  serverErrors: any[] = [];

  agregarEmpleado(): void {
    const formData = new FormData();
    formData.append('apellido', this.empleado.apellido || '');
    formData.append('nombre', this.empleado.nombre || '');
    formData.append('telefono', this.empleado.telefono || '');
    formData.append('correo', this.empleado.correo || '');
    formData.append(
      'fechaContratacion',
      this.empleado.fechaContratacion.toString() ?? new Date().toISOString()
    );

    if (this.empleado.archivo) {
      formData.append('archivo', this.empleado.archivo);
    }

    this.empleadoService.create(formData).subscribe({
      next: (res) => {
        console.log(res);
        this.submitted = true;
        this.serverErrors = [];
      },
      error: (e) => {
        console.error(e);
        if (e.error?.data) {
          this.serverErrors = e.error.data.map(
            (error: any) => error.errorMessage
          );
        } else {
          if (e.error?.errors) {
            const errorMessages: string[] = [];
            for (const key in e.error.errors) {
              if (e.error.errors.hasOwnProperty(key)) {
                const errorArray = e.error.errors[key];
                for (const errorMessage of errorArray) {
                  errorMessages.push(errorMessage);
                }
              }
            }
            this.serverErrors = errorMessages;
          }
        }
      },
    });
  }

  // New Empleado
  newEmpleado(): void {
    this.submitted = false;
    this.empleado = {
      apellido: null,
      nombre: null,
      telefono: null,
      correo: null,
      fechaContratacion: new Date(),
      archivo: null,
    };
  }

  //onFileSelected
  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    this.empleado.archivo = file;
  }
}
