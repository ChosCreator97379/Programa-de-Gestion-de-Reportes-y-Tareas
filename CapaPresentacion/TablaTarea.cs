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
            if (dgvTareas.SelectedRows.Count > 0) // Verifica que se haya seleccionado una fila
            {
                // Obtén la cuenta y la tarea de la fila seleccionada
                string cuenta = dgvTareas.SelectedRows[0].Cells["Cuenta"].Value.ToString();
                string tarea = dgvTareas.SelectedRows[0].Cells["Tareas_Que_Faltan"].Value.ToString();

                // Confirmar la eliminación
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta tarea?",
                                                      "Confirmar eliminación",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Elimina la tarea de la base de datos
                    TareaCN.EliminarTarea(cuenta, tarea);

                    // Elimina la fila seleccionada del DataGridView
                    dgvTareas.Rows.RemoveAt(dgvTareas.SelectedRows[0].Index);

                    MessageBox.Show("Tarea eliminada correctamente.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.");
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            // Abrir un cuadro de diálogo para guardar el archivo Excel
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.Title = "Guardar archivo Excel";
                sfd.FileName = "Tareas.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (ExcelPackage excel = new ExcelPackage())
                    {
                        // Crear una hoja de cálculo
                        var workSheet = excel.Workbook.Worksheets.Add("Tareas");

                        // Establecer el encabezado
                        workSheet.Cells[1, 1].Value = "Cuenta";
                        workSheet.Cells[1, 2].Value = "Tareas Que Faltan";
                        workSheet.Cells[1, 3].Value = "Fecha Limite";
                        workSheet.Cells[1, 4].Value = "Completado";
                        workSheet.Cells[1, 5].Value = "Link";

                        // Agregar los datos del DataGridView
                        for (int i = 0; i < dgvTareas.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvTareas.Columns.Count; j++)
                            {
                                workSheet.Cells[i + 2, j + 1].Value = dgvTareas.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        // Ajustar el ancho de las columnas
                        workSheet.Cells.AutoFitColumns();

                        // Guardar el archivo Excel
                        FileInfo excelFile = new FileInfo(sfd.FileName);
                        excel.SaveAs(excelFile);
                    }

                    MessageBox.Show("Datos exportados correctamente a Excel.");
                }
            }
        }
    }
}
