using AquaLink2._0.Models;

namespace AquaLink2._0.Services
{
    public class IReporteService
    {
        public interface Reporte
        {
            Task<List<Reporte>> ListarTodosAsync();
        }
    }
}
