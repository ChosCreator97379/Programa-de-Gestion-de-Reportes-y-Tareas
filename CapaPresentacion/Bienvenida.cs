﻿using System;
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
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void registrosDeTareaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TablaTarea tablatarea = new TablaTarea();
            tablatarea.Show();
        }

        private void listaDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login Login = new Login();
            Login.Show();
        }

        private void listaDeCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Descarga_de_Excel cuenta = new Descarga_de_Excel();
            cuenta.Show();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bienvenida_Load(object sender, EventArgs e)
        {

        }

    }
}
