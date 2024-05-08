import { Component, OnInit } from '@angular/core';
import { EmpleadoService } from '../empleado.service';
import { ApiResponse } from '../../models/api-response-model.model';
import Swal from 'sweetalert2';
import { formatDate } from '../../utils/FormatDate';

@Component({
  selector: 'app-empleado-list',
  templateUrl: './empleado-list.component.html',
  styleUrl: './empleado-list.component.css',
})
export class EmpleadoListComponent implements OnInit {
  empleados: any[] = [];
  defaultImagePath = 'http://localhost:5081/Fotos/sinImagen.jpg';
  formatDate = formatDate;

  constructor(private empleadoService: EmpleadoService) { }

  ngOnInit(): void {
    this.getEmpleados();
  }

  // OBTENER LOS EMPLEADOS
  getEmpleados(): void {
    this.empleadoService.getEmpleados().subscribe({
      next: (res: ApiResponse) => {
        if (res.success && res.data) {
          this.empleados = res.data;
        }
      },
      error: (e) => console.error(e),
    });
  }


  // ELIMINAR EMPLEADO
  eliminarEmpleado(id: number): void {
    Swal.fire({
      title: '¿Estás seguro?',
      text: '¡No podrás revertir esto!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Sí, eliminarlo!',
      cancelButtonText: 'Cancelar',
    }).then((result) => {
      if (result.isConfirmed) {
        this.empleadoService.delete(id).subscribe((response: ApiResponse) => {
          if (response.success) {
            this.getEmpleados();
            Swal.fire(
              'Eliminado!',
              'El empleado ha sido eliminado.',
              'success'
            );
          } else {
            Swal.fire(
              'Error!',
              response.message || 'Hubo un error al eliminar el empleado.',
              'error'
            );
          }
        });
      }
    });
  }


}
