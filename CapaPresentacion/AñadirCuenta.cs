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
    public partial class AñadirCuenta : Form
    {
        public AñadirCuenta()
        {
            InitializeComponent();
        }

        private void AñadirCuenta_Load(object sender, EventArgs e)
        {
            // Cargar empleados y ajustar ancho de ComboBox en un solo ciclo
            foreach (var comboBox in new[] { cmbMarketing, cmbDiseno, cmbAudiovisual })
            {
                CargarEmpleadosEnComboBox(comboBox);
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
        public event Action CuentaAgregada;
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                // Obtener la información seleccionada (primer nombre y primer apellido)
                string marketing = ObtenerNombreYApellido(cmbMarketing.SelectedItem.ToString());
                string diseno = ObtenerNombreYApellido(cmbDiseno.SelectedItem.ToString());
                string audiovisual = ObtenerNombreYApellido(cmbAudiovisual.SelectedItem.ToString());

                // Llamar al método de negocio para agregar la cuenta
                bool resultado = CuentaCN.AgregarCuenta(txtCuenta.Text, marketing, diseno, audiovisual);

                if (resultado)
                {
                    MessageBox.Show("Cuenta añadida con éxito.");
                    this.Close(); // Cierra el formulario // Cerrar el formulario si se guarda correctamente
                }
                else
                {
                    MessageBox.Show("No se pudo añadir la cuenta.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la cuenta: " + ex.Message);
            }
        }
        private string ObtenerNombreYApellido(string empleadoInfo)
        {
            // Formato esperado: "Nombre Apellido (Carrera)"
            int parentesisIndex = empleadoInfo.IndexOf("(");
            if (parentesisIndex > 0)
            {
                return empleadoInfo.Substring(0, parentesisIndex).Trim();
            }
            return empleadoInfo;
        }


        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario sin guardar
        }

        private void cmbMarketing_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
