using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDato
{
    public class CuentaCD
    {
        public static DataTable ObtenerCuentas()
        {
            DataTable dtCuentas = new DataTable();
            try
            {
                using (SqlConnection cn = ConexionCD.sqlConnection())
                {
                    cn.Open();
                    string query = "SELECT ID, Cuenta, Marketing, Diseno, Audiovisual FROM Cuentas";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtCuentas);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener las cuentas: " + ex.Message);
            }
            return dtCuentas;
        }
        public static List<string> ObtenerEmpleadosConCarrera()
        {
            List<string> listaEmpleados = new List<string>();

            try
            {
                using (SqlConnection cn = ConexionCD.sqlConnection())
                {
                    cn.Open();
                    string query = @"
                        SELECT e.Nombre1, e.Apellido1, da.Carrera 
                        FROM Empleados e
                        JOIN DatosAcademicos da ON e.ID = da.ID_Empleado";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nombre1 = reader["Nombre1"].ToString();
                                string apellido1 = reader["Apellido1"].ToString();
                                string carrera = reader["Carrera"].ToString();

                                // Formato: Nombre Apellido (Carrera)
                                string empleadoInfo = $"{nombre1} {apellido1} ({carrera})";
                                listaEmpleados.Add(empleadoInfo);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener los empleados: " + ex.Message);
            }

            return listaEmpleados;
        }
        public static bool AgregarCuenta(string cuenta, string marketing, string diseno, string audiovisual)
        {
            try
            {
                using (SqlConnection cn = ConexionCD.sqlConnection())
                {
                    cn.Open();
                    string query = @"INSERT INTO Cuentas (Cuenta, Marketing, Diseno, Audiovisual)
                                     VALUES (@Cuenta, @Marketing, @Diseno, @Audiovisual)";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        // Pasar los parámetros
                        cmd.Parameters.AddWithValue("@Cuenta", cuenta);
                        cmd.Parameters.AddWithValue("@Marketing", marketing);
                        cmd.Parameters.AddWithValue("@Diseno", diseno);
                        cmd.Parameters.AddWithValue("@Audiovisual", audiovisual);

                        // Ejecutar el comando
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Si al menos una fila fue afectada, la inserción fue exitosa
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al agregar la cuenta: " + ex.Message);
            }
        }
        public static DataTable ObtenerCuentaPorID(int id)
        {
            using (SqlConnection connection = ConexionCD.sqlConnection())
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM Cuentas WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }
        public static void EditarCuenta(int id, string cuenta, string marketing, string diseno, string audiovisual)
        {
            using (SqlConnection connection = ConexionCD.sqlConnection())
            {
                string query = "UPDATE Cuentas SET Cuenta = @cuenta, Marketing = @marketing, Diseno = @diseno, Audiovisual = @audiovisual WHERE ID = @id";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@cuenta", cuenta);
                cmd.Parameters.AddWithValue("@marketing", marketing);
                cmd.Parameters.AddWithValue("@diseno", diseno);
                cmd.Parameters.AddWithValue("@audiovisual", audiovisual);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static List<string> ObtenerCuenta()
        {
            List<string> cuentas = new List<string>();

            using (SqlConnection conexion = ConexionCD.sqlConnection())
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("SELECT Cuenta FROM Cuentas", conexion);
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        cuentas.Add(reader["Cuenta"].ToString());
                    }
                }
                catch (SqlException ex)
                {
                    // Manejar la excepción
                    Console.WriteLine("Error al obtener las cuentas: " + ex.Message);
                }
            }

            return cuentas;
        }
        public static DataTable ObtenerDatosCuenta(string cuenta)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conexion = ConexionCD.sqlConnection())
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("SELECT * FROM Cuentas WHERE Cuenta = @Cuenta", conexion);
                    comando.Parameters.AddWithValue("@Cuenta", cuenta);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    adapter.Fill(dt);
                }
                catch (SqlException ex)
                {
                    // Manejar la excepción
                    Console.WriteLine("Error al obtener los datos de la cuenta: " + ex.Message);
                }
            }

            return dt;
        }
        public static bool EliminarCuenta(int id)
        {
            using (SqlConnection conexion = ConexionCD.sqlConnection())
            {
                string query = "DELETE FROM Cuentas WHERE ID = @ID";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@ID", id);
                    conexion.Open();

                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0; // Devuelve true si se eliminó una fila
                }
            }
        }
        public static List<string> ObtenerEmpleadosPorCuenta(string cuenta)
        {
            List<string> empleados = new List<string>();
            using (SqlConnection con = ConexionCD.sqlConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Marketing, Diseno, Audiovisual FROM Cuentas WHERE Cuenta = @cuenta", con);
                cmd.Parameters.AddWithValue("@cuenta", cuenta);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Agregar los nombres de los empleados a la lista
                    empleados.Add(reader["Marketing"].ToString());
                    empleados.Add(reader["Diseno"].ToString());
                    empleados.Add(reader["Audiovisual"].ToString());
                }
            }
            return empleados;
        }

    }
}
