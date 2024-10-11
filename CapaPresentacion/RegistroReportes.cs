using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDato;
using ClosedXML.Excel;


namespace CapaPresentacion
{
    public partial class Registro_E_S : Form
    {
        private EmpleadoCN empleadoCN = new EmpleadoCN();
        public Registro_E_S()
        {
            InitializeComponent();
        }



        private void Registro_E_S_Load(object sender, EventArgs e)
        {
            // Rellenar el ComboBox con las opciones de búsqueda
            cmbCampoBusqueda.Items.Add("ID");
            cmbCampoBusqueda.Items.Add("Cuenta");
            cmbCampoBusqueda.Items.Add("Marketing");
            cmbCampoBusqueda.Items.Add("Diseñador");
            cmbCampoBusqueda.Items.Add("Audiovisual");
            cmbCampoBusqueda.SelectedIndex = 0;
            // Cargar los datos de la tabla Reportes
            DataTable dtReportes = ReportesCN.ObtenerReportes();

            if (dtReportes != null)
            {
                dataGridView.DataSource = dtReportes;
            }
            else
            {
                MessageBox.Show("Error al cargar los reportes.");
            }
        }
        private void CargarReportes()
        {
            DataTable dtReportes = ReportesCN.ObtenerReportes();

            if (dtReportes != null)
            {
                dataGridView.DataSource = dtReportes;
            }
            else
            {
                MessageBox.Show("Error al cargar los reportes.");
            }
        }


        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DataTable dtReportes = ReportesCN.ObtenerReportes();

            if (dtReportes != null)
            {
                dataGridView.DataSource = dtReportes;
            }
            else
            {
                MessageBox.Show("Error al cargar los reportes.");
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnBuscarRegistro_Click(object sender, EventArgs e)
        {
            string columnaSeleccionada = cmbCampoBusqueda.SelectedItem.ToString();
            string valorBusqueda = txtBusqueda.Text;

            // Verificar si el valor de búsqueda no está vacío
            if (string.IsNullOrWhiteSpace(valorBusqueda))
            {
                MessageBox.Show("Por favor, ingrese un valor para buscar.");
                return;
            }

            // Realizar la búsqueda en la base de datos
            DataTable dtResultados = ReportesCN.BuscarReporte(columnaSeleccionada, valorBusqueda);

            // Verificar si se encontraron resultados
            if (dtResultados != null && dtResultados.Rows.Count > 0)
            {
                dataGridView.DataSource = dtResultados; // Mostrar los resultados en el DataGridView
            }
            else
            {
                MessageBox.Show("No se encontraron resultados.");
                CargarReportes(); // Recargar todos los reportes si no hay resultados
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AñadirReporte formAgregar = new AñadirReporte();
            formAgregar.FormClosed += new FormClosedEventHandler(FormAgregar_FormClosed); // Suscribirse al evento FormClosed
            formAgregar.Show();
        }
        private void FormAgregar_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Se llama a CargarReportes() para actualizar el DataGridView cuando se cierra el formulario de agregar reporte
            CargarReportes();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int idReporte = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["ID"].Value);
                EditarReporte formEdicion = new EditarReporte(idReporte);
                formEdicion.ShowDialog();
                // Aquí puedes recargar los datos del DataGridView si es necesario
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un reporte para editar.");
            }
        }

