using AquaLink2._0.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AquaLink2._0.Services
{
    public class AutenService
    {
        private static List<Usuario> _usuarios = new List<Usuario>
        {
            new Usuario { Usu_Id = 1, Usu_Nombre = "Admin AquaLink", Usu_Correo = "admin@agua.com", Usu_IdRol = "1" }
        };

        public async Task<Usuario?> LoginAsync(string correo, string password)
        {
            await Task.Delay(50);
            if (password == "1234") // Simulación de validación
            {
                return _usuarios.FirstOrDefault(u => u.Usu_Correo == correo);
            }
            return null;
        }

        // CRUD de Usuarios
        public async Task<List<Usuario>> Listar() => await Task.FromResult(_usuarios);

        public async Task Insertar(Usuario nuevo)
        {
            nuevo.Usu_Id = _usuarios.Count > 0 ? _usuarios.Max(u => u.Usu_Id) + 1 : 1;
            _usuarios.Add(nuevo);
        }

        public async Task Actualizar(Usuario usu)
        {
            var index = _usuarios.FindIndex(u => u.Usu_Id == usu.Usu_Id);
            if (index != -1) _usuarios[index] = usu;
        }

        public async Task Borrar(int id) => _usuarios.RemoveAll(u => u.Usu_Id == id);

    }
}
