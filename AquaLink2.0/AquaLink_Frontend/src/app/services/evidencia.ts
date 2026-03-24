import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Evidencia } from '../Components/evidencia/evidencia';

@Injectable({
  providedIn: 'root',
})
export class EvidenciaService {
  private apiUrl = 'https://localhost:7160/api/Evidencia';

  constructor (private http:HttpClient) {}

  ObtenerTodo() {
    return this.http.get<Evidencia[]>(this.apiUrl);
  }

  InsertarEvidencia(evidencia: Evidencia){
    return this.http.post<Evidencia>(this.apiUrl, evidencia)
  }

  EliminarEvidencia(id: number){
    return this.http.delete(`${this.apiUrl}/${id}`)
  }

  actualizarEvidencia(evidencia: Evidencia){
    return this.http.put<Evidencia>(this.apiUrl, evidencia)
  }
}
