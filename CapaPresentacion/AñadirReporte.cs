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
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class AñadirReporte : Form
    {
        public AñadirReporte()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AñadirReporte_Load(object sender, EventArgs e)
        {
            // Cargar empleados y ajustar ancho de ComboBox en un solo ciclo
            foreach (var comboBox in new[] { cmbMarketing, cmbDiseñador, cmbAudiovisual })
            {
                cargarCuentas();
                // Cargar empleados en ComboBox de Marketing, Diseñador y Audiovisual
                CargarEmpleadosEnComboBox(cmbMarketing);
                CargarEmpleadosEnComboBox(cmbDiseñador);
                CargarEmpleadosEnComboBox(cmbAudiovisual);
                AjustarAnchoComboBox(comboBox);
            }
        }

        private void CargarEmpleadosEnComboBox(ComboBox comboBox)
        {
            DataTable dtEmpleados = EmpleadoCN.ObtenerEmpleadosConCarreras();

            if (dtEmpleados != null)
            {
                comboBox.Items.AddRange(
                    dtEmpleados.Rows
                    .Cast<DataRow>()
                    .Select(row => $"{row["Nombre1"]} {row["Apellido1"]} ({row["Carrera"]})")
                    .ToArray()
                );
            }
            else
            {
                MessageBox.Show("Error al cargar los empleados.");
            }
        }

        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            if (comboBox.SelectedItem != null)
            {
                // Extraer la parte del nombre y apellido, quitando lo que esté entre paréntesis
                string nombresYApellidos = comboBox.SelectedItem.ToString().Split('(')[0].Trim();

                // Dividir por espacios para obtener las palabras del nombre completo
                string[] partes = nombresYApellidos.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (partes.Length >= 2)
                {
                    // Construir el valor correcto del primer nombre y primer apellido
                    string nuevoValor = $"{partes[0]} {partes[1]}";

                    // Remover temporalmente el SelectedIndexChanged para evitar la recursividad
                    comboBox.SelectedIndexChanged -= cmb_SelectedIndexChanged;

                    // Actualizar el valor seleccionado con el nuevo formato
                    comboBox.Items[comboBox.SelectedIndex] = nuevoValor;
                    comboBox.SelectedItem = nuevoValor;

                    // Volver a añadir el event handler
                    comboBox.SelectedIndexChanged += cmb_SelectedIndexChanged;
                }
            }
        }

        private void AjustarAnchoComboBox(ComboBox comboBox)
        {
            using (Graphics graphics = comboBox.CreateGraphics())
            {
                Font font = comboBox.Font;
                int maxWidth = comboBox.Items.Cast<object>()
                    .Max(item => (int)graphics.MeasureString(item.ToString(), font).Width);

                comboBox.DropDownWidth = maxWidth + 20; // Ajusta el ancho con margen adicional
            }
        }
        private void cmbAudiovisual_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void cmbDiseñador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cmbMarketing_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string cuenta = txtCuenta.Text;

            // Obtener los nombres completos si están seleccionados, o establecer un valor por defecto (vacío)
            string marketing = cmbMarketing.SelectedItem != null ? ObtenerNombreCompleto(cmbMarketing.SelectedItem.ToString()) : string.Empty;
            string disenador = cmbDiseñador.SelectedItem != null ? ObtenerNombreCompleto(cmbDiseñador.SelectedItem.ToString()) : string.Empty;
            string audiovisual = cmbAudiovisual.SelectedItem != null ? ObtenerNombreCompleto(cmbAudiovisual.SelectedItem.ToString()) : string.Empty;

            // Crear una instancia de la capa de negocio
            ReportesCN reportesCN = new ReportesCN();
            reportesCN.CrearReporte(cuenta, marketing, disenador, audiovisual);

            // Opcional: Mostrar un mensaje de éxito o limpiar los campos
            MessageBox.Show("Reporte agregado exitosamente.");

            // Cerrar el formulario después de agregar el reporte
            this.Close();
        }
        private string ObtenerNombreCompleto(string empleadoSeleccionado)
        {
            // Asumiendo que el empleado está en el formato "nombre apellido (carrera)"
            var partes = empleadoSeleccionado.Split(' ');
            return $"{partes[0]} {partes[1]}"; // Devuelve solo el nombre y apellido
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtCuenta_TextChanged(object sender, EventArgs e)
        {

        }
        private void cargarCuentas()
        {
            try
            {
                // Obtener la lista de cuentas desde la capa de negocio
                List<string> cuentas = CuentaCN.ObtenerCuenta();

                // Asignar la lista al ComboBox
                txtCuenta.DataSource = cuentas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las cuentas: " + ex.Message);
            }

        }

        private void txtCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Obtener la cuenta seleccionada
                string cuentaSeleccionada = txtCuenta.SelectedItem.ToString();

                // Obtener los empleados relacionados con la cuenta seleccionada
                List<string> empleados = CuentaCN.ListarEmpleadosPorCuenta(cuentaSeleccionada);

                // Limpiar los ComboBox antes de asignar nuevos valores
                cmbMarketing.Items.Clear();
                cmbDiseñador.Items.Clear();
                cmbAudiovisual.Items.Clear();

                // Llenar los ComboBox con los empleados relacionados
                foreach (var empleado in empleados)
                {
                    cmbMarketing.Items.Add(empleado);
                    cmbDiseñador.Items.Add(empleado);
                    cmbAudiovisual.Items.Add(empleado);
                }

                // Seleccionar el primer empleado como un valor
                if (empleados.Count > 0)
                {
                    cmbMarketing.SelectedItem = empleados[0];
                }

                if (empleados.Count > 1)
                {
                    cmbDiseñador.SelectedItem = empleados[1];
                }

                if (empleados.Count > 2)
                {
                    cmbAudiovisual.SelectedItem = empleados[2];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los empleados: " + ex.Message);
            }

        }
    }
}
