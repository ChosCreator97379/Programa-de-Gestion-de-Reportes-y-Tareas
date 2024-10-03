using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDato;
using static System.Windows.Forms.MonthCalendar;


namespace CapaPresentacion
{
    public partial class Editar : Form
    {
        private int _idEmpleado;
        public Editar(int idEmpleado)
        {
            InitializeComponent();
            _idEmpleado = idEmpleado;
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            CargarDatosEmpleado(_idEmpleado);
        }

        private void CargarDatosEmpleado(int idEmpleado)
        {
            DataTable dt = EmpleadoCN.BuscarEmpleadoPorID(idEmpleado);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // Cargar datos en los TextBoxes (Asegúrate de tener estos controles en el formulario)
                txtNombre1.Text = row["Nombre1"].ToString();
                txtNombre2.Text = row["Nombre2"].ToString();
                txtApellido1.Text = row["Apellido1"].ToString();
                txtApellido2.Text = row["Apellido2"].ToString();
                txtDni.Text = row["DNI"].ToString();
                txtTelefono.Text = row["Telefono"].ToString();
                txtCorreo.Text = row["CorreoElectronico"].ToString();
                txtDireccion.Text = row["Direccion"].ToString();
                txtDistrito.Text = row["Distrito"].ToString();
                dtpFechaNacimiento.Value = Convert.ToDateTime(row["FechaNacimiento"]);
                txtCargo.Text = row["Cargo"].ToString();
                txtArea.Text = row["Area"].ToString();
                txtEstadoLaboral.Text = row["EstadoLaboral"].ToString();
                txtNombreSupervisor.Text = row["Nombre_Supervisor"].ToString();

                txtUni.Text = row["UniversidadInstituto"].ToString();
                txtCarrera.Text = row["Carrera"].ToString();
            }
            else
            {
                MessageBox.Show("No se encontraron datos del empleado.");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Recoger los valores del formulario para actualizar
                string nombre1 = txtNombre1.Text;
                string nombre2 = txtNombre2.Text;
                string apellido1 = txtApellido1.Text;
                string apellido2 = string.IsNullOrWhiteSpace(txtApellido2.Text) ? null : txtApellido2.Text;
                string dni = txtDni.Text;
                string telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text;
                string correo = string.IsNullOrWhiteSpace(txtCorreo.Text) ? null : txtCorreo.Text;
                string direccion = string.IsNullOrWhiteSpace(txtDireccion.Text) ? null : txtDireccion.Text;
                string distrito = string.IsNullOrWhiteSpace(txtDistrito.Text) ? null : txtDistrito.Text;
                DateTime fechaNacimiento = dtpFechaNacimiento.Value;
                string cargo = string.IsNullOrWhiteSpace(txtCargo.Text) ? null : txtCargo.Text;
                string area = string.IsNullOrWhiteSpace(txtArea.Text) ? null : txtArea.Text;
                string estadoLaboral = string.IsNullOrWhiteSpace(txtEstadoLaboral.Text) ? null : txtEstadoLaboral.Text;
                string nombreSupervisor = string.IsNullOrWhiteSpace(txtNombreSupervisor.Text) ? null : txtNombreSupervisor.Text;
                string universidadInstituto = string.IsNullOrWhiteSpace(txtUni.Text) ? null : txtUni.Text;
                string carrera = string.IsNullOrWhiteSpace(txtCarrera.Text) ? null : txtCarrera.Text;

                // Llamar a la capa de negocios para actualizar los datos del empleado
                EmpleadoCN.ActualizarEmpleado(_idEmpleado, nombre1, nombre2, apellido1, apellido2, dni, telefono, correo, direccion, distrito, fechaNacimiento, cargo, area, estadoLaboral, nombreSupervisor, universidadInstituto, carrera);

                MessageBox.Show("Datos actualizados correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar los datos: {ex.Message}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

