using AquaLink2._0.Models;

namespace AquaLink2._0.Services
{
    public interface IReporteService
    {
        List<Reporte> ObtenerTodo();
        Reporte ObtenerPorId(int id);
        int Insertar(Reporte reporte);
        void Actualizar (Reporte reporte);
        void Borrar (int id);
    }
}
