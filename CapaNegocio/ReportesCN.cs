using System;
using System.Data;
using CapaDato;
using CapaNegocio;
using DocumentFormat.OpenXml.Bibliography;

namespace CapaNegocio
{
    public class ReportesCN
    {
        // No se necesita crear la instancia de ReportesCD, dado que el método es estático
        public static DataTable ObtenerReportes()
        {
            return ReportesCD.ObtenerReportes();
        }
        private ReportesCD reportesCD = new ReportesCD();
        public void CrearReporte(string cuenta, string marketing, string disenador, string audiovisual)
        {
            DateTime fechaActual = DateTime.Now;
            reportesCD.AgregarReporte(fechaActual, cuenta, marketing, disenador, audiovisual);
        }
        public static DataTable ObtenerReportePorID(int id)
        {
            return CapaDato.ReportesCD.ObtenerReportePorID(id);
        }

        public static void EditarReporte(int id, string cuenta, string marketing, string disenador, string audiovisual,
                                          DateTime fecha, string cumplioActividad1, string cumplioActividad2,
                                          string hora1, string reporte1, string observacion1, string hora2, string reporte2,
                                          string observacion2, string hora3, string reporte3, string observacion3,
                                          string actM, string actD, string actA, int horasM, int horasD, int horasA, int puntaje)
        {
            CapaDato.ReportesCD.EditarReporte(id, cuenta, marketing, disenador, audiovisual, fecha, cumplioActividad1, cumplioActividad2,
                                               hora1, reporte1, observacion1, hora2, reporte2, observacion2,
                                               hora3, reporte3, observacion3, actM, actD, actA, horasM, horasD, horasA, puntaje);
        }

        public static DataTable ObtenerEmpleados()
        {
            return CapaDato.ReportesCD.ObtenerEmpleados();
        }
    }

}