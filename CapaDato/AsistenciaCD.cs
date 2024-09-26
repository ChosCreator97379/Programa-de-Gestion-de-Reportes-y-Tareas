using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaEntidad;
using System.Data;

namespace CapaDato
{
    public class AsistenciaCD
    {
        public void GuardarAsistencia(AsistenciaCE asistencia)
        {
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                if (cnx == null)
                {
                    throw new Exception("No se pudo establecer la conexión a la base de datos.");
                }

                try
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Asistencias (ID_Empleado, Fecha, HoraEntrada, HoraSalida) VALUES (@ID_Empleado, @Fecha, @HoraEntrada, @HoraSalida)", cnx);

                    // Añadir parámetros para ID de empleado y fecha
                    cmd.Parameters.AddWithValue("@ID_Empleado", asistencia.ID_Empleado);
                    cmd.Parameters.AddWithValue("@Fecha", asistencia.Fecha);

                    // Formatear hora de entrada para guardar solo horas y minutos
                    if (asistencia.HoraEntrada.HasValue)
                    {
                        TimeSpan horaEntrada = new TimeSpan(asistencia.HoraEntrada.Value.Hours, asistencia.HoraEntrada.Value.Minutes, 0);
                        cmd.Parameters.AddWithValue("@HoraEntrada", horaEntrada);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@HoraEntrada", DBNull.Value);
                    }

                    // Formatear hora de salida para guardar solo horas y minutos
                    if (asistencia.HoraSalida.HasValue)
                    {
                        TimeSpan horaSalida = new TimeSpan(asistencia.HoraSalida.Value.Hours, asistencia.HoraSalida.Value.Minutes, 0);
                        cmd.Parameters.AddWithValue("@HoraSalida", horaSalida);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@HoraSalida", DBNull.Value);
                    }

                    // Ejecutar el comando
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al guardar la asistencia: " + ex.Message);
                }
            }
        }

        public DataTable ObtenerAsistencias()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                if (cnx == null)
                {
                    throw new Exception("No se pudo establecer la conexión a la base de datos.");
                }

                try
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Asistencias", cnx);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los datos: " + ex.Message);
                }
            }
            return dt;
        }
        public DataTable ObtenerAsistenciaPorId(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Asistencias WHERE ID = @ID", cnx);
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public void ActualizarAsistencia(int id, DateTime fecha, TimeSpan? horaEntrada, TimeSpan? horaSalida)
        {
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                // Asegúrate de abrir la conexión
                cnx.Open();

                // Consulta SQL para actualizar la asistencia
                string query = "UPDATE Asistencias SET Fecha = @Fecha, HoraEntrada = @HoraEntrada, HoraSalida = @HoraSalida WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, cnx))
                {
                    // Agregar los parámetros a la consulta
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);

                    // Solo agregar las horas y minutos a HoraEntrada y HoraSalida
                    if (horaEntrada.HasValue)
                    {
                        TimeSpan horaEntradaSimplificada = new TimeSpan(horaEntrada.Value.Hours, horaEntrada.Value.Minutes, 0);
                        cmd.Parameters.AddWithValue("@HoraEntrada", horaEntradaSimplificada);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@HoraEntrada", DBNull.Value); // Si no hay valor, enviar nulo
                    }

                    if (horaSalida.HasValue)
                    {
                        TimeSpan horaSalidaSimplificada = new TimeSpan(horaSalida.Value.Hours, horaSalida.Value.Minutes, 0);
                        cmd.Parameters.AddWithValue("@HoraSalida", horaSalidaSimplificada);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@HoraSalida", DBNull.Value); // Si no hay valor, enviar nulo
                    }

                    // Ejecutar la consulta
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public bool EliminarAsistencia(int id)
        {
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Asistencias WHERE ID = @ID", cnx);
                cmd.Parameters.AddWithValue("@ID", id);

                cnx.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                cnx.Close();

                return filasAfectadas > 0;
            }
        }
        public DataTable BuscarAsistencias(string campo, string valor)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                cnx.Open();
                string query = "";

                // Construir la consulta SQL basada en el campo de búsqueda
                switch (campo)
                {
                    case "ID_Empleado":
                        query = "SELECT * FROM Asistencias WHERE ID_Empleado = @valor";
                        break;
                    case "HoraEntrada":
                        query = "SELECT * FROM Asistencias WHERE HoraEntrada = @valor";
                        break;
                    case "HoraSalida":
                        query = "SELECT * FROM Asistencias WHERE HoraSalida = @valor";
                        break;
                    case "Fecha":
                        query = "SELECT * FROM Asistencias WHERE Fecha = @valor";
                        break;
                    default:
                        throw new Exception("Campo de búsqueda inválido.");
                }

                using (SqlCommand cmd = new SqlCommand(query, cnx))
                {
                    // Agregar el parámetro con el valor adecuado
                    if (campo == "ID_Empleado")
                    {
                        // Validar que el valor sea un entero
                        if (!int.TryParse(valor, out int idEmpleado))
                        {
                            throw new Exception("El ID del empleado debe ser un número entero.");
                        }
                        cmd.Parameters.AddWithValue("@valor", idEmpleado);
                    }
                    else if (campo == "Fecha")
                    {
                        // Validar que el valor sea una fecha
                        if (!DateTime.TryParse(valor, out DateTime fecha))
                        {
                            throw new Exception("El valor de la fecha no es válido.");
                        }
                        cmd.Parameters.AddWithValue("@valor", fecha.Date);
                    }
                    else if (campo == "HoraEntrada" || campo == "HoraSalida")
                    {
                        // Validar que el valor sea una hora
                        if (!TimeSpan.TryParse(valor, out TimeSpan hora))
                        {
                            throw new Exception("El valor de la hora no es válido.");
                        }
                        cmd.Parameters.AddWithValue("@valor", hora);
                    }
                    else
                    {
                        // En caso de otros campos
                        cmd.Parameters.AddWithValue("@valor", valor);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable ObtenerAsistencias(int idEmpleado, DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT HoraEntrada, HoraSalida FROM Asistencias WHERE ID_Empleado = @ID_Empleado AND Fecha BETWEEN @FechaInicio AND @FechaFin", cnx);
                cmd.Parameters.AddWithValue("@ID_Empleado", idEmpleado);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable ObtenerAsistenciasConEmpleado()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                string query = @"
                SELECT e.Nombre + ' ' + e.Apellido1 AS NombreEmpleado, a.Fecha, a.HoraEntrada, a.HoraSalida
                FROM Asistencias a
                INNER JOIN Empleados e ON a.ID_Empleado = e.ID";

                SqlCommand cmd = new SqlCommand(query, cnx);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public void LimpiarAsistencias()
        {
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                string query = "DELETE FROM Asistencias";
                SqlCommand cmd = new SqlCommand(query, cnx);
                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();
            }
        }
    }
}
