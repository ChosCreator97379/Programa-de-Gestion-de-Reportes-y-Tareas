using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDato
{
    public class ReportesCD
    {
        public static DataTable ObtenerReportes()
        {
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Reportes", cnx))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dtReportes = new DataTable();
                try
                {
                    adapter.Fill(dtReportes);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al obtener los reportes: " + ex.Message);
                    return null;
                }

                return dtReportes;
            }
        }
        public void AgregarReporte(DateTime fecha, string cuenta, string marketing, string disenador, string audiovisual)
        {
            using (SqlConnection conexion = ConexionCD.sqlConnection())
            {
                string consulta = "INSERT INTO Reportes (Fecha, Cuenta, Marketing, Disenador, Audiovisual, Hora_01, Reporte_01, Observacion_01, " +
                                 "Hora_02, Reporte_02, Observacion_02, Cumplio_Actividad_01, Hora_03, Reporte_03, Observacion_03, Cumplio_Actividad_02, " +
                                 "Act_M, Act_D, Act_A, Horas_M, Horas_D, Horas_A, Puntaje) " +
                                 "VALUES (@Fecha, @Cuenta, @Marketing, @Disenador, @Audiovisual, @Hora_01, NULL, NULL, " +
                                 "@Hora_02, NULL, NULL, 'Nulo', NULL, NULL, NULL, 'Nulo', NULL, NULL, NULL, 0, 0, 0, 0)";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Fecha", fecha);
                    comando.Parameters.AddWithValue("@Cuenta", cuenta);
                    comando.Parameters.AddWithValue("@Marketing", marketing);
                    comando.Parameters.AddWithValue("@Disenador", disenador);
                    comando.Parameters.AddWithValue("@Audiovisual", audiovisual);
                    comando.Parameters.AddWithValue("@Hora_01", new TimeSpan(9, 0, 0)); // 09:00
                    comando.Parameters.AddWithValue("@Hora_02", new TimeSpan(18, 0, 0)); // 18:00

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
