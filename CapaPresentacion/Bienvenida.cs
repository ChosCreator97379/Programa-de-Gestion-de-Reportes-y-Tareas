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
    public partial class Bienvenida : Form
    {
        public Bienvenida()
        {
            InitializeComponent();
        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void registroDeEntradaYSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro_E_S Registro_E_S = new Registro_E_S();
            Registro_E_S.Show();
        }

        private void administradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login Login = new Login();
            Login.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void registroDeEntradaYSalidaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Registro_E_S Registro_E_S = new Registro_E_S();
            Registro_E_S.Show();
        }

        private void administradorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Login Login = new Login();
            Login.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
