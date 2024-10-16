namespace CapaPresentacion
{
    partial class Bienvenida
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDeEntradaYSalidaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.registrosDeTareaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administradorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeEmpleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeCuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.registroDeEntradaYSalidaToolStripMenuItem1,
            this.registrosDeTareaToolStripMenuItem,
            this.administradorToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(63, 224);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 15, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(593, 102);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.archivoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.archivoToolStripMenuItem.Image = global::CapaPresentacion.Properties.Resources.salir_alternativa;
            this.archivoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.archivoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Red;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(125, 85);
            this.archivoToolStripMenuItem.Text = "Cerrar Aplicacion";
            this.archivoToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.archivoToolStripMenuItem.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
            // 
            // registroDeEntradaYSalidaToolStripMenuItem1
            // 
            this.registroDeEntradaYSalidaToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registroDeEntradaYSalidaToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.registroDeEntradaYSalidaToolStripMenuItem1.Image = global::CapaPresentacion.Properties.Resources.archivos_medicos__1_;
            this.registroDeEntradaYSalidaToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.registroDeEntradaYSalidaToolStripMenuItem1.Name = "registroDeEntradaYSalidaToolStripMenuItem1";
            this.registroDeEntradaYSalidaToolStripMenuItem1.Size = new System.Drawing.Size(124, 85);
            this.registroDeEntradaYSalidaToolStripMenuItem1.Text = "Reporte de Tarea";
            this.registroDeEntradaYSalidaToolStripMenuItem1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.registroDeEntradaYSalidaToolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.registroDeEntradaYSalidaToolStripMenuItem1.Click += new System.EventHandler(this.registroDeEntradaYSalidaToolStripMenuItem1_Click);
            // 
            // registrosDeTareaToolStripMenuItem
            // 
            this.registrosDeTareaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.registrosDeTareaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.registrosDeTareaToolStripMenuItem.Image = global::CapaPresentacion.Properties.Resources.lista_de_tablas;
            this.registrosDeTareaToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.registrosDeTareaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.registrosDeTareaToolStripMenuItem.Name = "registrosDeTareaToolStripMenuItem";
            this.registrosDeTareaToolStripMenuItem.Size = new System.Drawing.Size(109, 85);
            this.registrosDeTareaToolStripMenuItem.Text = "Tabla de Tarea";
            this.registrosDeTareaToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.registrosDeTareaToolStripMenuItem.Click += new System.EventHandler(this.registrosDeTareaToolStripMenuItem_Click);
            // 
            // administradorToolStripMenuItem1
            // 
            this.administradorToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaDeEmpleadosToolStripMenuItem,
            this.listaDeCuentasToolStripMenuItem});
            this.administradorToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.administradorToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.administradorToolStripMenuItem1.Image = global::CapaPresentacion.Properties.Resources.alt_administrador__1_;
            this.administradorToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.administradorToolStripMenuItem1.Name = "administradorToolStripMenuItem1";
            this.administradorToolStripMenuItem1.Size = new System.Drawing.Size(109, 85);
            this.administradorToolStripMenuItem1.Text = "Administrador";
            this.administradorToolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.administradorToolStripMenuItem1.Click += new System.EventHandler(this.administradorToolStripMenuItem1_Click);
            // 
            // listaDeEmpleadosToolStripMenuItem
            // 
            this.listaDeEmpleadosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.listaDeEmpleadosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.listaDeEmpleadosToolStripMenuItem.Image = global::CapaPresentacion.Properties.Resources.hombre_empleado_alt;
            this.listaDeEmpleadosToolStripMenuItem.Name = "listaDeEmpleadosToolStripMenuItem";
            this.listaDeEmpleadosToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.listaDeEmpleadosToolStripMenuItem.Text = "Lista de Empleados";
            this.listaDeEmpleadosToolStripMenuItem.Click += new System.EventHandler(this.listaDeEmpleadosToolStripMenuItem_Click);
            // 
            // listaDeCuentasToolStripMenuItem
            // 
            this.listaDeCuentasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.listaDeCuentasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.listaDeCuentasToolStripMenuItem.Image = global::CapaPresentacion.Properties.Resources.recibo;
            this.listaDeCuentasToolStripMenuItem.Name = "listaDeCuentasToolStripMenuItem";
            this.listaDeCuentasToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.listaDeCuentasToolStripMenuItem.Text = "Lista de Cuentas";
            this.listaDeCuentasToolStripMenuItem.Click += new System.EventHandler(this.listaDeCuentasToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.Logo_Arreglado;
            this.pictureBox1.Location = new System.Drawing.Point(566, 83);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(293, 401);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Bienvenida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(998, 584);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Bienvenida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenida";
            this.Load += new System.EventHandler(this.Bienvenida_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDeEntradaYSalidaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem administradorToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem registrosDeTareaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeEmpleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeCuentasToolStripMenuItem;
    }
}

