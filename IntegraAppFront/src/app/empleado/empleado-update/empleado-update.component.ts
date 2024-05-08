import { Component } from '@angular/core';
import { Empleado } from '../../models/Empleado/empleado.model';
import { EmpleadoService } from '../empleado.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiResponse } from '../../models/api-response-model.model';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-empleado-update',
  templateUrl: './empleado-update.component.html',
  styleUrl: './empleado-update.component.css',
})
export class EmpleadoUpdateComponent {
  empleado: Empleado = new Empleado(
    null,
    null,
    null,
    null,
    null,
    new Date(),
    null
  );

  submitted = false;
  serverErrors: any[] = [];

  constructor(
    private empleadoService: EmpleadoService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.getEmpleado(Number.parseInt(id ?? '0'));
  }

  getEmpleado(id: number): void {
    this.empleadoService.getById(id).subscribe({
      next: (respuesta: ApiResponse) => {
        if (respuesta.success && respuesta.data) {
          this.empleado = respuesta.data;
        }
      },
      error: (error) => {
        console.error(error);
      },
    });
  }

  updateEmpleado(): void {
    this.submitted = true;
    this.empleadoService.update(this.empleado.id, this.empleado).subscribe({
      next: () => {
        Swal.fire(
          '¡Empleado actualizado!',
          'El empleado se ha actualizado correctamente.',
          'success'
        );
        this.router.navigate(['/empleados/detail', this.empleado.id]);
      },
      error: (error) => {
        if (error.error?.errors) {
          console.log('eRROR');
        } else {
          this.serverErrors = [
            error.error?.message ||
            'Error al actualizar el empleado. Revisar los campos ingresados',
          ];
        }
      },
    });
  }

  resetForm(): void {
    this.submitted = false;
    this.serverErrors = [];
    this.ngOnInit();
  }

  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    this.empleado.archivo = file;
  }
}
