import { Component } from '@angular/core';
import { Empleado } from '../../models/Empleado/empleado.model';
import { EmpleadoService } from '../empleado.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiResponse } from '../../models/api-response-model.model';

@Component({
  selector: 'app-empleado-detail',
  templateUrl: './empleado-detail.component.html',
  styleUrl: './empleado-detail.component.css'
})
export class EmpleadoDetailComponent {
  empleado: any;

  defaultImagePath = 'http://localhost:5081/Fotos/sinImagen.jpg';

  constructor(
    private empleadoService: EmpleadoService,
    private route: ActivatedRoute
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


}
