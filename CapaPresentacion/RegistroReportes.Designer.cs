namespace CapaPresentacion
{
    partial class Registro_E_S
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cmbCampoBusqueda = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnDescargarTodo = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnBuscarRegistro = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSlateGray;
            this.groupBox2.Controls.Add(this.btnActualizar);
            this.groupBox2.Controls.Add(this.txtBusqueda);
            this.groupBox2.Controls.Add(this.cmbCampoBusqueda);
            this.groupBox2.Controls.Add(this.dataGridView);
            this.groupBox2.Controls.Add(this.btnBuscarRegistro);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(128, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(901, 541);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reporte de Tareas";
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(271, 35);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(171, 25);
            this.txtBusqueda.TabIndex = 16;
            // 
            // cmbCampoBusqueda
            // 
            this.cmbCampoBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.cmbCampoBusqueda.ForeColor = System.Drawing.SystemColors.Window;
            this.cmbCampoBusqueda.FormattingEnabled = true;
            this.cmbCampoBusqueda.Location = new System.Drawing.Point(129, 35);
            this.cmbCampoBusqueda.Name = "cmbCampoBusqueda";
            this.cmbCampoBusqueda.Size = new System.Drawing.Size(136, 25);
            this.cmbCampoBusqueda.TabIndex = 16;
            this.cmbCampoBusqueda.Text = "Tipo de Busqueda";
            this.cmbCampoBusqueda.SelectedIndexChanged += new System.EventHandler(this.cmbCampoBusqueda_SelectedIndexChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView.Location = new System.Drawing.Point(6, 83);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(889, 452);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(15, 12);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(84, 87);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnDescargarTodo
            // 
            this.btnDescargarTodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.btnDescargarTodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargarTodo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDescargarTodo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargarTodo.ForeColor = System.Drawing.SystemColors.Window;
            this.btnDescargarTodo.Image = global::CapaPresentacion.Properties.Resources.archivo_excel1;
            this.btnDescargarTodo.Location = new System.Drawing.Point(1040, 333);
            this.btnDescargarTodo.Name = "btnDescargarTodo";
            this.btnDescargarTodo.Size = new System.Drawing.Size(113, 105);
            this.btnDescargarTodo.TabIndex = 22;
            this.btnDescargarTodo.Text = "Descargar en Excel (Todo)";
            this.btnDescargarTodo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDescargarTodo.UseVisualStyleBackColor = false;
            this.btnDescargarTodo.Click += new System.EventHandler(this.btnDescargarTodo_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.Window;
            this.button4.Image = global::CapaPresentacion.Properties.Resources.archivo_excel1;
            this.button4.Location = new System.Drawing.Point(1040, 143);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(113, 105);
            this.button4.TabIndex = 21;
            this.button4.Text = "Descargar en Excel (Unidad)";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.SystemColors.Window;
            this.btnActualizar.Image = global::CapaPresentacion.Properties.Resources.actualizar__1_;
            this.btnActualizar.Location = new System.Drawing.Point(21, 30);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(102, 35);
            this.btnActualizar.TabIndex = 17;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnBuscarRegistro
            // 
            this.btnBuscarRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.btnBuscarRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarRegistro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarRegistro.ForeColor = System.Drawing.SystemColors.Window;
            this.btnBuscarRegistro.Image = global::CapaPresentacion.Properties.Resources.busqueda__4_;
            this.btnBuscarRegistro.Location = new System.Drawing.Point(448, 30);
            this.btnBuscarRegistro.Name = "btnBuscarRegistro";
            this.btnBuscarRegistro.Size = new System.Drawing.Size(99, 35);
            this.btnBuscarRegistro.TabIndex = 16;
            this.btnBuscarRegistro.Text = "Buscar";
            this.btnBuscarRegistro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarRegistro.UseVisualStyleBackColor = false;
            this.btnBuscarRegistro.Click += new System.EventHandler(this.btnBuscarRegistro_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Window;
            this.button2.Image = global::CapaPresentacion.Properties.Resources.basura__2_;
            this.button2.Location = new System.Drawing.Point(18, 427);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 88);
            this.button2.TabIndex = 19;
            this.button2.Text = "Eliminar";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.Window;
            this.button3.Image = global::CapaPresentacion.Properties.Resources.capa_mas;
            this.button3.Location = new System.Drawing.Point(19, 143);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 89);
            this.button3.TabIndex = 20;
            this.button3.Text = "Añadir";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Image = global::CapaPresentacion.Properties.Resources.editar__1_;
            this.button1.Location = new System.Drawing.Point(19, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 89);
            this.button1.TabIndex = 18;
            this.button1.Text = "Editar";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.inicioToolStripMenuItem.Image = global::CapaPresentacion.Properties.Resources.hogar__5_;
            this.inicioToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(76, 83);
            this.inicioToolStripMenuItem.Text = "Inicio";
            this.inicioToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.inicioToolStripMenuItem.Click += new System.EventHandler(this.inicioToolStripMenuItem_Click_1);
            // 
            // Registro_E_S
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(1165, 565);
            this.ControlBox = false;
            this.Controls.Add(this.btnDescargarTodo);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Registro_E_S";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.Registro_E_S_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBuscarRegistro;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.ComboBox cmbCampoBusqueda;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.Button btnDescargarTodo;
    }
}