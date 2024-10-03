using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;

namespace CapaNegocio
{
    public class EmpleadoCN
    {
        public static DataTable BuscarEmpleadoPorID(int id)
        {
            return CapaDato.EmpleadoCD.BuscarEmpleadoPorID(id);
        }

        public static DataTable ObtenerInformacionEmpleados()
        {
            EmpleadoCD empleadoCD = new EmpleadoCD();
            return empleadoCD.ObtenerInformacionEmpleados();
        }

        private EmpleadoCD empleadoCD = new EmpleadoCD();

        public void AgregarEmpleadoConDatos(string nombre1, string nombre2, string apellido1, string apellido2, string dni, string telefono,
            string correo, DateTime fechaNacimiento, string direccion, string distrito, string cargo, string area,
            string estadoLaboral, string nombreSupervisor, string universidadInstituto, string carrera)
        {
            int empleadoId = empleadoCD.InsertarEmpleado(nombre1, nombre2, apellido1, apellido2, dni, telefono, correo, fechaNacimiento, direccion, distrito);

            empleadoCD.InsertarDatosLaborales(empleadoId, cargo, area, estadoLaboral, nombreSupervisor);
            empleadoCD.InsertarDatosAcademicos(empleadoId, universidadInstituto, carrera);
        }

        public static void ActualizarEmpleado(int idEmpleado, string nombre1, string nombre2, string apellido1, string apellido2, string dni, string telefono, string correo, string direccion, string distrito, DateTime fechaNacimiento, string cargo, string area, string estadoLaboral, string nombreSupervisor, string universidadInstituto, string carrera)
        {
            EmpleadoCD.ActualizarEmpleado(idEmpleado, nombre1, nombre2, apellido1, apellido2, dni, telefono, correo, direccion, distrito, fechaNacimiento, cargo, area, estadoLaboral, nombreSupervisor, universidadInstituto, carrera);
        }
        public void EliminarEmpleado(int idEmpleado)
        {
            EmpleadoCD empleadoCD = new EmpleadoCD();  // Capa de datos
            empleadoCD.EliminarEmpleado(idEmpleado);  // Llamamos al método de la capa de datos
        }
        public DataTable BuscarEmpleado(string criterio, string valor)
        {
            EmpleadoCD empleadoCD = new EmpleadoCD();
            return empleadoCD.BuscarEmpleado(criterio, valor);
        }
        public static DataTable ObtenerEmpleadosConCarreras()
        {
            return EmpleadoCD.ObtenerEmpleadosConCarreras();
        }
    }
}

