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
using CapaDato;
using ClosedXML.Excel;


namespace CapaPresentacion
{
    public partial class Registro_E_S : Form
    {
        private EmpleadoCN empleadoCN = new EmpleadoCN();
        public Registro_E_S()
        {
            InitializeComponent();
        }

        

        private void Registro_E_S_Load(object sender, EventArgs e)
        {
            // Cargar los datos de la tabla Reportes
            DataTable dtReportes = ReportesCN.ObtenerReportes();

            if (dtReportes != null)
            {
                dataGridView.DataSource = dtReportes;
            }
            else
            {
                MessageBox.Show("Error al cargar los reportes.");
            }
        }
        private void CargarReportes()
        {
            DataTable dtReportes = ReportesCN.ObtenerReportes();

            if (dtReportes != null)
            {
                dataGridView.DataSource = dtReportes;
            }
            else
            {
                MessageBox.Show("Error al cargar los reportes.");
            }
        }


        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       

        private void btnBuscarRegistro_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
        }
        
        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AñadirReporte formAgregar = new AñadirReporte();
            formAgregar.FormClosed += new FormClosedEventHandler(FormAgregar_FormClosed); // Suscribirse al evento FormClosed
            formAgregar.Show();
        }
        private void FormAgregar_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Se llama a CargarReportes() para actualizar el DataGridView cuando se cierra el formulario de agregar reporte
            CargarReportes();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
