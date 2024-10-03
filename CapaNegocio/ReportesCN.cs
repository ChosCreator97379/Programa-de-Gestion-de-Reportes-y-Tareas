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
    }
}