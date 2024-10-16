using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;

namespace CapaPresentacion
{
    public partial class EditarTabla : Form
    {
        private string cuentaSeleccionada;
        private int tareaIdSeleccionada;

        public EditarTabla(string cuenta)
        {
            InitializeComponent();
            cuentaSeleccionada = cuenta;

            // Llama al método para cargar las cuentas relacionadas
            CargarCuentasRelacionadas();
            dgvTareasRelacionadas.SelectionChanged += dgvTareasRelacionadas_SelectionChanged;
        }
        private void CargarCuentasRelacionadas()
        {
            // Obtener todas las cuentas relacionadas de la base de datos
            DataTable dtCuentas = TareaCN.ObtenerCuentasRelacionadas(cuentaSeleccionada);

            // Llenar el ComboBox con las cuentas
            cmbCuentas.DisplayMember = "Cuenta"; // Mostrar el nombre de la cuenta
            cmbCuentas.ValueMember = "Cuenta";  // El valor real de cada opción del ComboBox
            cmbCuentas.DataSource = dtCuentas;

            // Selecciona la cuenta original al inicio
            cmbCuentas.SelectedValue = cuentaSeleccionada;

            // Cargar los datos de la cuenta seleccionada
            CargarDatosCuenta(cuentaSeleccionada);
        }

        private void cbmCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCuentas.SelectedValue != null)
            {
                string cuenta = cmbCuentas.SelectedValue.ToString();
                CargarDatosCuenta(cuenta);
            }
        }
        private void CargarDatosCuenta(string cuenta)
        {
            // Obtener los datos de la cuenta seleccionada desde la base de datos
            DataTable dt = TareaCN.ObtenerTareasPorCuenta(cuenta);

            // Asegúrate de que hay datos
            if (dt.Rows.Count > 0)
            {
                // Mostrar los datos en los controles
                txtFechaLimite.Text = dt.Rows[3]["Fecha_Limite"].ToString();
                chkCompletado.Checked = dt.Rows[4]["Completado"].ToString() == "si";

                // Mostrar las demás tareas relacionadas en el DataGridView
                dgvTareasRelacionadas.DataSource = dt;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvTareasRelacionadas.CurrentRow.Cells[0].Value); // Obtener el ID de la fila seleccionada
                string fechaLimite = txtFechaLimite.Text;
                string completado = chkCompletado.Checked ? "si" : "no";
                string link = txtLink.Text;

                TareaCN.ActualizarTarea(id, fechaLimite, completado, link);
                MessageBox.Show("Tarea actualizada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la tarea: {ex.Message}");
            }

        }

        private void dgvTareasRelacionadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        

        private void dgvTareasRelacionadas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTareasRelacionadas.CurrentRow != null)
            {
                // Suponiendo que el ID está en la primera columna (índice 0)
                int id;
                if (int.TryParse(dgvTareasRelacionadas.CurrentRow.Cells[0].Value.ToString(), out id))
                {
                    // Aquí puedes usar 'id' para cargar otros datos en los TextBox y ComboBox
                    
                    cmbCuentas.SelectedItem = dgvTareasRelacionadas.CurrentRow.Cells[0].Value.ToString(); // Esto debería ser el ID
                    txtFechaLimite.Text = dgvTareasRelacionadas.CurrentRow.Cells[3].Value.ToString();
                    chkCompletado.Checked = dgvTareasRelacionadas.CurrentRow.Cells[4].Value.ToString().Equals("si");
                    txtLink.Text = dgvTareasRelacionadas.CurrentRow.Cells[5].Value.ToString();
                }
                else
                {
                    MessageBox.Show("El ID seleccionado no es válido.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
