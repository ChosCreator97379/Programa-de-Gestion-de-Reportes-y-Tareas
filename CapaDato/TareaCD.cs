﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDato
{
    public class TareaCD
    {
        public static void InsertarNuevaCuenta(string cuenta)
        {
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                string query = "INSERT INTO Tareas (Cuenta, Tareas_Que_Faltan, Fecha_Limite, Completado, Link) " +
                               "VALUES (@Cuenta, '', '', '', '')";

                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@Cuenta", cuenta);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();
            }
        }

        public static bool VerificarCuentaExiste(string cuenta)
        {
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                string query = "SELECT COUNT(*) FROM Tareas WHERE Cuenta = @Cuenta";
                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@Cuenta", cuenta);

                cnx.Open();
                int count = (int)cmd.ExecuteScalar();
                cnx.Close();

                return count > 0;
            }
        }

        public static DataTable ObtenerTareas()
        {
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                string query = "SELECT Cuenta, Tareas_Que_Faltan, Fecha_Limite, Completado, Link FROM Tareas";
                SqlDataAdapter adapter = new SqlDataAdapter(query, cnx);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
        public static DataTable BuscarTareasPorCuenta(string cuenta)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnx = ConexionCD.sqlConnection())
            {
                string query = "SELECT Cuenta, Tareas_Que_Faltan, Fecha_Limite, Completado, Link FROM Tareas WHERE Cuenta = @Cuenta";
                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@Cuenta", cuenta);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
