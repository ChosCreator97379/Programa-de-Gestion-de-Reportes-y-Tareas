using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaDato;
using CapaEntidad;

namespace CapaNegocio
{
    public class AsistenciaCN
    {
        public void GuardarAsistencia(int idEmpleado, DateTime fecha, TimeSpan? hora, string tipoRegistro)
        {
            AsistenciaCD asistenciaCD = new AsistenciaCD();
            AsistenciaCE asistencia = new AsistenciaCE
            {
                ID_Empleado = idEmpleado,
                Fecha = fecha,
                HoraEntrada = tipoRegistro == "Entrada" ? hora : (TimeSpan?)null,
                HoraSalida = tipoRegistro == "Salida" ? hora : (TimeSpan?)null
            };
            asistenciaCD.GuardarAsistencia(asistencia);
        }
        public DataTable ObtenerAsistencias()
        {
            AsistenciaCD asistenciaCD = new AsistenciaCD();
            return asistenciaCD.ObtenerAsistencias();
        }
        public void ActualizarAsistencia(int id, DateTime fecha, TimeSpan? horaEntrada, TimeSpan? horaSalida)
        {
            AsistenciaCD asistenciaCD = new AsistenciaCD();
            asistenciaCD.ActualizarAsistencia(id, fecha, horaEntrada, horaSalida);
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
            AsistenciaCD asistenciaCD = new AsistenciaCD();
            return asistenciaCD.BuscarAsistencias(campo, valor);
        }
        public TimeSpan CalcularHorasTrabajadas(int idEmpleado, DateTime fechaInicio, DateTime fechaFin)
        {
            AsistenciaCD asistenciaCD = new AsistenciaCD();
            DataTable dt = asistenciaCD.ObtenerAsistencias(idEmpleado, fechaInicio, fechaFin);

            TimeSpan totalHoras = TimeSpan.Zero;

            foreach (DataRow row in dt.Rows)
            {
                if (row["HoraEntrada"] != DBNull.Value && row["HoraSalida"] != DBNull.Value)
                {
                    // Asumiendo que los datos están almacenados como TIME
                    TimeSpan entrada = (TimeSpan)row["HoraEntrada"];
                    TimeSpan salida = (TimeSpan)row["HoraSalida"];

                    // Si la hora de salida es menor que la de entrada, asumimos que es al día siguiente
                    if (salida < entrada)
                    {
                        salida = salida.Add(TimeSpan.FromDays(1));
                    }

                    // Calcular horas trabajadas
                    TimeSpan horasTrabajadas = salida - entrada;
                    totalHoras += horasTrabajadas;
                }
            }

            return totalHoras;
        }
        private AsistenciaCD asistenciaCD = new AsistenciaCD();

        public DataTable ObtenerAsistenciasConEmpleado()
        {
            return asistenciaCD.ObtenerAsistenciasConEmpleado();
        }

        public void LimpiarAsistencias()
        {
            asistenciaCD.LimpiarAsistencias();
        }
    }
}
