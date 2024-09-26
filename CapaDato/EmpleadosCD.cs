using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDato
{
    public class EmpleadoCD
    {
        public static DataTable BuscarEmpleadoPorID(int id)
        {
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                string query = @"
                SELECT e.Nombre, e.Apellido1, e.Apellido2, e.DNI, e.Telefono, e.CorreoElectronico, e.FechaNacimiento, 
                       e.Direccion, e.Distrito,
                       dl.Cargo, dl.Area, dl.EstadoLaboral, dl.Nombre_Supervisor, 
                       da.UniversidadInstituto, da.Carrera
                        FROM Empleados e
                LEFT JOIN DatosLaborales dl ON e.ID = dl.ID_Empleado
                LEFT JOIN DatosAcademicos da ON e.ID = da.ID_Empleado
                WHERE e.ID = @ID";

                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@ID", id);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
        public DataTable ObtenerInformacionEmpleados()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                try
                {
                    string query = @"
                SELECT e.ID, e.Nombre, e.Apellido1, e.Apellido2, e.DNI, e.Telefono, e.CorreoElectronico, e.FechaNacimiento, e.Direccion, e.Distrito,
                       dl.Cargo, dl.Area, dl.EstadoLaboral, dl.Nombre_Supervisor,
                       da.UniversidadInstituto, da.Carrera
                FROM Empleados e
                LEFT JOIN DatosLaborales dl ON e.ID = dl.ID_Empleado
                LEFT JOIN DatosAcademicos da ON e.ID = da.ID_Empleado";

                    SqlCommand cmd = new SqlCommand(query, cnx);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener la información: " + ex.Message);
                }
                finally
                {
                    if (cnx.State == ConnectionState.Open)
                    {
                        cnx.Close();
                    }
                }
            }
            return dt;
        }

        public int InsertarEmpleado(string nombre, string apellido1, string apellido2, string dni, string telefono,
            string correo, DateTime fechaNacimiento, string direccion, string distrito)
        {
            using (SqlConnection conn = ConexionCD.sqlConnection())
            {
                if (conn == null)
                {
                    throw new Exception("No se pudo establecer una conexión con la base de datos.");
                }

                conn.Open();
                string query = "INSERT INTO Empleados (Nombre, Apellido1, Apellido2, DNI, Telefono, CorreoElectronico, FechaNacimiento, Direccion, Distrito) " +
                               "VALUES (@Nombre, @Apellido1, @Apellido2, @DNI, @Telefono, @Correo, @FechaNacimiento, @Direccion, @Distrito); " +
                               "SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Apellido1", apellido1);
                    cmd.Parameters.AddWithValue("@Apellido2", apellido2);
                    cmd.Parameters.AddWithValue("@DNI", dni);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@Distrito", distrito);

                    int empleadoId = Convert.ToInt32(cmd.ExecuteScalar());
                    return empleadoId;
                }
            }
        }

        public void InsertarDatosLaborales(int empleadoId, string cargo, string area, string estadoLaboral, string nombreSupervisor)
        {
            using (SqlConnection conn = ConexionCD.sqlConnection())
            {
                if (conn == null)
                {
                    throw new Exception("No se pudo establecer una conexión con la base de datos.");
                }

                conn.Open();
                string query = "INSERT INTO DatosLaborales (ID_Empleado, Cargo, Area, EstadoLaboral, Nombre_Supervisor) " +
                               "VALUES (@ID_Empleado, @Cargo, @Area, @EstadoLaboral, @NombreSupervisor);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID_Empleado", empleadoId);
                    cmd.Parameters.AddWithValue("@Cargo", cargo);
                    cmd.Parameters.AddWithValue("@Area", area);
                    cmd.Parameters.AddWithValue("@EstadoLaboral", estadoLaboral);
                    cmd.Parameters.AddWithValue("@NombreSupervisor", nombreSupervisor);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertarDatosAcademicos(int empleadoId, string universidadInstituto, string carrera)
        {
            using (SqlConnection conn = ConexionCD.sqlConnection())
            {
                if (conn == null)
                {
                    throw new Exception("No se pudo establecer una conexión con la base de datos.");
                }

                conn.Open();
                string query = "INSERT INTO DatosAcademicos (ID_Empleado, UniversidadInstituto, Carrera) " +
                               "VALUES (@ID_Empleado, @Universidad, @Carrera);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID_Empleado", empleadoId);
                    cmd.Parameters.AddWithValue("@Universidad", universidadInstituto);
                    cmd.Parameters.AddWithValue("@Carrera", carrera);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public DataTable ObtenerInformacionEmpleadoCompleta(int id)
        {
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                string query = @"
                SELECT e.ID, e.Nombre, e.Apellido1, e.Apellido2, e.DNI, e.Telefono, e.CorreoElectronico, 
                       e.FechaNacimiento, e.Direccion, e.Distrito,
                       dl.Cargo, dl.Area, dl.EstadoLaboral, dl.Nombre_Supervisor,
                       da.UniversidadInstituto, da.Carrera
                FROM Empleados e
                LEFT JOIN DatosLaborales dl ON e.ID = dl.ID_Empleado
                LEFT JOIN DatosAcademicos da ON e.ID = da.ID_Empleado
                WHERE e.ID = @ID";

                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@ID", id);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
        public static void ActualizarEmpleado(int idEmpleado, string nombre, string apellido1, string apellido2, string dni, string telefono, string correo, string direccion, string distrito, DateTime fechaNacimiento, string cargo, string area, string estadoLaboral, string nombreSupervisor, string universidadInstituto, string carrera)
        {
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                string query = @"
            UPDATE Empleados
            SET Nombre = @Nombre, Apellido1 = @Apellido1, Apellido2 = @Apellido2, DNI = @DNI, 
                Telefono = @Telefono, CorreoElectronico = @Correo, Direccion = @Direccion, Distrito = @Distrito, 
                FechaNacimiento = @FechaNacimiento
            WHERE ID = @ID;

            UPDATE DatosLaborales
            SET Cargo = @Cargo, Area = @Area, EstadoLaboral = @EstadoLaboral, Nombre_Supervisor = @Supervisor
            WHERE ID_Empleado = @ID;

            UPDATE DatosAcademicos
            SET UniversidadInstituto = @UniversidadInstituto, Carrera = @Carrera
            WHERE ID_Empleado = @ID;";

                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@ID", idEmpleado);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido1", apellido1);

                // Manejar los posibles valores nulos
                cmd.Parameters.AddWithValue("@Apellido2", string.IsNullOrEmpty(apellido2) ? (object)DBNull.Value : apellido2);
                cmd.Parameters.AddWithValue("@DNI", dni);
                cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrEmpty(telefono) ? (object)DBNull.Value : telefono);
                cmd.Parameters.AddWithValue("@Correo", string.IsNullOrEmpty(correo) ? (object)DBNull.Value : correo);
                cmd.Parameters.AddWithValue("@Direccion", string.IsNullOrEmpty(direccion) ? (object)DBNull.Value : direccion);
                cmd.Parameters.AddWithValue("@Distrito", string.IsNullOrEmpty(distrito) ? (object)DBNull.Value : distrito);
                cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);

                cmd.Parameters.AddWithValue("@Cargo", string.IsNullOrEmpty(cargo) ? (object)DBNull.Value : cargo);
                cmd.Parameters.AddWithValue("@Area", string.IsNullOrEmpty(area) ? (object)DBNull.Value : area);
                cmd.Parameters.AddWithValue("@EstadoLaboral", string.IsNullOrEmpty(estadoLaboral) ? (object)DBNull.Value : estadoLaboral);
                cmd.Parameters.AddWithValue("@Supervisor", string.IsNullOrEmpty(nombreSupervisor) ? (object)DBNull.Value : nombreSupervisor);

                // Datos Académicos
                cmd.Parameters.AddWithValue("@UniversidadInstituto", string.IsNullOrEmpty(universidadInstituto) ? (object)DBNull.Value : universidadInstituto);
                cmd.Parameters.AddWithValue("@Carrera", string.IsNullOrEmpty(carrera) ? (object)DBNull.Value : carrera);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();
            }
        }
        public void EliminarEmpleado(int idEmpleado)
        {
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                cnx.Open();
                SqlTransaction transaction = cnx.BeginTransaction();

                try
                {
                    // Eliminar primero en las tablas relacionadas (DatosLaborales y DatosAcademicos)
                    SqlCommand cmdEliminarDatosLaborales = new SqlCommand("DELETE FROM DatosLaborales WHERE ID_Empleado = @ID_Empleado", cnx, transaction);
                    cmdEliminarDatosLaborales.Parameters.AddWithValue("@ID_Empleado", idEmpleado);
                    cmdEliminarDatosLaborales.ExecuteNonQuery();

                    SqlCommand cmdEliminarDatosAcademicos = new SqlCommand("DELETE FROM DatosAcademicos WHERE ID_Empleado = @ID_Empleado", cnx, transaction);
                    cmdEliminarDatosAcademicos.Parameters.AddWithValue("@ID_Empleado", idEmpleado);
                    cmdEliminarDatosAcademicos.ExecuteNonQuery();

                    // Finalmente, eliminamos el registro en la tabla Empleados
                    SqlCommand cmdEliminarEmpleado = new SqlCommand("DELETE FROM Empleados WHERE ID = @ID_Empleado", cnx, transaction);
                    cmdEliminarEmpleado.Parameters.AddWithValue("@ID_Empleado", idEmpleado);
                    cmdEliminarEmpleado.ExecuteNonQuery();

                    // Confirmamos la transacción
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error al eliminar el empleado: " + ex.Message);
                }
            }
        }
        public DataTable BuscarEmpleado(string criterio, string valor)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                string query = @"SELECT e.ID, e.Nombre, e.Apellido1, e.Apellido2, e.DNI, e.Telefono, e.CorreoElectronico,
                                dl.Cargo, dl.Area, dl.EstadoLaboral, dl.Nombre_Supervisor, 
                                da.UniversidadInstituto, da.Carrera
                         FROM Empleados e
                         LEFT JOIN DatosLaborales dl ON e.ID = dl.ID_Empleado
                         LEFT JOIN DatosAcademicos da ON e.ID = da.ID_Empleado
                         WHERE " + criterio + " LIKE @Valor";

                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@Valor", "%" + valor + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

    }
}
