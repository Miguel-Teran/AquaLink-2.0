using AquaLink2._0.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AquaLink2._0.Services
{
    public class ReporteService : IReporteService
    {
        private readonly string _connection;

        public ReporteService(IConfiguration config)
        {
            _connection = config.GetConnectionString("DefaultConnection");
        }

        public List<Reporte>ObtenerTodo()
        {
            var lista = new List<Reporte>();

            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Obtener_Reporte", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Reporte
                {
                    Rep_Descripcion = reader["Rep_Descripcion"].ToString(),
                    Rep_Fecha = DateOnly.FromDateTime(Convert.ToDateTime(reader["Rep_Fecha"])),
                    Rep_Lat = Convert.ToDecimal(reader["Rep_Lat"]),
                    Rep_Lon = Convert.ToDecimal(reader["Rep_Lon"]),
                    Rep_IdUsu = Convert.ToInt32(reader["Rep_IdUsu"])
                });
            }
                return lista;
        }

        public Reporte ObtenerPorId(int id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Obtener_Reporte_Por_Id", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Reporte
                {
                    Rep_Id = Convert.ToInt32(reader["Rep_Id"]),
                    Rep_Descripcion = reader["Rep_Descripcion"].ToString(),
                    Rep_Fecha = DateOnly.FromDateTime(Convert.ToDateTime(reader["Rep_Fecha"])),
                    Rep_Lat = Convert.ToDecimal(reader["Rep_Lat"]),
                    Rep_Lon = Convert.ToDecimal(reader["Rep_Lon"]),
                    Rep_IdUsu = Convert.ToInt32(reader["Rep_IdUsu"])
                };
            }
            return null;
        }
        public int Insertar(Reporte reporte)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Ins_Reporte", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Descripcion", reporte.Rep_Descripcion);
            cmd.Parameters.AddWithValue("@Fecha", reporte.Rep_Fecha);
            cmd.Parameters.AddWithValue("@Latitud", reporte.Rep_Lat);
            cmd.Parameters.AddWithValue("@Longitud", reporte.Rep_Lon);
            cmd.Parameters.AddWithValue("@Usuario", reporte.Rep_IdUsu);

            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        public void Actualizar(Reporte reporte)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Act_Reporte", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Clave", reporte.Rep_Id);
            cmd.Parameters.AddWithValue("@Descripcion", reporte.Rep_Descripcion);
            cmd.Parameters.AddWithValue("@Fecha", reporte.Rep_Fecha);
            cmd.Parameters.AddWithValue("@Latitud", reporte.Rep_Lat);
            cmd.Parameters.AddWithValue("@Longitud", reporte.Rep_Lon);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
        public void Borrar(int id)
        {
            using SqlConnection conn = new SqlConnection(_connection);
            using SqlCommand cmd = new SqlCommand("Eliminar_Reporte", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
