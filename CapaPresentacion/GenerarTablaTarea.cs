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
    public partial class GenerarTablaTarea : Form
    {
        public GenerarTablaTarea()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string cuenta = txtCuenta.SelectedItem?.ToString();

            // Tareas predeterminadas para la nueva cuenta
            List<string> tareas = new List<string>()
            {
                "Hoja de preguntas y respuestas",
                "Arquetipo de cliente",
                "Manual de marca",
                "Mockup",
                "Las plantillas",
                "Plan de publicaciones",
                "Dia de produccion",
                "Hoja de designacion",
                "Hora de publicaciones",
                "Día de publicaciones",
                "Administracion de la cuenta"
                
            };

            List<string> fechasLimite = new List<string>()
            {
                "", "", "", "", "",
                "", "", "", "","",""
            };

            List<string> completado = new List<string>() { "No", "No", "No", "No", "No", "No", "No", "No", "No","No","No" };
            List<string> links = new List<string>()
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                ""

            };

            // Insertar cada tarea en la base de datos
            for (int i = 0; i < tareas.Count; i++)
            {
                TareaCN.InsertarTarea(cuenta, tareas[i], fechasLimite[i], completado[i], links[i]);
            }

            MessageBox.Show("Tareas generadas e insertadas para la cuenta: " + cuenta);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void CargarCuentasCMB()
        {
            try
            {
                // Obtener la lista de cuentas desde la capa de negocio
                List<string> cuentas = CuentaCN.ObtenerCuenta();

                // Asignar la lista al ComboBox
                txtCuenta.DataSource = cuentas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las cuentas: " + ex.Message);
            }
        }

        private void GenerarTablaTarea_Load(object sender, EventArgs e)
        {
            CargarCuentasCMB();
        }
    }
}
