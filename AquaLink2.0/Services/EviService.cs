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
            using SqlCommand cmd = new SqlCommand("Obtener_Evidencia", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Evidencia
                {
                    Evi_IdRep = Convert.ToInt32(reader["Evi_IdRep"]),
                    Evi_Descripcion = reader["Evi_Descripcion"].ToString(),
                    Evi_ImaURL = reader["Evi_ImaDireccion"].ToString() 
                });
            }
            return lista;
        }

        public Evidencia ObtenerPorId(int id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Obtener_Evidencia_Por_Id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Evidencia
                {
                    Evi_IdRep = Convert.ToInt32(reader["Evi_IdRep"]),
                    Evi_Descripcion = reader["Evi_Descripcion"].ToString(),
                    Evi_ImaURL = reader["Evi_ImaDireccion"].ToString()
                };
            }
            return null;
        }

        public void Insertar(Evidencia evidencia)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Insertar_Evidencia", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", evidencia.Evi_Id);
            cmd.Parameters.AddWithValue("@IdRep", evidencia.Evi_IdRep);
            cmd.Parameters.AddWithValue("@Descripcion", evidencia.Evi_Descripcion);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Evidencia evidencia)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Actualizar_Evidencia", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Clave", evidencia.Evi_Id);
            cmd.Parameters.AddWithValue("@Descripcion", evidencia.Evi_Descripcion);
            cmd.Parameters.AddWithValue("@Imadireccion", evidencia.Evi_ImaURL);
            cmd.Parameters.AddWithValue("@IdRep", evidencia.Evi_IdRep);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Borrar(int id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Eliminar_Evidencia", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
