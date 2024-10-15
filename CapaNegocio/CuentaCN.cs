using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDato;

namespace CapaNegocio
{
    public class CuentaCN
    {
        public static DataTable ListarCuentas()
        {
            return CapaDato.CuentaCD.ObtenerCuentas();
        }
        public static List<string> ListarEmpleadosConCarrera()
        {
            return CapaDato.CuentaCD.ObtenerEmpleadosConCarrera();
        }
        public static bool AgregarCuenta(string cuenta, string marketing, string diseno, string audiovisual)
        {
            return CuentaCD.AgregarCuenta(cuenta, marketing, diseno, audiovisual);
        }
        public static DataTable ObtenerCuentaPorID(int id)
        {
            return CapaDato.CuentaCD.ObtenerCuentaPorID(id);
        }
        public static void EditarCuenta(int id, string cuenta, string marketing, string diseno, string audiovisual)
        {
            CapaDato.CuentaCD.EditarCuenta(id, cuenta, marketing, diseno, audiovisual);
        }
        public static List<string> ObtenerCuenta()
        {
            return CuentaCD.ObtenerCuenta();
        }
        public static DataTable ObtenerDatosCuenta(string cuenta)
        {
            return CuentaCD.ObtenerDatosCuenta(cuenta); // Este método debe estar en CuentaCD
        }
        public static bool EliminarCuenta(int id)
        {
            return CuentaCD.EliminarCuenta(id);
        }
        public static List<string> ListarEmpleadosPorCuenta(string cuenta)
        {
            return CuentaCD.ObtenerEmpleadosPorCuenta(cuenta); // Método que deberás implementar en la Capa de Datos
        }
    }
}
