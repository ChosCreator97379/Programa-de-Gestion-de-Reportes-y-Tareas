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
using System.Data.SqlClient;

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
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Guardar tabla como Excel";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Lista de cuentas exportadas
                List<string> cuentasExportadas = ExportarMultiplesTablasAExcel(filePath);

                MessageBox.Show("Las tablas se exportaron correctamente.");

                // Limpia las tablas de la base de datos de las cuentas exportadas
                TareaCN.LimpiarBaseDeDatosPorCuentas(cuentasExportadas);
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
        private List<string> ExportarMultiplesTablasAExcel(string filePath)
        {
            List<string> cuentasExportadas = new List<string>();

            using (var workbook = new XLWorkbook())
            {
                // Obtener todas las cuentas
                List<string> cuentas = TareaCN.ObtenerTodasLasCuentas();

                foreach (string cuenta in cuentas)
                {
                    DataTable dt = TareaCN.ObtenerTareasPorCuentas(cuenta);
                    if (dt.Rows.Count > 0)
                    {
                        // Añadir la cuenta a la lista de cuentas exportadas
                        cuentasExportadas.Add(cuenta);

                        // Crear una hoja por cuenta
                        var hoja = workbook.Worksheets.Add(cuenta);

                        // Título de las columnas
                        hoja.Cell(1, 1).Value = "Cuenta";
                        hoja.Cell(1, 2).Value = "Tareas_Que_Faltan";
                        hoja.Cell(1, 3).Value = "Fecha_Limite";
                        hoja.Cell(1, 4).Value = "Completado";
                        hoja.Cell(1, 5).Value = "Link";

                        // Rellenar datos
                        int fila = 2;
                        foreach (DataRow row in dt.Rows)
                        {
                            hoja.Cell(fila, 1).Value = row["Cuenta"].ToString();
                            hoja.Cell(fila, 2).Value = row["Tareas_Que_Faltan"].ToString();
                            hoja.Cell(fila, 3).Value = row["Fecha_Limite"].ToString();
                            hoja.Cell(fila, 4).Value = row["Completado"].ToString();
                            hoja.Cell(fila, 5).Value = row["Link"].ToString();
                            fila++;
                        }

                        // Ajustar el contenido de las celdas
                        hoja.Columns().AdjustToContents();
                    }
                }

                // Guardar el archivo
                workbook.SaveAs(filePath);
            }

            return cuentasExportadas; // Devolver las cuentas exportadas
        }
        
    }
}
