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
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Añadirempleado añadirempleado = new Añadirempleado();
            añadirempleado.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verificar que se haya seleccionado una fila
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Obtener el ID del empleado desde la fila seleccionada
                int idEmpleado = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["ID"].Value);

                // Abrir el formulario de edición y pasarle el ID del empleado
                EditarEmpleado editarEmpleado = new EditarEmpleado(idEmpleado);
                editarEmpleado.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un empleado para editar.");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    DataTable dt = EmpleadoCN.ObtenerInformacionEmpleados();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dataGridView.DataSource = dt;
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

        }

        private void Administrador_Load(object sender, EventArgs e)
        {
            {
                try
                {
                    DataTable dt = EmpleadoCN.ObtenerInformacionEmpleados();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dataGridView.DataSource = dt;
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
        }
        private int ObtenerIdEmpleadoSeleccionado()
        {
            if (dataGridView.CurrentRow != null)
            {
                return Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
            }
            return -1;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idEmpleado = ObtenerIdEmpleadoSeleccionado();

            if (idEmpleado != -1)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Estás seguro que deseas eliminar este empleado y todos sus registros asociados?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    // Llamamos a la capa de negocio para eliminar el empleado
                    EliminarEmpleado(idEmpleado);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un empleado.");
            }
        }
        private void EliminarEmpleado(int idEmpleado)
        {
            EmpleadoCN empleadoCN = new EmpleadoCN();
            empleadoCN.EliminarEmpleado(idEmpleado);
            MessageBox.Show("Empleado eliminado correctamente.");
            // Actualiza el DataGridView después de eliminar
            CargarDatosEmpleados();
        }
        private void CargarDatosEmpleados()
        {
            // Aquí llamas a la capa de negocio para obtener los empleados y rellenar el DataGridView
            EmpleadoCN empleadoCN = new EmpleadoCN();
            DataTable dt = EmpleadoCN.ObtenerInformacionEmpleados(); // Asumiendo que tienes una función que retorna los empleados

            dataGridView.DataSource = dt;
        }

        private void btnBuscarRegistro_Click(object sender, EventArgs e)
        {
            string criterio = "";
            switch (cmbCriterioBusqueda.SelectedItem.ToString())
            {
                case "ID Empleado":
                    criterio = "e.ID";
                    break;
                case "Nombre1":
                    criterio = "e.Nombre1";
                    break;
                case "Nombre2":
                    criterio = "e.Nombre2";
                    break;
                case "DNI":
                    criterio = "e.DNI";
                    break;
                case "Cargo":
                    criterio = "dl.Cargo";
                    break;
                case "Área":
                    criterio = "dl.Area";
                    break;
                case "Estado Laboral":
                    criterio = "dl.EstadoLaboral";
                    break;
                case "Supervisor":
                    criterio = "dl.Nombre_Supervisor";
                    break;
                case "Universidad o Instituto":
                    criterio = "da.UniversidadInstituto";
                    break;
                case "Carrera":
                    criterio = "da.Carrera";
                    break;
            }

            EmpleadoCN empleadoCN = new EmpleadoCN();
            DataTable dt = empleadoCN.BuscarEmpleado(criterio, txtValorBusqueda.Text);

            dataGridView.DataSource = dt;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