        private void inicioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int idReporte = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["ID"].Value);

                // Confirmar la eliminación
                var result = MessageBox.Show("¿Estás seguro de que deseas eliminar este reporte?", "Confirmar Eliminación", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ReportesCN.EliminarReporte(idReporte);
                    MessageBox.Show("Reporte eliminado exitosamente.");

                    // Recargar el DataGridView después de la eliminación
                    CargarReportes();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un reporte para eliminar.");
            }
        }

        private void cmbCampoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila para exportar.");
                return;
            }

            // Crear un nuevo workbook y agregar una hoja de trabajo
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Reporte");

                // Encabezados
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

                worksheet.Range("Q2:S2").Merge().Value = "Horas cumplidas";
                worksheet.Cell("Q3").Value = "    M    ";
                worksheet.Cell("R3").Value = "    D    ";
                worksheet.Cell("S3").Value = "    A    ";

                worksheet.Cell("T3").Value = "Puntaje";

                // Obtener los datos seleccionados
                var filaSeleccionada = dataGridView.SelectedRows[0];

                // Llenar datos - Conversion explícita para evitar errores de tipo
                worksheet.Cell("B4").Value = filaSeleccionada.Cells["ID"].Value?.ToString();
                worksheet.Cell("C4").Value = filaSeleccionada.Cells["Cuenta"].Value?.ToString();

                // Separar nombre y apellido para Marketing, Diseñador y Audiovisual
                var marketing = filaSeleccionada.Cells["Marketing"].Value?.ToString().Split(' ');
                var disenador = filaSeleccionada.Cells["Disenador"].Value?.ToString().Split(' ');
                var audiovisual = filaSeleccionada.Cells["Audiovisual"].Value?.ToString().Split(' ');

                worksheet.Cell("D4").Value = marketing?[0] ?? ""; // Nombre Marketing
                worksheet.Cell("E4").Value = marketing?.Length > 1 ? marketing[1] : ""; // Apellido Marketing

                worksheet.Cell("F4").Value = disenador?[0] ?? ""; // Nombre Diseñador
                worksheet.Cell("G4").Value = disenador?.Length > 1 ? disenador[1] : ""; // Apellido Diseñador

                worksheet.Cell("H4").Value = audiovisual?[0] ?? ""; // Nombre Audiovisual
                worksheet.Cell("I4").Value = audiovisual?.Length > 1 ? audiovisual[1] : ""; // Apellido Audiovisual

                // Llenar horas
                worksheet.Cell("J4").Value = filaSeleccionada.Cells["Hora_01"].Value?.ToString();
                worksheet.Cell("J5").Value = filaSeleccionada.Cells["Hora_02"].Value?.ToString();
                worksheet.Cell("J6").Value = filaSeleccionada.Cells["Hora_03"].Value?.ToString();

                // Llenar detalle del reporte
                worksheet.Cell("K4").Value = filaSeleccionada.Cells["Reporte_01"].Value?.ToString();
                worksheet.Cell("K5").Value = filaSeleccionada.Cells["Reporte_02"].Value?.ToString();
                worksheet.Cell("K6").Value = filaSeleccionada.Cells["Reporte_03"].Value?.ToString();

                // Cumplió la actividad a tiempo? (subida de celda)
                worksheet.Cell("L4").Value = filaSeleccionada.Cells["Cumplio_Actividad_01"].Value?.ToString();
                worksheet.Range("L5:L6").Merge();
                worksheet.Cell("L5").Value = filaSeleccionada.Cells["Cumplio_Actividad_02"].Value?.ToString();

                // Observaciones (subida de celda)
                worksheet.Cell("M4").Value = filaSeleccionada.Cells["Observacion_01"].Value?.ToString();
                worksheet.Cell("M5").Value = filaSeleccionada.Cells["Observacion_02"].Value?.ToString();
                worksheet.Cell("M6").Value = filaSeleccionada.Cells["Observacion_03"].Value?.ToString();

                // Llenar actividades
                worksheet.Cell("N4").Value = filaSeleccionada.Cells["Act_M"].Value?.ToString();
                worksheet.Cell("O4").Value = filaSeleccionada.Cells["Act_D"].Value?.ToString();
                worksheet.Cell("P4").Value = filaSeleccionada.Cells["Act_A"].Value?.ToString();

                // Llenar horas cumplidas
                worksheet.Cell("Q4").Value = filaSeleccionada.Cells["Horas_M"].Value?.ToString();
                worksheet.Cell("R4").Value = filaSeleccionada.Cells["Horas_D"].Value?.ToString();
                worksheet.Cell("S4").Value = filaSeleccionada.Cells["Horas_A"].Value?.ToString();

                // Puntaje
                worksheet.Cell("T4").Value = filaSeleccionada.Cells["Puntaje"].Value?.ToString();

                // Diseño de los encabezados
                var encabezados = worksheet.Range("B2:T3");
                encabezados.Style.Font.Bold = true;
                encabezados.Style.Fill.BackgroundColor = XLColor.LightBlue;
                encabezados.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                encabezados.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                encabezados.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

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

                worksheet.Columns().AdjustToContents();
                // Guardar archivo
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Archivos de Excel (*.xlsx)|*.xlsx",
                    FileName = "ReporteExportado.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Exportación completada con éxito.");
                }
            }


        }
    }
}
