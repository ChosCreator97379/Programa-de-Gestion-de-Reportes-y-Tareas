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
        public static void InsertarNuevaCuenta(string cuenta)
        {
            TareaCD.InsertarNuevaCuenta(cuenta);
        }

        public static bool VerificarCuentaExiste(string cuenta)
        {
            return TareaCD.VerificarCuentaExiste(cuenta);
        }

        public static DataTable ObtenerTareas()
        {
            return TareaCD.ObtenerTareas();
        }
        public static DataTable BuscarTareasPorCuenta(string cuenta)
        {
            return TareaCD.BuscarTareasPorCuenta(cuenta);
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
    }
}
