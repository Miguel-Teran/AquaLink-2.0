using AquaLink2._0.Models;

namespace AquaLink2._0.Services
{
    public class ReporteService : IReporteService
    {
        public async Task<List<Reporte>> ListarTodosAsync()
        {
            await Task.Delay(100);
            return new List<Reporte>();
        }
    }
}

