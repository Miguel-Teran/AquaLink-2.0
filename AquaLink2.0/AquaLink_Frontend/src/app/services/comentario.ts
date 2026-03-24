import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Comentario } from '../Components/comentario/comentario';

@Injectable({
  providedIn: 'root',
})
export class ComentarioService {
  private apiUrl = 'https://localhost:7160/api/Comentario';

  constructor (private http:HttpClient) {}

  ObtenerTodo() {
    return this.http.get<Comentario[]>(this.apiUrl);
  }
  
  InsertarComentario(comentario: Comentario){
    return this.http.post<Comentario>(this.apiUrl, Comentario);
  }

  DeleteComentario(id: number){
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  Actualizarcomentario(comentario: Comentario){
    return this.http.put<Comentario>(this.apiUrl, Comentario);
  }
}
