import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Reporte } from '../Models/reporte';

@Injectable({
  providedIn: 'root',
})
export class UsuarioService {
  private apiUrl ='https://localhost:7160/api/Reporte';

  constructor (private http:HttpClient) {}

  ObtenerTodo() {
    return this.http.get<Reporte[]>(this.apiUrl);
  }

  InsetarUsuario(usuario: Reporte){
    return this.http.post<Reporte>(this.apiUrl, usuario);
  }

  deleteUsuario(id: number){
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  actualizarUsuario(usuario:Reporte) {
    return this.http.put<Reporte>(this.apiUrl, usuario);
  }
}
