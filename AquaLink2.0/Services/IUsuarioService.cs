using AquaLink2._0.Models;

namespace AquaLink2._0.Services
{
    public interface IUsuarioService
    {
        List<Usuario> ObtenerTodo();
        Usuario? ObtenerPorId(int id);
        void Insertar(Usuario usuario);
        void Actualizar(Usuario usuario);
        void Borrar(int id);
        Usuario? ValidarLogin(string correo, string password);
    }
}
