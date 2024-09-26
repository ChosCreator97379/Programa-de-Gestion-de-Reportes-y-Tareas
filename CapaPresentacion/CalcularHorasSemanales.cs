using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class CalcularHorasSemanales : Form
    {
        public CalcularHorasSemanales()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtIdEmpleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void CalcularHorasSemanales_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int idEmpleado = Convert.ToInt32(txtIdEmpleado.Text);
                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime fechaFin = dtpFechaFin.Value.Date;

                AsistenciaCN asistenciaCN = new AsistenciaCN();
                TimeSpan totalHoras = asistenciaCN.CalcularHorasTrabajadas(idEmpleado, fechaInicio, fechaFin);

                // Mostrar el total de horas en el TextBox
                txtHorasTrabajadas.Text = FormatearTiempo(totalHoras);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular las horas trabajadas: " + ex.Message);
            }
        }
        private string FormatearTiempo(TimeSpan tiempo)
        {
            int horas = (int)tiempo.TotalHours;
            int minutos = tiempo.Minutes;
            return $"{horas} horas y {minutos} minutos";
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtHorasTrabajadas_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
