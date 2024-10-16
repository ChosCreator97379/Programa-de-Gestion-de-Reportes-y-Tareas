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
    public partial class Descarga_de_Excel : Form
    {
        public Descarga_de_Excel()
        {
            InitializeComponent();
        }

        private void Descarga_de_Excel_Load(object sender, EventArgs e)
        {
            CargarCuentasCMB();
            CargarCuentas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (AñadirCuenta añadirCuenta = new AñadirCuenta())
            {
                añadirCuenta.ShowDialog(); // Abre el formulario de añadir cuenta

                // Aquí puedes recargar el DataGridView después de que se cierre
                CargarCuentasCMB();
                CargarCuentas();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idCuenta = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
                EditarCuenta formEdicion = new EditarCuenta(idCuenta);
                formEdicion.ShowDialog();
                CargarCuentasCMB();
                CargarCuentas();
                // Aquí puedes recargar los datos del DataGridView si es necesario
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un cuenta para editar.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string cuentaSeleccionada = cmbCuentas.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(cuentaSeleccionada))
                {
                    MessageBox.Show("Por favor, seleccione una cuenta.");
                    return;
                }

                // Llamar al método en CuentaCN para obtener los datos de la cuenta
                DataTable datosCuenta = CuentaCN.ObtenerDatosCuenta(cuentaSeleccionada);

                // Mostrar los datos en el DataGridView
                dataGridView1.DataSource = datosCuenta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar la cuenta: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay una fila seleccionada
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione una cuenta para eliminar.");
                    return;
                }

                // Obtener el ID de la cuenta de la fila seleccionada
                int idCuenta = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                // Confirmar la eliminación
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar la cuenta seleccionada?", "Confirmar Eliminación", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    // Llamar al método de negocio para eliminar la cuenta usando su ID
                    bool eliminado = CuentaCN.EliminarCuenta(idCuenta);

                    if (eliminado)
                    {
                        MessageBox.Show("Cuenta eliminada con éxito.");

                        // Recargar el DataGridView para reflejar los cambios
                        CargarCuentasCMB();
                        CargarCuentas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la cuenta.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la cuenta: " + ex.Message);
            }
        }
        private void CargarCuentasCMB()
        {
            try
            {
                // Obtener la lista de cuentas desde la capa de negocio
                List<string> cuentas = CuentaCN.ObtenerCuenta();

                // Asignar la lista al ComboBox
                cmbCuentas.DataSource = cuentas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las cuentas: " + ex.Message);
            }
        }
        private void CargarCuentas()
        {
            try
            {
                // Cargar los datos en el DataGridView
                dataGridView1.DataSource = CuentaCN.ListarCuentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void cmbCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
