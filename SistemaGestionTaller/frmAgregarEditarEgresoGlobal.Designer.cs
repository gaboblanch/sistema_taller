namespace SistemaGestionTaller
{
    partial class frmAgregarEditarEgresoGlobal
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
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxImporte = new System.Windows.Forms.TextBox();
            this.textBoxDescripcion = new System.Windows.Forms.RichTextBox();
            this.dateTimePickerFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Location = new System.Drawing.Point(319, 208);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(102, 54);
            this.buttonGuardar.TabIndex = 15;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBoxTipo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxImporte);
            this.groupBox1.Controls.Add(this.textBoxDescripcion);
            this.groupBox1.Controls.Add(this.dateTimePickerFecha);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 196);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles Egreso";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(207, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "*";
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Items.AddRange(new object[] {
            "EFECTIVO",
            "CHEQUE",
            "GLOBAL",
            "BANCO"});
            this.comboBoxTipo.Location = new System.Drawing.Point(84, 66);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipo.TabIndex = 6;
            this.comboBoxTipo.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tipo:";
            // 
            // textBoxImporte
            // 
            this.textBoxImporte.Location = new System.Drawing.Point(84, 107);
            this.textBoxImporte.Name = "textBoxImporte";
            this.textBoxImporte.Size = new System.Drawing.Size(121, 20);
            this.textBoxImporte.TabIndex = 1;
            this.textBoxImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxImporte.TextChanged += new System.EventHandler(this.textBoxImporte_TextChanged);
            this.textBoxImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxImporte_KeyPress);
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(84, 147);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(323, 42);
            this.textBoxDescripcion.TabIndex = 2;
            this.textBoxDescripcion.Text = "";
            // 
            // dateTimePickerFecha
            // 
            this.dateTimePickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFecha.Location = new System.Drawing.Point(84, 26);
            this.dateTimePickerFecha.Name = "dateTimePickerFecha";
            this.dateTimePickerFecha.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerFecha.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Importe:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripción:";
            // 
            // frmAgregarEditarEgresoGlobal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 274);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAgregarEditarEgresoGlobal";
            this.Text = "Agregar/Editar Egreso";
            this.Load += new System.EventHandler(this.frmAgregarEditarEgresoGlobal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxImporte;
        private System.Windows.Forms.RichTextBox textBoxDescripcion;
        private System.Windows.Forms.DateTimePicker dateTimePickerFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}