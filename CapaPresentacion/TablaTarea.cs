using CapaDato;
using CapaNegocio;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace CapaPresentacion
{
    public partial class TablaTarea : Form
    {
        public TablaTarea()
        {
            InitializeComponent();
        }

        private void btnGenerarTabla_Click(object sender, EventArgs e)
        {
            GenerarTablaTarea generarTablaTarea = new GenerarTablaTarea();
            generarTablaTarea.ShowDialog(); // Abre el formulario de generación de tareas
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cuenta = txtValorBusqueda.Text; // Cuenta ingresada para buscar
            DataTable dt = TareaCN.ObtenerTareasPorCuenta(cuenta);
            if (dt != null && dt.Rows.Count > 0)
            {
                dgvTareas.DataSource = dt; // Mostrar tareas filtradas por cuenta
            }
            else
            {
                dgvTareas.DataSource = null;
                MessageBox.Show("No se encontraron tareas para la cuenta: " + cuenta);
            }
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargarTareasPorCuenta(string cuenta)
        {
            DataTable dt = TareaCN.ObtenerTareasPorCuenta(cuenta);
            if (dt != null && dt.Rows.Count > 0)
            {
                dgvTareas.DataSource = dt; // dgvTareas es tu DataGridView
            }
            else
            {
                dgvTareas.DataSource = null;
                MessageBox.Show($"No hay tareas para la cuenta {cuenta}.");
            }
        }
        private void CargarTareas()
        {
            DataTable dt = TareaCN.ObtenerTareas(); // Obtener todas las tareas de la base de datos
            if (dt != null && dt.Rows.Count > 0)
            {
                dgvTareas.DataSource = dt; // Cargar las tareas en el DataGridView
            }
            else
            {
                dgvTareas.DataSource = null;
                MessageBox.Show("No hay tareas que mostrar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTareas.SelectedRows.Count > 0) // Verifica que haya al menos una fila seleccionada
            {
                // Confirmar la eliminación
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar las tareas seleccionadas?",
                                                      "Confirmar eliminación",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Recorre las filas seleccionadas en reversa para eliminar sin conflictos
                    foreach (DataGridViewRow row in dgvTareas.SelectedRows)
                    {
                        if (row.Cells["Cuenta"].Value != null && row.Cells["Tareas_Que_Faltan"].Value != null)
                        {
                            string cuenta = row.Cells["Cuenta"].Value.ToString();
                            string tarea = row.Cells["Tareas_Que_Faltan"].Value.ToString();

                            // Elimina la tarea de la base de datos
                            TareaCN.EliminarTarea(cuenta, tarea);

                            // Elimina la fila seleccionada del DataGridView
                            dgvTareas.Rows.RemoveAt(row.Index);
                        }
                    }

                    MessageBox.Show("Tareas eliminadas correctamente.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona al menos una fila para eliminar.");
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Guardar archivo Excel";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    ExportarDatosAExcel(filePath);

                    // Eliminar todas las tareas después de la exportación
                    TareaCN.EliminarTodasLasTareas();

                    // Limpiar el DataGridView
                    dgvTareas.DataSource = null;
                    MessageBox.Show("Datos exportados y eliminados correctamente.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvTareas.SelectedRows.Count > 0)
            {
                // Obtener la cuenta seleccionada
                string cuentaSeleccionada = dgvTareas.SelectedRows[0].Cells["Cuenta"].Value.ToString();

                // Crear una instancia del formulario de edición y pasar la cuenta seleccionada
                EditarTabla Editar = new EditarTabla(cuentaSeleccionada);

                // Mostrar el formulario de edición
                Editar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void CargarDatos()
        {
            // Lógica para cargar los datos en el DataGridView
            DataTable tareas = TareaCN.ObtenerTareas(); // Asegúrate de que este método obtenga todas las tareas actualizadas
            dgvTareas.DataSource = tareas;
        }
        private void ExportarDatosAExcel(string filePath)
        {
            using (XLWorkbook workbook = new XLWorkbook())
            {
                // Crear la hoja de Excel
                IXLWorksheet worksheet = workbook.Worksheets.Add("Tareas");

                // Inicializar fila para las tablas
                int rowIndex = 1;

                // Exportar datos de DataGridView a Excel
                ExportarDataGridViewAExcel(worksheet, dgvTareas, ref rowIndex);

                // Guardar el archivo en la ruta especificada
                workbook.SaveAs(filePath);

                MessageBox.Show("Exportación completada correctamente.", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ExportarDataGridViewAExcel(IXLWorksheet worksheet, DataGridView dgv, ref int rowIndex)
        {
            // Aplicar título de la tabla
            worksheet.Cell(rowIndex, 1).Value = "Tareas";
            worksheet.Cell(rowIndex, 1).Style.Font.Bold = true;
            worksheet.Cell(rowIndex, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Range(rowIndex, 1, rowIndex, dgv.Columns.Count).Merge();
            rowIndex++;

            // Encabezados de columnas (sin mostrar la columna de ID)
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].Name != "ID") // Ocultar columna ID
                {
                    worksheet.Cell(rowIndex, i + 1).Value = dgv.Columns[i].HeaderText;
                    worksheet.Cell(rowIndex, i + 1).Style.Font.Bold = true;
                    worksheet.Cell(rowIndex, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                    worksheet.Cell(rowIndex, i + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }
            }
            rowIndex++;

            // Filas de datos
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv.Columns[j].Name != "ID") // Ocultar columna ID
                    {
                        worksheet.Cell(rowIndex + i, j + 1).Value = dgv.Rows[i].Cells[j].Value?.ToString();
                        worksheet.Cell(rowIndex + i, j + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    }
                }
            }

            // Ajustar tamaño de columnas automáticamente
            worksheet.Columns().AdjustToContents();

            // Añadir espacio antes de la próxima tabla, si hay más
            rowIndex += dgv.Rows.Count + 2;
        }
    }
}
