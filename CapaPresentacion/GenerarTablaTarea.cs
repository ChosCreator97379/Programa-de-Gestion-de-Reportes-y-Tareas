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
            string cuenta = txtCuenta.Text;

            // Tareas predeterminadas para la nueva cuenta
            List<string> tareas = new List<string>()
            {
                "hoja de preguntas y respuestas",
                "arquetipo de cliente",
                "manual de marca",
                "-mockup/septiembre",
                "-las plantillas",
                "-plan de publicaciones/septiembre",
                "dia de produccion/setiembre",
                "hoja de designacion",
                "-hora de publicaciones",
                "día de publicaciones",
                "administracion de la cuenta"
                
            };

            List<string> fechasLimite = new List<string>()
            {
                "", "", "", "", "",
                "", "", "", "","",""
            };

            List<string> completado = new List<string>() { "no", "no", "no", "no", "no", "no", "no", "no", "no","no","no" };
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
    }
}
