using CapaDato;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class ReporteDescarga : Form
    {
        public ReporteDescarga()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpInicio.Value;
            DateTime fechaFinal = dtpFinal.Value;

            // Verificar que la fecha de inicio no sea mayor que la fecha final
            if (fechaInicio > fechaFinal)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.");
                return;
            }

            // Crear un nuevo workbook
            using (var workbook = new XLWorkbook())
            {
                // Conectar a la base de datos y obtener los datos
                using (SqlConnection cnx = ConexionCD.sqlConnection())
                {
                    cnx.Open();
                    string query = "SELECT * FROM Reportes WHERE Fecha BETWEEN @fechaInicio AND @fechaFinal";
                    SqlCommand cmd = new SqlCommand(query, cnx);
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Agrupar los datos por cuenta
                    var cuentas = dt.AsEnumerable()
                                    .GroupBy(r => r.Field<string>("Cuenta"));

                    foreach (var grupo in cuentas)
                    {
                        string nombreCuenta = grupo.Key;
                        var worksheet = workbook.Worksheets.Add(nombreCuenta);

                        // Añadir encabezados
                        worksheet.Cell("A2").Value = "Fecha";
                        worksheet.Cell("B2").Value = "ID";
                        worksheet.Cell("C2").Value = "Cuenta";
                        worksheet.Range("D2:E2").Merge().Value = "Marketing";
                        worksheet.Range("D3").Merge().Value = "Nombre";
                        worksheet.Range("E3").Merge().Value = "Apellido";
                        worksheet.Range("F2:G2").Merge().Value = "Diseñador";
                        worksheet.Range("F3").Merge().Value = "Nombre";
                        worksheet.Range("G3").Merge().Value = "Apellido";
                        worksheet.Range("H2:I2").Merge().Value = "Audiovisual";
                        worksheet.Range("H3").Merge().Value = "Nombre";
                        worksheet.Range("I3").Merge().Value = "Apellido";
                        worksheet.Cell("J2").Value = "Hora";
                        worksheet.Range("K2:M2").Merge().Value = "Control";
                        worksheet.Cell("K3").Value = "Detalle del Reporte";
                        worksheet.Cell("L3").Value = "Cumplió a tiempo?";
                        worksheet.Cell("M3").Value = "Observación";
                        worksheet.Range("N2:P2").Merge().Value = "Actividades";
                        worksheet.Cell("N3").Value = "M";
                        worksheet.Cell("O3").Value = "D";
                        worksheet.Cell("P3").Value = "A";
                        worksheet.Range("Q2:S2").Merge().Value = "Puntajes";
                        worksheet.Cell("Q3").Value = "M";
                        worksheet.Cell("R3").Value = "D";
                        worksheet.Cell("S3").Value = "A";
                        worksheet.Cell("T3").Value = "Puntaje";

                        int row = 4; // Comenzar a llenar desde la fila 4
                        for (int col = 1; col <= worksheet.LastColumnUsed().ColumnNumber(); col++)
                        {
                            worksheet.Column(col).AdjustToContents();
                        }

                        // Llenar los datos
                        foreach (var fila in grupo.OrderBy(r => r.Field<DateTime>("Fecha")))
                        {
                            worksheet.Cell($"A{row}").Value = fila.Field<DateTime>("Fecha");
                            worksheet.Cell($"A{row}").Style.DateFormat.Format = "dd/MM/yyyy";
                            worksheet.Cell($"B{row}").Value = fila.Field<int>("ID");
                            worksheet.Cell($"C{row}").Value = fila.Field<string>("Cuenta");

                            // Separar nombre y apellido para Marketing, Diseñador y Audiovisual
                            var marketing = fila.Field<string>("Marketing")?.Split(' ');
                            var disenador = fila.Field<string>("Disenador")?.Split(' ');
                            var audiovisual = fila.Field<string>("Audiovisual")?.Split(' ');

                            worksheet.Cell($"D{row}").Value = marketing?[0] ?? ""; // Nombre Marketing
                            worksheet.Cell($"E{row}").Value = marketing?.Length > 1 ? marketing[1] : ""; // Apellido Marketing

                            worksheet.Cell($"F{row}").Value = disenador?[0] ?? ""; // Nombre Diseñador
                            worksheet.Cell($"G{row}").Value = disenador?.Length > 1 ? disenador[1] : ""; // Apellido Diseñador

                            worksheet.Cell($"H{row}").Value = audiovisual?[0] ?? ""; // Nombre Audiovisual
                            worksheet.Cell($"I{row}").Value = audiovisual?.Length > 1 ? audiovisual[1] : ""; // Apellido Audiovisual

                            // Llenar horas y reportes
                            worksheet.Cell($"J{row}").Value = fila.Field<TimeSpan?>("Hora_01")?.ToString();
                            worksheet.Cell($"K{row}").Value = fila.Field<string>("Reporte_01");
                            worksheet.Cell($"L{row}").Value = fila.Field<string>("Cumplio_Actividad_01");
                            worksheet.Cell($"M{row}").Value = fila.Field<string>("Observacion_01");

                            // Llenar actividades
                            worksheet.Cell($"N{row}").Value = fila.Field<string>("Act_M"); // Actividad M
                            worksheet.Cell($"O{row}").Value = fila.Field<string>("Act_D"); // Actividad D
                            worksheet.Cell($"P{row}").Value = fila.Field<string>("Act_A"); // Actividad A

                            // Llenar horas cumplidas
                            worksheet.Cell($"Q{row}").Value = fila.Field<int?>("Horas_M")?.ToString(); // Horas M
                            worksheet.Cell($"R{row}").Value = fila.Field<int?>("Horas_D")?.ToString(); // Horas D
                            worksheet.Cell($"S{row}").Value = fila.Field<int?>("Horas_A")?.ToString(); // Horas A

                            // Llenar puntaje
                            worksheet.Cell($"T{row}").Value = fila.Field<int?>("Puntaje")?.ToString(); // Puntaje

                            // Aumentar la fila
                            row++;

                            // Si hay más reportes, llenarlos (ejemplo para Hora_02 y Hora_03)
                            if (!string.IsNullOrEmpty(fila.Field<string>("Reporte_02")))
                            {
                                worksheet.Cell($"J{row}").Value = fila.Field<TimeSpan?>("Hora_02")?.ToString();
                                worksheet.Cell($"K{row}").Value = fila.Field<string>("Reporte_02");
                                worksheet.Cell($"L{row}").Value = fila.Field<string>("Cumplio_Actividad_02");
                                worksheet.Cell($"M{row}").Value = fila.Field<string>("Observacion_02");

                                // Llenar actividades
                                row++;
                            }

                            if (!string.IsNullOrEmpty(fila.Field<string>("Reporte_03")))
                            {
                                worksheet.Cell($"J{row}").Value = fila.Field<TimeSpan?>("Hora_03")?.ToString();
                                worksheet.Cell($"K{row}").Value = fila.Field<string>("Reporte_03");
                                worksheet.Cell($"M{row}").Value = fila.Field<string>("Observacion_03");
                                row++;
                            }
                            

                            // Separación de reportes
                            worksheet.Row(row).InsertRowsAbove(1); // Inserta una fila en blanco como separación
                            row++;
                        }

                        var rangoDatos = worksheet.Range($"A2:T{row - 1}"); // Ajusta el rango según tus datos
                        rangoDatos.Style.Border.OutsideBorder = XLBorderStyleValues.Thin; // Borde exterior
                        rangoDatos.Style.Border.InsideBorder = XLBorderStyleValues.Thin; // Bordes interiores

                        worksheet.Column("A").Width = 15; // Ancho para la columna de fecha
                        worksheet.Column("B").Width = 10; // Ancho para ID
                        worksheet.Column("C").Width = 20; // Ancho para Cuenta
                        worksheet.Column("D").Width = 15; // Ancho para Marketing
                        worksheet.Column("E").Width = 15; // Ancho para Marketing
                        worksheet.Column("F").Width = 15; // Ancho para Marketing
                        worksheet.Column("G").Width = 15; // Ancho para Marketing
                        worksheet.Column("H").Width = 15; // Ancho para Marketing
                        worksheet.Column("I").Width = 15; // Ancho para Marketing
                        worksheet.Column("J").Width = 15; // Ancho para Marketing
                        worksheet.Column("K").Width = 15; // Ancho para Marketing
                        worksheet.Column("L").Width = 15; // Ancho para Marketing
                        worksheet.Column("M").Width = 15; // Ancho para Marketing
                        worksheet.Column("N").Width = 15; // Ancho para Marketing
                        worksheet.Column("O").Width = 15; // Ancho para Marketing
                        worksheet.Column("P").Width = 15; // Ancho para Marketing
                        worksheet.Column("Q").Width = 15; // Ancho para Marketing
                        worksheet.Column("R").Width = 15; // Ancho para Marketing
                        worksheet.Column("S").Width = 15; // Ancho para Marketing
                        worksheet.Column("T").Width = 15; // Ancho para Marketing

                        // Aplicar el diseño y estilo (opcional)
                        var encabezados = worksheet.Range("A2:T3");
                        encabezados.Style.Font.Bold = true;
                        encabezados.Style.Fill.BackgroundColor = XLColor.LightBlue;
                        encabezados.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        encabezados.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        encabezados.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        worksheet.Range("A2:A3").Style.Fill.BackgroundColor = XLColor.BlueBell;
                        worksheet.Range("B2:B3").Style.Fill.BackgroundColor = XLColor.Orange;   // ID
                        worksheet.Range("C2:C3").Style.Fill.BackgroundColor = XLColor.LightCoral; // Cuenta
                        worksheet.Range("D2:E3").Style.Fill.BackgroundColor = XLColor.Yellow;   // Marketing
                        worksheet.Range("F2:G3").Style.Fill.BackgroundColor = XLColor.Aqua;     // Diseñador
                        worksheet.Range("H2:I3").Style.Fill.BackgroundColor = XLColor.Green;    // Audiovisual
                        worksheet.Range("J2:J3").Style.Fill.BackgroundColor = XLColor.LightPink; // Hora
                        worksheet.Range("K2:M2").Style.Fill.BackgroundColor = XLColor.LightSkyBlue; // Control
                        worksheet.Range("K3").Style.Fill.BackgroundColor = XLColor.LightSkyBlue;
                        worksheet.Range("L3").Style.Fill.BackgroundColor = XLColor.LightSkyBlue;
                        worksheet.Range("M3").Style.Fill.BackgroundColor = XLColor.LightSkyBlue;
                        worksheet.Range("N2:P2").Style.Fill.BackgroundColor = XLColor.LightGoldenrodYellow; // Actividades
                        worksheet.Range("N3").Style.Fill.BackgroundColor = XLColor.LightGoldenrodYellow;
                        worksheet.Range("O3").Style.Fill.BackgroundColor = XLColor.LightGoldenrodYellow;
                        worksheet.Range("P3").Style.Fill.BackgroundColor = XLColor.LightGoldenrodYellow;
                        worksheet.Range("Q2:S2").Style.Fill.BackgroundColor = XLColor.LightSteelBlue; // Horas cumplidas
                        worksheet.Range("Q3").Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
                        worksheet.Range("R3").Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
                        worksheet.Range("S3").Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
                        worksheet.Range("T3").Style.Fill.BackgroundColor = XLColor.LightGreen;  // Puntaje


                    }

                }

                // Guardar el archivo de Excel
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    FileName = "Reportes.xlsx",
                    Filter = "Excel Files|*.xlsx",
                    Title = "Guardar archivo de Excel"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Reportes descargados exitosamente.");
                    this.Close();
                }
            }
        }
    }
    }

