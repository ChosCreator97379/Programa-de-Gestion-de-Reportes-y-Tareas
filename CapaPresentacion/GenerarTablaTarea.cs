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
            // Validar que el campo de la cuenta no esté vacío
            if (string.IsNullOrEmpty(txtCuenta.Text))
            {
                MessageBox.Show("Por favor ingrese un nombre de cuenta.");
                return;
            }

            // Verificar si la cuenta ya existe en la base de datos
            if (TareaCN.VerificarCuentaExiste(txtCuenta.Text))
            {
                MessageBox.Show("La cuenta ya existe. Por favor, ingrese una cuenta diferente.");
                return;
            }

            // Insertar la cuenta en la tabla
            TareaCN.InsertarNuevaCuenta(txtCuenta.Text);

            MessageBox.Show("Cuenta creada correctamente.");
            this.Close(); // Cerrar el formulario después de guardar
        }
        
    }
}
