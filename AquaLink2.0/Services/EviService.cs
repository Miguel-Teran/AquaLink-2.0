using System.Data;
using AquaLink2._0.Models;
using Microsoft.Data.SqlClient;

namespace AquaLink2._0.Services
{
    public class EviService : IEvidenciaService
    {
        private readonly string _connection;

        public EviService(IConfiguration config)
        {
            _connection = config.GetConnectionString("DefaultConnection");
        }

        public List<Evidencia> ObtenerTodo()
        {
            var lista = new List<Evidencia>();
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Obtener_Evidencias", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Evidencia
                {
                    Evi_Id = Convert.ToInt32(reader["Evi_Id"]),
                    Evi_IdRep = Convert.ToInt32(reader["Evi_IdRep"]),
                    Evi_Descripcion = reader["Evi_Descripcion"].ToString(),
                    Evi_Imagen = reader["Evi_ImaDireccion"].ToString() 
                });
            }
            return lista;
        }

        public Evidencia ObtenerPorId(int id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Obtener_Evidencia_Por_Id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdEvi", id);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Evidencia
                {
                    Evi_Id = Convert.ToInt32(reader["Evi_Id"]),
                    Evi_IdRep = Convert.ToInt32(reader["Evi_IdRep"]),
                    Evi_Descripcion = reader["Evi_Descripcion"].ToString(),
                    Evi_Imagen = reader["Evi_ImaDireccion"].ToString()
                };
            }
            return null;
        }

        public void Insertar(Evidencia evidencia)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Insertar_Evidencia", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdRep", evidencia.Evi_IdRep);
            cmd.Parameters.AddWithValue("@Desc", evidencia.Evi_Descripcion);
            cmd.Parameters.AddWithValue("@Imagen", evidencia.Evi_Imagen);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Evidencia evidencia)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Actualizar_Evidencia", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdRep", evidencia.Evi_IdRep);
            cmd.Parameters.AddWithValue("@Desc", evidencia.Evi_Descripcion);
            cmd.Parameters.AddWithValue("@Imagen", evidencia.Evi_Imagen);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Borrar(int id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Eliminar_Evidencia", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdRep", id);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
