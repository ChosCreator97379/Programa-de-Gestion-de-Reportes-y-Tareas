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
    }
}
