import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmpleadoListComponent } from './empleado/empleado-list/empleado-list.component';
import { EmpleadoDetailComponent } from './empleado/empleado-detail/empleado-detail.component';
import { EmpleadoCreateComponent } from './empleado/empleado-create/empleado-create.component';
import { EmpleadoUpdateComponent } from './empleado/empleado-update/empleado-update.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

const routes: Routes = [
  { path: '', redirectTo: 'empleados', pathMatch: 'full' },
  { path: 'empleados', component: EmpleadoListComponent },
  { path: 'empleados/detail/:id', component: EmpleadoDetailComponent },
  { path: 'empleados/create', component: EmpleadoCreateComponent },
  { path: 'empleados/update/:id', component: EmpleadoUpdateComponent },
  { path: '**', redirectTo: '/' },
];

@NgModule({
  declarations: [
    AppComponent,
    EmpleadoListComponent,
    EmpleadoCreateComponent,
    EmpleadoUpdateComponent,
    EmpleadoDetailComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    CommonModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
