namespace SistemaGestionTaller
{
    partial class frmAgregarEditarProveedor
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
            this.textObservaciones = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxLocalidad = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textPagina = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textTelefono = new System.Windows.Forms.TextBox();
            this.textApellido = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textCp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textCuit = new System.Windows.Forms.TextBox();
            this.textDireccion = new System.Windows.Forms.TextBox();
            this.comboBoxProvincia = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.textNumero = new System.Windows.Forms.TextBox();
            this.textTitular = new System.Windows.Forms.TextBox();
            this.textBanco = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textObservaciones
            // 
            this.textObservaciones.Location = new System.Drawing.Point(6, 19);
            this.textObservaciones.Name = "textObservaciones";
            this.textObservaciones.Size = new System.Drawing.Size(682, 75);
            this.textObservaciones.TabIndex = 0;
            this.textObservaciones.Text = "";
            this.textObservaciones.TextChanged += new System.EventHandler(this.textObservaciones_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxLocalidad);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.textPagina);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textEmail);
            this.groupBox1.Controls.Add(this.textTelefono);
            this.groupBox1.Controls.Add(this.textApellido);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textCp);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textCuit);
            this.groupBox1.Controls.Add(this.textDireccion);
            this.groupBox1.Controls.Add(this.comboBoxProvincia);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 175);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos :: Personales";
            // 
            // comboBoxLocalidad
            // 
            this.comboBoxLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLocalidad.FormattingEnabled = true;
            this.comboBoxLocalidad.Location = new System.Drawing.Point(404, 131);
            this.comboBoxLocalidad.Name = "comboBoxLocalidad";
            this.comboBoxLocalidad.Size = new System.Drawing.Size(259, 21);
            this.comboBoxLocalidad.TabIndex = 41;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 107);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 40;
            this.label14.Text = "Página Web:";
            // 
            // textPagina
            // 
            this.textPagina.Location = new System.Drawing.Point(131, 103);
            this.textPagina.Name = "textPagina";
            this.textPagina.Size = new System.Drawing.Size(173, 20);
            this.textPagina.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "E-Mail:";
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(131, 75);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(173, 20);
            this.textEmail.TabIndex = 3;
            this.textEmail.TextChanged += new System.EventHandler(this.textEmail_TextChanged);
            // 
            // textTelefono
            // 
            this.textTelefono.Location = new System.Drawing.Point(404, 19);
            this.textTelefono.Name = "textTelefono";
            this.textTelefono.Size = new System.Drawing.Size(259, 20);
            this.textTelefono.TabIndex = 4;
            this.textTelefono.TextChanged += new System.EventHandler(this.textTelefono_TextChanged);
            // 
            // textApellido
            // 
            this.textApellido.Location = new System.Drawing.Point(131, 47);
            this.textApellido.Name = "textApellido";
            this.textApellido.Size = new System.Drawing.Size(173, 20);
            this.textApellido.TabIndex = 2;
            this.textApellido.TextChanged += new System.EventHandler(this.textApellido_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(315, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "Telefono:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Nombre/Razón Social:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(315, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Cód. Postal:";
            // 
            // textCp
            // 
            this.textCp.Location = new System.Drawing.Point(404, 47);
            this.textCp.Name = "textCp";
            this.textCp.Size = new System.Drawing.Size(259, 20);
            this.textCp.TabIndex = 5;
            this.textCp.TextChanged += new System.EventHandler(this.textCp_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "CUIT:";
            // 
            // textCuit
            // 
            this.textCuit.Location = new System.Drawing.Point(131, 19);
            this.textCuit.Name = "textCuit";
            this.textCuit.Size = new System.Drawing.Size(173, 20);
            this.textCuit.TabIndex = 0;
            this.textCuit.TextChanged += new System.EventHandler(this.textCuit_TextChanged);
            // 
            // textDireccion
            // 
            this.textDireccion.Location = new System.Drawing.Point(404, 75);
            this.textDireccion.Name = "textDireccion";
            this.textDireccion.Size = new System.Drawing.Size(259, 20);
            this.textDireccion.TabIndex = 6;
            this.textDireccion.TextChanged += new System.EventHandler(this.textDireccion_TextChanged);
            // 
            // comboBoxProvincia
            // 
            this.comboBoxProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxProvincia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProvincia.FormattingEnabled = true;
            this.comboBoxProvincia.Location = new System.Drawing.Point(404, 103);
            this.comboBoxProvincia.Name = "comboBoxProvincia";
            this.comboBoxProvincia.Size = new System.Drawing.Size(259, 21);
            this.comboBoxProvincia.TabIndex = 8;
            this.comboBoxProvincia.SelectedIndexChanged += new System.EventHandler(this.comboBoxProvincia_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(315, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Provincia:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Localidad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Dirección:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textObservaciones);
            this.groupBox2.Location = new System.Drawing.Point(15, 309);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(694, 100);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Observaciones";
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Location = new System.Drawing.Point(601, 420);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(102, 54);
            this.buttonGuardar.TabIndex = 0;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboTipo);
            this.groupBox3.Controls.Add(this.textNumero);
            this.groupBox3.Controls.Add(this.textTitular);
            this.groupBox3.Controls.Add(this.textBanco);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(15, 198);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(694, 100);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos :: Cuenta Bancaria";
            // 
            // comboTipo
            // 
            this.comboTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Items.AddRange(new object[] {
            "CAJA DE AHORRO (PESOS)",
            "CAJA DE AHORRO (DOLARES)",
            "CUENTA CORRIENTE (PESOS)",
            "CUENTA CORRIENTE (DOLARES)"});
            this.comboTipo.Location = new System.Drawing.Point(404, 28);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(259, 21);
            this.comboTipo.TabIndex = 7;
            this.comboTipo.SelectedIndexChanged += new System.EventHandler(this.comboTipo_SelectedIndexChanged);
            // 
            // textNumero
            // 
            this.textNumero.Location = new System.Drawing.Point(404, 63);
            this.textNumero.Name = "textNumero";
            this.textNumero.Size = new System.Drawing.Size(259, 20);
            this.textNumero.TabIndex = 6;
            this.textNumero.TextChanged += new System.EventHandler(this.textNumero_TextChanged);
            // 
            // textTitular
            // 
            this.textTitular.Location = new System.Drawing.Point(91, 62);
            this.textTitular.Name = "textTitular";
            this.textTitular.Size = new System.Drawing.Size(173, 20);
            this.textTitular.TabIndex = 5;
            this.textTitular.TextChanged += new System.EventHandler(this.textTitular_TextChanged);
            // 
            // textBanco
            // 
            this.textBanco.Location = new System.Drawing.Point(91, 27);
            this.textBanco.Name = "textBanco";
            this.textBanco.Size = new System.Drawing.Size(173, 20);
            this.textBanco.TabIndex = 4;
            this.textBanco.TextChanged += new System.EventHandler(this.textBanco_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "N° de Cuenta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de Cuenta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Titular:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Banco:";
            // 
            // frmAgregarEditarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 486);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAgregarEditarProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Proveedor";
            this.Load += new System.EventHandler(this.frmAgregarEditarProveedor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox textObservaciones;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textCp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textCuit;
        private System.Windows.Forms.TextBox textDireccion;
        private System.Windows.Forms.ComboBox comboBoxProvincia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textTelefono;
        private System.Windows.Forms.TextBox textApellido;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboTipo;
        private System.Windows.Forms.TextBox textNumero;
        private System.Windows.Forms.TextBox textTitular;
        private System.Windows.Forms.TextBox textBanco;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textPagina;
        private System.Windows.Forms.ComboBox comboBoxLocalidad;
    }
}