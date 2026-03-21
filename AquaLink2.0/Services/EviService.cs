using AquaLink2._0.Models;

namespace AquaLink2._0.Services
{
    public class EviService : IEvidenciaService
    {
        private static List<Evidencia> _evidencias = new List<Evidencia>();

        public async Task<List<Evidencia>> ListarPorReporte(int idRep) =>
            _evidencias.Where(e => e.Evi_IdRep == idRep).ToList();

        public async Task Insertar(Evidencia nueva)
        {
            nueva.Evi_Id = _evidencias.Count > 0 ? _evidencias.Max(e => e.Evi_Id) + 1 : 1;
            _evidencias.Add(nueva);
        }

        public async Task Borrar(int id) => _evidencias.RemoveAll(e => e.Evi_Id == id);
    }
}
