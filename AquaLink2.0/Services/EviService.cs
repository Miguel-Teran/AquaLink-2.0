using AquaLink2._0.Models;

namespace AquaLink2._0.Services
{
    public class EviService : IEvidenciaService
    {
        private static List<Evidencia> _evidenciasSimuladas = new List<Evidencia>();

        public async Task<List<Evidencia>> ObtenerPorReporteAsync(int idReporte)
        {
            await Task.Delay(50);
            return _evidenciasSimuladas.Where(e => e.Evi_IdRep == idReporte).ToList();
        }

        public async Task<bool> GuardarEvidenciaAsync(Evidencia nueva)
        {
            nueva.Evi_Id = _evidenciasSimuladas.Count + 1;
            _evidenciasSimuladas.Add(nueva);
            return await Task.FromResult(true);
        }
    }
}
