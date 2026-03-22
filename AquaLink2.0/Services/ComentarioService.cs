using System.Data.Common;
using System.Data;
using AquaLink2._0.Models;
using Microsoft.Data.SqlClient;

namespace AquaLink2._0.Services
{
    public class ComentarioService : IComentarioService
    {
        private readonly string _connection;

        public ComentarioService(IConfiguration config)
        {
            _connection = config.GetConnectionString("DefaultConnection");
        }

        public List<Comentario> ObtenerTodo()
        {
            var lista = new List<Comentario>();
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Listar_Comentario", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Descripcion", "");

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Comentario
                {
                    Com_Id = Convert.ToInt32(reader["Com_Id"]),
                    Com_IdUsu = Convert.ToInt32(reader["Com_IdUsu"]),
                    Com_IdRep = Convert.ToInt32(reader["Com_IdRep"]),
                    Com_Descripcion = reader["Com_Descripcion"].ToString()
                });
            }
            return lista;
        }

        public Comentario ObtenerPorId(int id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Bus_Comentario", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Clave", id);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Comentario
                {
                    Com_Id = Convert.ToInt32(reader["Com_Id"]),
                    Com_IdUsu = Convert.ToInt32(reader["Com_IdUsu"]),
                    Com_IdRep = Convert.ToInt32(reader["Com_IdRep"]),
                    Com_Descripcion = reader["Com_Descripcion"].ToString()
                };
            }
            return null;
        }

        public void Insertar(Comentario comentario)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Ins_Comentario", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdUsu", comentario.Com_IdUsu);
            cmd.Parameters.AddWithValue("@IdRep", comentario.Com_IdRep);
            cmd.Parameters.AddWithValue("@Descripción", comentario.Com_Descripcion);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Comentario comentario)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Act_Comentario", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdCom", comentario.Com_Id);
            cmd.Parameters.AddWithValue("@Descripción", comentario.Com_Descripcion);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Borrar(int id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Del_Comentario", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Clave", id);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}

