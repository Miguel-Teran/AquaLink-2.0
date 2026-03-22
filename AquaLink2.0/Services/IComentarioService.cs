using AquaLink2._0.Models;

namespace AquaLink2._0.Services
{
    public interface IComentarioService
    {
        List<Comentario> ObtenerTodo();
        Comentario ObtenerPorId(int id);
        void Insertar(Comentario comentario);
        void Actualizar(Comentario comentario);
        void Borrar(int id);
    }
}
