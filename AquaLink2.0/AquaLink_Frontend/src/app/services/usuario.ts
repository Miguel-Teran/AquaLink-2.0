import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Usuario } from '../Models/usuario';

@Injectable({
  providedIn: 'root',
})
export class UsuarioService {
  private apiUrl ='https://localhost:7160/api/Usuario';

  constructor (private http:HttpClient) {}

  ObtenerTodo() {
    return this.http.get<Usuario[]>(this.apiUrl);
  }

  InsetarUsuario(usuario: Usuario){
    return this.http.post<Usuario>(this.apiUrl, usuario);
  }

  deleteUsuario(id: number){
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  actualizarUsuario(usuario:Usuario) {
    return this.http.put<Usuario>(this.apiUrl, usuario);
  }
}
