using AquaLink2._0.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AquaLink2._0.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly string? _connection;

        public UsuarioService(IConfiguration config)
        {
            _connection = config.GetConnectionString("DefaultConnection");
        }

        public List<Usuario> ObtenerTodo()
        {
            var lista = new List<Usuario>();

            using SqlConnection conn = new SqlConnection(_connection!);
            using SqlCommand cmd = new SqlCommand("Obtener_Usuario", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Usuario
                {
                    Usu_Id = Convert.ToInt32(reader["Usu_Id"]),
                    Usu_Nombre = reader["Usu_Nombre"].ToString(),
                    Usu_Correo = reader["Usu_Correo"].ToString(),
                    Usu_Telefono = reader["Usu_Telefono"].ToString(),
                    Usu_IdRol = Convert.ToInt32(reader["Usu_IdRol"])
                });
            }
            return lista;
        }

        public Usuario? ObtenerPorId(int id)
        {
            using SqlConnection conn = new SqlConnection(_connection!);
            using SqlCommand cmd = new SqlCommand("Obtener_Usuario_Por_Id", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Usuario
                {
                    Usu_Id = Convert.ToInt32(reader["Usu_Id"]),
                    Usu_Nombre = reader["Usu_Nombre"].ToString(),
                    Usu_Correo = reader["Usu_Correo"].ToString(),
                    Usu_Telefono = reader["Usu_Telefono"].ToString(),
                    Usu_IdRol = Convert.ToInt32(reader["Usu_IdRol"])
                };
            }
            return null;
        }

        public void Insertar(Usuario usuario)
        {
            using SqlConnection conn = new SqlConnection(_connection!);
            using SqlCommand cmd = new SqlCommand("sp_InsertarUsuario", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", usuario.Usu_Id);
            cmd.Parameters.AddWithValue("@Nombre", usuario.Usu_Nombre);
            cmd.Parameters.AddWithValue("@Correo", usuario.Usu_Correo);
            cmd.Parameters.AddWithValue("@Tel", usuario.Usu_Telefono);
            cmd.Parameters.AddWithValue("@IdRol", usuario.Usu_IdRol);
            cmd.Parameters.AddWithValue("@Password", usuario.Usu_Password);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Usuario usuario)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Actualizar_Usuario", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Clave", usuario.Usu_Id);
            cmd.Parameters.AddWithValue("@Nombre", usuario.Usu_Nombre);
            cmd.Parameters.AddWithValue("@Correo", usuario.Usu_Correo);
            cmd.Parameters.AddWithValue("@Telefono", usuario.Usu_Telefono);
            cmd.Parameters.AddWithValue("@IdRol", usuario.Usu_IdRol);
            cmd.Parameters.AddWithValue("@Password", usuario.Usu_Password);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Borrar(int id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Eliminar_Usuario", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public Usuario ValidarLogin(string correo, string password)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Validar_Acceso", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Correo", correo.Trim());
            cmd.Parameters.AddWithValue("@Password", password.Trim());

            conn.Open();
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Usuario
                {
                    Usu_Id = Convert.ToInt32(reader["Usu_Id"]),
                    Usu_Nombre = reader["Usu_Nombre"].ToString(),
                    Usu_IdRol = Convert.ToInt32(reader["Usu_IdRol"])
                };
            }
            return null;
        }
        public int Registrar(Usuario usuario)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("sp_InsertarUsuario", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nombre", usuario.Usu_Nombre);
            cmd.Parameters.AddWithValue("@Correo", usuario.Usu_Correo);
            cmd.Parameters.AddWithValue("@Password", usuario.Usu_Password);
            cmd.Parameters.AddWithValue("@Rol", 2);
            SqlParameter resParam = new SqlParameter("@Resultado", SqlDbType.Int) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(resParam);

            conn.Open();
            cmd.ExecuteNonQuery();

            return (int)resParam.Value;
        }
    }
}
