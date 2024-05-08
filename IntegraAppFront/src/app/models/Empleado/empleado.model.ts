export class Empleado {
  id: number | null;
  apellido: string | null;
  nombre: string | null;
  telefono: string | null;
  correo: string | null;
  fechaContratacion: Date;
  archivo: File | null;

  constructor(
    id: number | null,
    apellido: string | null,
    nombre: string | null,
    telefono: string | null,
    correo: string | null,
    fechaContratacion: Date,
    archivo: File | null
  ) {
    this.id = id;
    this.apellido = apellido;
    this.nombre = nombre;
    this.telefono = telefono;
    this.correo = correo;
    this.fechaContratacion = fechaContratacion;
    this.archivo = archivo;
  }
}
