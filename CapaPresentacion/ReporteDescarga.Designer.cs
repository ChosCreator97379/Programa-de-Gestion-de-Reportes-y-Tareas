namespace CapaPresentacion
{
    partial class ReporteDescarga
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
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDescargar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSlateGray;
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnDescargar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFinal);
            this.groupBox1.Controls.Add(this.dtpInicio);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 222);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Descargar todo por Fecha";
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "dd/MM/yyyy";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(21, 70);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(200, 25);
            this.dtpInicio.TabIndex = 0;
            // 
            // dtpFinal
            // 
            this.dtpFinal.CustomFormat = "dd/MM/yyyy";
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinal.Location = new System.Drawing.Point(240, 70);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(200, 25);
            this.dtpFinal.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha de Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha de Fin";
            // 
            // btnDescargar
            // 
            this.btnDescargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.btnDescargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargar.Image = global::CapaPresentacion.Properties.Resources.seleccione;
            this.btnDescargar.Location = new System.Drawing.Point(74, 144);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(125, 49);
            this.btnDescargar.TabIndex = 9;
            this.btnDescargar.Text = "Descargar";
            this.btnDescargar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDescargar.UseVisualStyleBackColor = false;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.circulo_cruzado__1_;
            this.btnCancelar.Location = new System.Drawing.Point(257, 144);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(134, 49);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ReporteDescarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(507, 244);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ReporteDescarga";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteDescarga";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Button btnDescargar;
        private System.Windows.Forms.Button btnCancelar;
    }
}