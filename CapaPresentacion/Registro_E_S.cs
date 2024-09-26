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
        private AsistenciaCN asistenciaCN = new AsistenciaCN();
        public Registro_E_S()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Registro_E_S_Load(object sender, EventArgs e)
        {
            // Poblar el ComboBox con los campos de búsqueda
            cmbCampoBusqueda.Items.Add("ID_Empleado");
            cmbCampoBusqueda.Items.Add("HoraEntrada");
            cmbCampoBusqueda.Items.Add("HoraSalida");
            cmbCampoBusqueda.Items.Add("Fecha");
            cmbCampoBusqueda.SelectedIndex = 0; // Seleccionar el primer elemento por defecto
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                if (int.TryParse(txtId.Text, out id))
                {
                    DataTable dt = CapaNegocio.EmpleadoCN.BuscarEmpleadoPorID(id);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        txtNombre.Text = row["Nombre"].ToString();
                        txtApellido.Text = $"{row["Apellido1"]} {row["Apellido2"]}";
                        txtCargo.Text = row["Cargo"].ToString();
                        txtArea.Text = row["Area"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún empleado con ese ID.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un ID válido.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idEmpleado = Convert.ToInt32(txtId.Text); // ID del empleado que buscaste
            DateTime fecha = Fecha.Value; // Fecha seleccionada
            TimeSpan hora = Hora.Value.TimeOfDay; // Hora seleccionada
            string tipoRegistro = txtTipoRegistro.SelectedItem.ToString(); // 'Entrada' o 'Salida'

            asistenciaCN.GuardarAsistencia(idEmpleado, fecha, hora, tipoRegistro);

            MessageBox.Show("Asistencia registrada correctamente.");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = asistenciaCN.ObtenerAsistencias();
                if (dt != null && dt.Rows.Count > 0)
                {
                    dataGridView.AutoGenerateColumns = true; // Deshabilitar la autogeneración de columnas
                    dataGridView.DataSource = dt; // Asignar el DataTable al DataGridView
                }
                else
                {
                    dataGridView.DataSource = null;
                    MessageBox.Show("No se encontraron datos para mostrar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los datos: {ex.Message}");
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                // Obtén el ID del registro seleccionado. Suponiendo que el ID está en la primera columna.
                int id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value);

                // Abre el formulario de edición y pasa el ID del registro
                EditarRegistro editarFormulario = new EditarRegistro(id);
                editarFormulario.ShowDialog();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Obtener el ID de la fila seleccionada
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["ID"].Value);

                // Crear una nueva instancia del formulario de edición, pasando el ID del registro
                EditarRegistro editarRegistro = new EditarRegistro(id);

                // Mostrar el formulario de edición
                editarRegistro.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0) // Verificar si hay una fila seleccionada
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["ID"].Value); // Obtener el ID de la fila seleccionada

                // Confirmación de eliminación
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool eliminado = asistenciaCN.EliminarAsistencia(id); // Llamar al método de la capa de negocio
                    if (eliminado)
                    {
                        MessageBox.Show("Registro eliminado correctamente.");
                        btnActualizar_Click(sender, e); // Refrescar el DataGridView después de la eliminación
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el registro.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un registro para eliminar.");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);

            // Restablecer los DateTimePicker al valor actual
            Fecha.Value = DateTime.Now;
            Hora.Value = DateTime.Now;

            // También puedes limpiar otros controles si los tienes, como ComboBox, etc.
        }
        private void LimpiarControles(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                else if (control.HasChildren)
                {
                    LimpiarControles(control); // Llamada recursiva para los controles anidados
                }
            }
        }

        private void btnBuscarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el campo seleccionado y el valor de búsqueda
                string campoSeleccionado = cmbCampoBusqueda.SelectedItem.ToString();
                string valorBusqueda = txtBusqueda.Text.Trim();

                if (string.IsNullOrEmpty(valorBusqueda))
                {
                    MessageBox.Show("Por favor, ingresa un valor para buscar.");
                    return;
                }

                // Llamar al método de la capa de negocio para realizar la búsqueda
                DataTable dt = asistenciaCN.BuscarAsistencias(campoSeleccionado, valorBusqueda);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dataGridView.DataSource = dt;
                }
                else
                {
                    dataGridView.DataSource = null;
                    MessageBox.Show("No se encontraron registros que coincidan con la búsqueda.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la búsqueda: {ex.Message}");
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            CalcularHorasSemanales calcularhorassemanasles = new CalcularHorasSemanales();
            calcularhorassemanasles.Show();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AsistenciaCN asistenciaCN = new AsistenciaCN();
                DataTable dt = asistenciaCN.ObtenerAsistenciasConEmpleado();

                // Crear un archivo Excel
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Asistencias");

                    // Añadir encabezados
                    worksheet.Cell(1, 1).Value = "Nombre Empleado";
                    worksheet.Cell(1, 2).Value = "Fecha";
                    worksheet.Cell(1, 3).Value = "Hora Entrada";
                    worksheet.Cell(1, 4).Value = "Hora Salida";
                    worksheet.Cell(1, 5).Value = "Horas Totales";

                    // Estilizar encabezados
                    var headerRange = worksheet.Range("A1:E1");
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;
                    headerRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    headerRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                    headerRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    headerRange.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Añadir los datos al Excel
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var fila = dt.Rows[i];
                        string nombreEmpleado = fila["NombreEmpleado"].ToString();
                        DateTime fecha = Convert.ToDateTime(fila["Fecha"]);
                        TimeSpan horaEntrada = TimeSpan.Parse(fila["HoraEntrada"].ToString());
                        TimeSpan horaSalida = TimeSpan.Parse(fila["HoraSalida"].ToString());

                        // Calcular las horas trabajadas
                        TimeSpan horasTrabajadas = horaSalida - horaEntrada;

                        // Añadir los valores a la hoja de cálculo
                        worksheet.Cell(i + 2, 1).Value = nombreEmpleado;
                        worksheet.Cell(i + 2, 2).Value = fecha.ToShortDateString();
                        worksheet.Cell(i + 2, 3).Value = horaEntrada.ToString(@"hh\:mm");
                        worksheet.Cell(i + 2, 4).Value = horaSalida.ToString(@"hh\:mm");
                        worksheet.Cell(i + 2, 5).Value = horasTrabajadas.ToString(@"hh\:mm");
                    }

                    // Estilizar las celdas de datos
                    var dataRange = worksheet.Range("A2:E" + (dt.Rows.Count + 1));
                    dataRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    dataRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                    dataRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    dataRange.Style.Border.RightBorder = XLBorderStyleValues.Thin;

                    // Ajustar el ancho de las columnas
                    worksheet.Columns().AdjustToContents();

                    // Guardar el archivo en el escritorio
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\RegistroAsistencias.xlsx";
                    workbook.SaveAs(path);

                    MessageBox.Show("El archivo ha sido guardado en el escritorio.");
                }

                // Limpiar la tabla de asistencias
                asistenciaCN.LimpiarAsistencias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar a Excel: {ex.Message}");
            }
        }
    }
}
