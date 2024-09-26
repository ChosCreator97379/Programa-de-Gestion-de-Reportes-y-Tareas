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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string claveCorrecta = "1234";

            // Verificar si la clave ingresada es correcta
            if (txtClave.Text == claveCorrecta)
            {
                // Abrir el nuevo formulario
                Administrador Administrador = new Administrador();
                Administrador.Show();
                this.Close();

                // Cerrar el formulario de login
                // Esconder en lugar de cerrar para no terminar la aplicación
            }
            else
            {
                // Mensaje de error si la clave es incorrecta
                MessageBox.Show("Clave incorrecta. Intente nuevamente.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
