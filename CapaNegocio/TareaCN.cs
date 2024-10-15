using CapaDato;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class TareaCN
    {
        public static DataTable ObtenerTareas()
        {
            return TareaCD.ObtenerTareas();
        }
        public static DataTable ObtenerTareasPorCuenta(string cuenta)
        {
            return TareaCD.ObtenerTareasPorCuenta(cuenta);
        }
        public static void InsertarTarea(string cuenta, string tarea, string fechaLimite, string completado, string link)
        {
            TareaCD.InsertarTarea(cuenta, tarea, fechaLimite, completado, link); // Llama al método de la CapaDatos
        }
        public static void EliminarTarea(string cuenta, string tarea)
        {
            TareaCD.EliminarTarea(cuenta, tarea); // Llamada al método de la capa de datos
        }
        public static DataTable ObtenerCuentasRelacionadas(string cuentaBase)
        {
            return TareaCD.ObtenerCuentasRelacionadas(cuentaBase);
        }
        public static void ActualizarTarea(int id, string fechaLimite, string completado, string link)
        {
            TareaCD.ActualizarTarea(id, fechaLimite, completado, link);
        }
        /*
        public static void LimpiarBaseDeDatosPorCuentas(List<string> cuentas)
        {
            TareaCD.LimpiarTablasPorCuenta(cuentas); // Llamada al método de la capa de datos
        }
        */

        public static List<string> ObtenerTodasLasCuentas()
        {
            return TareaCD.ObtenerTodasLasCuentas(); // Método que obtiene todas las cuentas de la base de datos
        }
        public static DataTable ObtenerTareasPorCuentas(string cuenta)
        {
            return TareaCD.ObtenerTareasPorCuentas(cuenta);
        }
    }
}
