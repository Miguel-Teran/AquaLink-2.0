import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Reporte } from '../Models/reporte';

@Injectable({
  providedIn: 'root',
})

export class ReporteService {
  private apiUrl ='https://localhost:7160/api/Reporte';

  constructor (private http:HttpClient) {}

  ObtenerTodo() {
    return this.http.get<Reporte[]>(this.apiUrl);
  }

  InsetarReporte(reporte: Reporte){
    return this.http.post<Reporte>(this.apiUrl, reporte);
  }

  DeleteReporte(id: number){
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  ActualizarReporte(reporte: Reporte) {
    return this.http.put<Reporte>(this.apiUrl, reporte);
  }
}