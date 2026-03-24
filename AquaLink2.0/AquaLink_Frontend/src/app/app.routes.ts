import { Routes } from '@angular/router';
import { reporte } from './Components/reporte/reporte';

export const routes: Routes = [
  { path: '', component: reporte }, // Ruta inicial para Reportes
  { path: 'reportes', component: reporte }
];