using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Añadirempleado : Form
    {
        private EmpleadoCN empleadoCN = new EmpleadoCN();
        public Añadirempleado()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Capturar los valores de los TextBoxes
                string nombre = txtnombre.Text;
                string apellido1 = txtapellido1.Text;
                string apellido2 = txtapellido2.Text;
                string dni = txtdni.Text;
                string telefono = txttelefono.Text;
                string correo = txtcorreo.Text;
                DateTime fechaNacimiento = dtpfechanaci.Value; // DateTimePicker
                string direccion = txtdireccion.Text;
                string distrito = txtdistrito.Text;

                string cargo = txtcargo.Text;
                string area = txtarea.Text;
                string estadoLaboral = txtestadolaboral.Text;
                string nombreSupervisor = txtsupervisor.Text;

                string universidadInstituto = txtestudios.Text;
                string carrera = txtcarrera.Text;

                // Llamada a la capa de negocios para insertar los datos
                empleadoCN.AgregarEmpleadoConDatos(nombre, apellido1, apellido2, dni, telefono, correo, fechaNacimiento,
                    direccion, distrito, cargo, area, estadoLaboral, nombreSupervisor, universidadInstituto, carrera);

                MessageBox.Show("Datos guardados exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message);
            }
        }

        private void txtestadolaboral_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdni_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
