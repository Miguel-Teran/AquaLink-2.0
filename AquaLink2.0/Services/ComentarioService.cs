using AquaLink2._0.Models;

namespace AquaLink2._0.Services
{
    public class ComentarioService : IComentarioService
    {
        private static List<Comentario> _comentariosSimulados = new List<Comentario>();

        public async Task<List<Comentario>> ObtenerPorReporteAsync(int idReporte)
        {
            await Task.Delay(50);
            return _comentariosSimulados.Where(c => c.Com_IdRep == idReporte).ToList();
        }

        public async Task<bool> AgregarComentarioAsync(Comentario nuevo)
        {
            nuevo.Com_Id = _comentariosSimulados.Count + 1;
            _comentariosSimulados.Add(nuevo);
            return await Task.FromResult(true);
        }
    }
}
