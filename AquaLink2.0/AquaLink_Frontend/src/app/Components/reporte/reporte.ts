import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Reporte } from '../../Models/reporte';
import { ReporteService } from '../../services/reporteService';
import { ChangeDetectorRef } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-root',
  imports: [
    CommonModule, 
    FormsModule,
    MatTableModule,
    MatButtonModule,
    MatInputModule,
    MatCardModule,
    MatFormFieldModule,
    MatIconModule,
    MatSelectModule
  ],
  templateUrl: './reporte.html',
  styleUrl: '../../app.css'
})

export class reporte implements OnInit {
  reportes: Reporte[] = [];

  newReporte : Reporte = {
    rep_Id: 0,
    rep_Fecha: new Date(),
    rep_Lat: 0,
    rep_Lon: 0,
    rep_IdUsu: 0,
  }
  
  constructor(private reporteService: ReporteService, private cd: ChangeDetectorRef){}

  displayedColumns: string[] = ['Fecha', 'Latitud', 'Longitud', 'Usuario']

  isEditing = false;

  reserForm() {
    this.newReporte = {
      rep_Id: 0, rep_Fecha:new Date(), rep_Lat:0, rep_Lon:0, rep_IdUsu:0}
    this.isEditing = false;
    this.ObtenerTodo();
  }

  guardarReporte() {
    if(this.isEditing) {
      this.reporteService.ActualizarReporte(this.newReporte)
      .subscribe(() => {
        this.reserForm();
      });
    }
  }

  editarReporte() {
  }
  ngOnInit(): void {
    this.ObtenerTodo();
  }

  ObtenerTodo() {
    this.reporteService.ObtenerTodo()
    .subscribe(data => {
      console.log('Datos cargados en el componente', data);
      this.reportes = data;
      this.cd.detectChanges();
    },
  );
  }

  InsertarReporte() {
    this.reporteService.InsetarReporte(this.newReporte)
    .subscribe(() => {
    this.ObtenerTodo();
    this.newReporte = {
      rep_Id: 0, rep_Fecha: new Date(), rep_Lat: 0, rep_Lon:0, rep_IdUsu:0}
    });
  }

  DeleteReporte(id: number) {
    this.reporteService.DeleteReporte(id)
    .subscribe(() => this.ObtenerTodo());
  }
}

  