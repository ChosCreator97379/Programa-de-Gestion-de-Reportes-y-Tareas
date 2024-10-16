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

namespace CapaPresentacion
{
    public partial class EditarCuenta : Form
    {
        private int _idCuenta;
        public EditarCuenta(int idCuenta)
        {
            InitializeComponent();
            _idCuenta = idCuenta;
        }

        private void EditarCuenta_Load(object sender, EventArgs e)
        {
            foreach (var comboBox in new[] { cmbMarketing, cmbDiseno, cmbAudiovisual })
            {
                CargarEmpleados();
                AjustarAnchoComboBox(comboBox);
            }
            CargarDatosCuenta();
        }
        private void CargarDatosCuenta()
        {
            DataTable dtReporte = CuentaCN.ObtenerCuentaPorID(_idCuenta);
            if (dtReporte.Rows.Count > 0)
            {
                DataRow row = dtReporte.Rows[0];

                txtCuenta.Text = row["Cuenta"].ToString();
                // Asignar empleados a los ComboBox
                cmbMarketing.Text = row["Marketing"].ToString();
                cmbDiseno.Text = row["Diseno"].ToString();
                cmbAudiovisual.Text = row["Audiovisual"].ToString();
            }
        }
        private void AjustarAnchoComboBox(ComboBox comboBox)
        {
            using (Graphics graphics = comboBox.CreateGraphics())
            {
                System.Drawing.Font font = comboBox.Font;
                int maxWidth = comboBox.Items.Cast<object>()
                    .Max(item => (int)graphics.MeasureString(item.ToString(), font).Width);

                comboBox.DropDownWidth = maxWidth + 20; // Ajusta el ancho con margen adicional
            }
        }
        private void CargarEmpleados()
        {
            DataTable dtEmpleados = ReportesCN.ObtenerEmpleados();

            foreach (DataRow row in dtEmpleados.Rows)
            {
                string empleadoCompleto = $"{row["Nombre1"]} {row["Apellido1"]} ( {row["Carrera"]} )";
                cmbMarketing.Items.Add(empleadoCompleto);
                cmbDiseno.Items.Add(empleadoCompleto);
                cmbAudiovisual.Items.Add(empleadoCompleto);
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
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string cuenta = txtCuenta.Text;
            string marketing = ObtenerNombreSeleccionado(cmbMarketing.Text);
            string disenador = ObtenerNombreSeleccionado(cmbDiseno.Text);
            string audiovisual = ObtenerNombreSeleccionado(cmbAudiovisual.Text);

            CuentaCN.EditarCuenta(_idCuenta, cuenta, marketing, disenador, audiovisual);

            MessageBox.Show("Reporte actualizado correctamente.");
            this.Close();
        }
        private string ObtenerNombreSeleccionado(string nombreCompleto)
        {
            string[] partes = nombreCompleto.Split(' ');
            return $"{partes[0]} {partes[1]}"; // Retorna solo el primer nombre y apellido
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
