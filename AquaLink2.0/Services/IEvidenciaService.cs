using AquaLink2._0.Models;

namespace AquaLink2._0.Services
{
    public interface IEvidenciaService
    {
        List<Evidencia> ObtenerTodo();
        Evidencia ObtenerPorId(int id);
        void Insertar(Evidencia evidencia);
        void Actualizar(Evidencia evidencia);
        void Borrar(int id);
    }
}
