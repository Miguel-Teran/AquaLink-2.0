using AquaLink2._0.Models;

namespace AquaLink2._0.Services
{
    public class IComentarioService
    {
        public interface IComentarioInternal
        {
            Task<List<Comentario>> ObtenerPorReporteAsync(int idReporte);
            Task<bool> AgregarComentarioAsync(Comentario nuevo);
        }
    }
}
