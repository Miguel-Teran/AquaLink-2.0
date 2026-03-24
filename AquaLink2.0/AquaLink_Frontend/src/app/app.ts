import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Reporte } from './Models/reporte';
import { Usuario } from './Models/usuario';
import { UsuarioService } from './services/usuario';
import { ChangeDetectorRef } from '@angular/core';

import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';

interface Rol {
  id: number;
  nombre: string;
}

@Component({
  selector: 'app-root',
  standalone: true,
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
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App implements OnInit{
  usurios: Usuario[] = [];

  newUsuario: Usuario = {
    usu_Id: 0,
    usu_Nombre: '',
    usu_Correo : '',
    usu_Telefono : '',
    usu_IdRol : 0
  };

  roles: Rol[] = [
    {id: 1, nombre: 'Usuario'},
    {id: 2, nombre: 'Administrador'}
  ]

  constructor(private usuarioService: UsuarioService, private cd: ChangeDetectorRef){}
  
  displayedColumns: string[] = ['nombre', 'correo', 'telefono', 'rol'];
  
  isEditing = false;

  getNombreRol(id: number): string {
    const rol = this.roles.find(r => r.id === id);
    return rol ? rol.nombre : 'Sin Rol';
  }

  reserForm() {
    this.newUsuario = {
      usu_Id: 0,usu_Nombre: '',usu_Correo : '',usu_Telefono : '',usu_IdRol : 0}
    this.isEditing = false;
    this.obtenerTodo();
  }

  guardarUsuario() {
    if (this.isEditing) {
      this.usuarioService.actualizarUsuario(this.newUsuario)
      .subscribe(() => {
        this.reserForm();
      });
    }else {
      this.usuarioService.InsetarUsuario(this.newUsuario)
      .subscribe(( ) => {
        this.reserForm(); 
      });
    } 
  }

  editarUsuario(usuario: Usuario) {
    this.newUsuario = {...usuario};
    this.isEditing = true;
  }

  ngOnInit(): void {
    this.obtenerTodo();
  }

  obtenerTodo() {
    this.usuarioService.ObtenerTodo()
    .subscribe(data => {
      console.log('Datos cargados en el componente', data);
      this.usurios = data;
      this.cd.detectChanges();
    },
  );
  }

  insertarUsuario() {
    this.usuarioService.InsetarUsuario(this.newUsuario)
    .subscribe(() => {
      this.obtenerTodo();
      this.newUsuario = {
        usu_Id: 0,usu_Nombre: '',usu_Correo : '',usu_Telefono : '',usu_IdRol : 0}
    });
  }

  deleteUsuario (id: number) {
    this.usuarioService.deleteUsuario(id)
    .subscribe(() => this.obtenerTodo());
  }
}

