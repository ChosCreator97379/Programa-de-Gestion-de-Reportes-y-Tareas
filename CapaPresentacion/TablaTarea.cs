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
    public partial class TablaTarea : Form
    {
        public TablaTarea()
        {
            InitializeComponent();
        }

        private void btnGenerarTabla_Click(object sender, EventArgs e)
        {
            GenerarTablaTarea generarTablaTarea = new GenerarTablaTarea();
            generarTablaTarea.ShowDialog(); // Abre el formulario de generación de tareas
        }
        private void CargarTareas()
        {
            DataTable dt = TareaCN.ObtenerTareas();
            if (dt != null && dt.Rows.Count > 0)
            {
                dgvTareas.DataSource = dt;
            }
            else
            {
                dgvTareas.DataSource = null;
                MessageBox.Show("No hay tareas que mostrar.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cuenta = txtValorBusqueda.Text.Trim(); // Obtener el valor de la cuenta del TextBox

            if (cuenta.Equals("Cantolao", StringComparison.OrdinalIgnoreCase))
            {
                // Simulamos los datos para Cantolao
                DataTable dtCantolao = new DataTable();
                dtCantolao.Columns.Add("Tareas_Que_Faltan", typeof(string));
                dtCantolao.Columns.Add("Fecha_Limite", typeof(string));
                dtCantolao.Columns.Add("Completado", typeof(string));
                dtCantolao.Columns.Add("Link", typeof(string));

                dtCantolao.Rows.Add("Hoja de preguntas y respuestas", "TERMINADO", "si", "https://terabox.com/s/1QaT93bfHxzp1_M-v-rtBFA");
                dtCantolao.Rows.Add("Arquetipo de cliente", "TERMINADO", "si", "https://terabox.com/s/15KAq9q10oJnA0pvo-k44Fw");
                dtCantolao.Rows.Add("Manual de marca", "TERMINADO", "si", "https://terabox.com/s/1Sq0VhtBw4FV2C7h0P4MPfw");
                dtCantolao.Rows.Add("Plan de publicaciones / septiembre", "TERMINADO", "no", "https://terabox.com/s/1Acs6gxJ8SRZOohojRu0Ig");
                dtCantolao.Rows.Add("Hoja de designaciones", "TERMINADO", "si", "https://terabox.com/s/1Nb7RdiGuLHgkAhhmmPVEg");

                // Asignar el DataTable simulado al DataGridView
                dgvTareas.DataSource = dtCantolao;
            }
            else
            {
                dgvTareas.DataSource = null;
                MessageBox.Show("No se encontraron tareas para la cuenta ingresada.");
            }
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
