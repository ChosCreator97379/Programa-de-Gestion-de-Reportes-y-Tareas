namespace CapaPresentacion
{
    partial class AñadirReporte
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtFecha = new System.Windows.Forms.Label();
            this.txtCuenta = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAudiovisual = new System.Windows.Forms.ComboBox();
            this.cmbDiseñador = new System.Windows.Forms.ComboBox();
            this.cmbMarketing = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSlateGray;
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.txtFecha);
            this.groupBox1.Controls.Add(this.txtCuenta);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbAudiovisual);
            this.groupBox1.Controls.Add(this.cmbDiseñador);
            this.groupBox1.Controls.Add(this.cmbMarketing);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 253);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Añadir Reporte";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(212, 64);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 25);
            this.dtpFecha.TabIndex = 16;
            // 
            // txtFecha
            // 
            this.txtFecha.AutoSize = true;
            this.txtFecha.Location = new System.Drawing.Point(209, 44);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(43, 17);
            this.txtFecha.TabIndex = 15;
            this.txtFecha.Text = "Fecha";
            // 
            // txtCuenta
            // 
            this.txtCuenta.FormattingEnabled = true;
            this.txtCuenta.Location = new System.Drawing.Point(59, 64);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(121, 25);
            this.txtCuenta.TabIndex = 13;
            this.txtCuenta.SelectedIndexChanged += new System.EventHandler(this.txtCuenta_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cuenta";
            // 
            // cmbAudiovisual
            // 
            this.cmbAudiovisual.FormattingEnabled = true;
            this.cmbAudiovisual.Location = new System.Drawing.Point(315, 143);
            this.cmbAudiovisual.Name = "cmbAudiovisual";
            this.cmbAudiovisual.Size = new System.Drawing.Size(121, 25);
            this.cmbAudiovisual.TabIndex = 10;
            this.cmbAudiovisual.SelectedIndexChanged += new System.EventHandler(this.cmbAudiovisual_SelectedIndexChanged);
            // 
            // cmbDiseñador
            // 
            this.cmbDiseñador.FormattingEnabled = true;
            this.cmbDiseñador.Location = new System.Drawing.Point(176, 143);
            this.cmbDiseñador.Name = "cmbDiseñador";
            this.cmbDiseñador.Size = new System.Drawing.Size(121, 25);
            this.cmbDiseñador.TabIndex = 9;
            this.cmbDiseñador.SelectedIndexChanged += new System.EventHandler(this.cmbDiseñador_SelectedIndexChanged);
            // 
            // cmbMarketing
            // 
            this.cmbMarketing.FormattingEnabled = true;
            this.cmbMarketing.Location = new System.Drawing.Point(39, 143);
            this.cmbMarketing.Name = "cmbMarketing";
            this.cmbMarketing.Size = new System.Drawing.Size(121, 25);
            this.cmbMarketing.TabIndex = 8;
            this.cmbMarketing.SelectedIndexChanged += new System.EventHandler(this.cmbMarketing_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::CapaPresentacion.Properties.Resources.circulo_cruzado__1_;
            this.button2.Location = new System.Drawing.Point(272, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 52);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancelar";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::CapaPresentacion.Properties.Resources.seleccione;
            this.button1.Location = new System.Drawing.Point(85, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 52);
            this.button1.TabIndex = 6;
            this.button1.Text = "Crear Reporte";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Audiovisual";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Diseñador ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Marketing";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // AñadirReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(502, 277);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AñadirReporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AñadirReporte";
            this.Load += new System.EventHandler(this.AñadirReporte_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbAudiovisual;
        private System.Windows.Forms.ComboBox cmbDiseñador;
        private System.Windows.Forms.ComboBox cmbMarketing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox txtCuenta;
        private System.Windows.Forms.Label txtFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
    }
}