using AquaLink2._0.Models;

namespace AquaLink2._0.Services
{
    public class ComentarioService : IComentarioService
    {
        private static List<Comentario> _comentarios = new List<Comentario>();

        public async Task<List<Comentario>> ListarPorReporte(int idRep) =>
            _comentarios.Where(c => c.Com_IdRep == idRep).ToList();

        public async Task Insertar(Comentario nuevo)
        {
            nuevo.Com_Id = _comentarios.Count > 0 ? _comentarios.Max(c => c.Com_Id) + 1 : 1;
            _comentarios.Add(nuevo);
        }

        public async Task Borrar(int id) => _comentarios.RemoveAll(c => c.Com_Id == id);
    }
}

