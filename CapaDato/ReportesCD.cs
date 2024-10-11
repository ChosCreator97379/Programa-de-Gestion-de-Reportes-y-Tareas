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
        public static DataTable ObtenerReportePorID(int id)
        {
            using (SqlConnection connection = ConexionCD.sqlConnection())
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM Reportes WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        public static void EditarReporte(int id, string cuenta, string marketing, string disenador, string audiovisual,
                                          DateTime fecha, string cumplioActividad1, string cumplioActividad2,
                                          string hora1, string reporte1, string observacion1, string hora2, string reporte2,
                                          string observacion2, string hora3, string reporte3, string observacion3,
                                          string actM, string actD, string actA, int horasM, int horasD, int horasA, int puntaje)
        {
            using (SqlConnection connection = ConexionCD.sqlConnection())
            {
                string query = "UPDATE Reportes SET Cuenta = @cuenta, Marketing = @marketing, Disenador = @disenador, Audiovisual = @audiovisual, " +
                               "Fecha = @fecha, Cumplio_Actividad_01 = @cumplioActividad1, Cumplio_Actividad_02 = @cumplioActividad2, " +
                               "Hora_01 = @hora1, Reporte_01 = @reporte1, Observacion_01 = @observacion1, " +
                               "Hora_02 = @hora2, Reporte_02 = @reporte2, Observacion_02 = @observacion2, " +
                               "Hora_03 = @hora3, Reporte_03 = @reporte3, Observacion_03 = @observacion3, " +
                               "Act_M = @actM, Act_D = @actD, Act_A = @actA, Horas_M = @horasM, Horas_D = @horasD, " +
                               "Horas_A = @horasA, Puntaje = @puntaje WHERE ID = @id";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@cuenta", cuenta);
                cmd.Parameters.AddWithValue("@marketing", marketing);
                cmd.Parameters.AddWithValue("@disenador", disenador);
                cmd.Parameters.AddWithValue("@audiovisual", audiovisual);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@cumplioActividad1", cumplioActividad1);
                cmd.Parameters.AddWithValue("@cumplioActividad2", cumplioActividad2);
                cmd.Parameters.AddWithValue("@hora1", hora1);
                cmd.Parameters.AddWithValue("@reporte1", reporte1);
                cmd.Parameters.AddWithValue("@observacion1", observacion1);
                cmd.Parameters.AddWithValue("@hora2", hora2);
                cmd.Parameters.AddWithValue("@reporte2", reporte2);
                cmd.Parameters.AddWithValue("@observacion2", observacion2);
                cmd.Parameters.AddWithValue("@hora3", hora3);
                cmd.Parameters.AddWithValue("@reporte3", reporte3);
                cmd.Parameters.AddWithValue("@observacion3", observacion3);
                cmd.Parameters.AddWithValue("@actM", actM);
                cmd.Parameters.AddWithValue("@actD", actD);
                cmd.Parameters.AddWithValue("@actA", actA);
                cmd.Parameters.AddWithValue("@horasM", horasM);
                cmd.Parameters.AddWithValue("@horasD", horasD);
                cmd.Parameters.AddWithValue("@horasA", horasA);
                cmd.Parameters.AddWithValue("@puntaje", puntaje);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static DataTable ObtenerEmpleados()
        {
            using (SqlConnection connection = ConexionCD.sqlConnection())
            {
                DataTable dt = new DataTable();
                string query = "SELECT Nombre1, Apellido1, Carrera FROM DatosAcademicos INNER JOIN Empleados ON DatosAcademicos.ID_Empleado = Empleados.ID";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }
        public static void EliminarReporte(int id)
        {
            using (SqlConnection conn = ConexionCD.sqlConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Reportes WHERE ID = @ID", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static DataTable BuscarReporte(string columna, string valor)
        {
            using (SqlConnection connection = ConexionCD.sqlConnection())
            {
                // Abrir conexión
                connection.Open();

                // Crear consulta SQL
                string query = $"SELECT * FROM Reportes WHERE {columna} LIKE @valor";

                // Crear comando SQL
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@valor", "%" + valor + "%"); // Búsqueda con LIKE

                    // Ejecutar consulta y llenar DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dtResultados = new DataTable();
                    adapter.Fill(dtResultados);

                    return dtResultados;
                }
            }
        }
    }
}
