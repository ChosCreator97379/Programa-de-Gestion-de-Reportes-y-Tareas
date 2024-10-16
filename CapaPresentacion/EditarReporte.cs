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
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;

namespace CapaPresentacion
{
    public partial class EditarReporte : Form
    {
        private int _idReporte;
        public EditarReporte(int idReporte)
        {
            InitializeComponent();
            _idReporte = idReporte;
        }
        private void CargarEmpleados()
        {
            DataTable dtEmpleados = ReportesCN.ObtenerEmpleados();

            foreach (DataRow row in dtEmpleados.Rows)
            {
                string empleadoCompleto = $"{row["Nombre1"]} {row["Apellido1"]} ( {row["Carrera"]} )";
                cmbMarketing.Items.Add(empleadoCompleto);
                cmbDiseñador.Items.Add(empleadoCompleto);
                cmbAudiovisual.Items.Add(empleadoCompleto);
            }
        }

        private void CargarDatosReporte()
        {
            DataTable dtReporte = ReportesCN.ObtenerReportePorID(_idReporte);
            if (dtReporte.Rows.Count > 0)
            {
                DataRow row = dtReporte.Rows[0];

                txtCuenta.Text = row["Cuenta"].ToString();
                dtpFecha.Value = Convert.ToDateTime(row["Fecha"]);
                chkCumplioActividad1.Checked = row["Cumplio_Actividad_01"].ToString() == "Sí";
                chkCumplioActividad2.Checked = row["Cumplio_Actividad_02"].ToString() == "Sí";
                txtHora1.Text = row["Hora_01"].ToString();
                txtReporte1.Text = row["Reporte_01"].ToString();
                txtObservacion1.Text = row["Observacion_01"].ToString();
                txtHora2.Text = row["Hora_02"].ToString();
                txtReporte2.Text = row["Reporte_02"].ToString();
                txtObservacion2.Text = row["Observacion_02"].ToString();
                txtHora3.Text = row["Hora_03"].ToString();
                txtReporte3.Text = row["Reporte_03"].ToString();
                txtObservacion3.Text = row["Observacion_03"].ToString();
                txtActM.Text = row["Act_M"].ToString();
                txtActD.Text = row["Act_D"].ToString();
                txtActA.Text = row["Act_A"].ToString();
                txtHorasM.Text = row["Horas_M"].ToString();
                txtHorasD.Text = row["Horas_D"].ToString();
                txtHorasA.Text = row["Horas_A"].ToString();
                txtPuntaje.Text = row["Puntaje"].ToString();

                // Asignar empleados a los ComboBox
                cmbMarketing.Text = row["Marketing"].ToString();
                cmbDiseñador.Text = row["Disenador"].ToString();
                cmbAudiovisual.Text = row["Audiovisual"].ToString();
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditarReporte_Load(object sender, EventArgs e)
        {
            foreach (var comboBox in new[] { cmbMarketing, cmbDiseñador, cmbAudiovisual })
            {
                CargarEmpleados();
                AjustarAnchoComboBox(comboBox);
            }
            CargarDatosReporte();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string cuenta = txtCuenta.Text;
            string marketing = ObtenerNombreSeleccionado(cmbMarketing.Text);
            string disenador = ObtenerNombreSeleccionado(cmbDiseñador.Text);
            string audiovisual = ObtenerNombreSeleccionado(cmbAudiovisual.Text);
            DateTime fecha = dtpFecha.Value;
            string cumplioActividad1 = chkCumplioActividad1.Checked ? "Sí" : "No";
            string cumplioActividad2 = chkCumplioActividad2.Checked ? "Sí" : "No";
            string hora1 = txtHora1.Text;
            string reporte1 = txtReporte1.Text;
            string observacion1 = txtObservacion1.Text;
            string hora2 = txtHora2.Text;
            string reporte2 = txtReporte2.Text;
            string observacion2 = txtObservacion2.Text;
            string hora3 = txtHora3.Text;
            string reporte3 = txtReporte3.Text;
            string observacion3 = txtObservacion3.Text;
            string actM = txtActM.Text;
            string actD = txtActD.Text;
            string actA = txtActA.Text;
            int horasM = int.Parse(txtHorasM.Text);
            int horasD = int.Parse(txtHorasD.Text);
            int horasA = int.Parse(txtHorasA.Text);
            int puntaje = int.Parse(txtPuntaje.Text);

            ReportesCN.EditarReporte(_idReporte, cuenta, marketing, disenador, audiovisual, fecha,
                                      cumplioActividad1, cumplioActividad2, hora1, reporte1, observacion1,
                                      hora2, reporte2, observacion2, hora3, reporte3, observacion3,
                                      actM, actD, actA, horasM, horasD, horasA, puntaje);

            MessageBox.Show("Reporte actualizado correctamente.");
            this.Close();
        }
        private string ObtenerNombreSeleccionado(string nombreCompleto)
        {
            string[] partes = nombreCompleto.Split(' ');
            return $"{partes[0]} {partes[1]}"; // Retorna solo el primer nombre y apellido
        }

        private void cmbMarketing_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
