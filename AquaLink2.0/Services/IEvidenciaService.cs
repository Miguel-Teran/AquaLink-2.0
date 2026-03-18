using AquaLink2._0.Models;

namespace AquaLink2._0.Services
{
    public class IEvidenciaService
    {
        public class IEviService
        {
            public interface IEviInternal
            {
                Task<List<Evidencia>> ObtenerPorReporteAsync(int idReporte);
                Task<bool> GuardarEvidenciaAsync(Evidencia nueva);
            }
        }
    }
}
