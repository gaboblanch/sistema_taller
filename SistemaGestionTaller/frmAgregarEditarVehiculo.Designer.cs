namespace SistemaGestionTaller
{
    partial class frmAgregarEditarVehiculo
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textModelo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textAnio = new System.Windows.Forms.MaskedTextBox();
            this.textDominio = new System.Windows.Forms.MaskedTextBox();
            this.comboMarca = new System.Windows.Forms.ComboBox();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonBuscarCliente = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textObservaciones = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.textCapacidad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dominio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Marca:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(296, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Modelo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Año:";
            // 
            // textModelo
            // 
            this.textModelo.Location = new System.Drawing.Point(350, 24);
            this.textModelo.Name = "textModelo";
            this.textModelo.Size = new System.Drawing.Size(121, 20);
            this.textModelo.TabIndex = 2;
            this.textModelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textAnio);
            this.groupBox1.Controls.Add(this.textDominio);
            this.groupBox1.Controls.Add(this.comboMarca);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textModelo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 111);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Características";
            // 
            // textAnio
            // 
            this.textAnio.Location = new System.Drawing.Point(350, 64);
            this.textAnio.Mask = "0000";
            this.textAnio.Name = "textAnio";
            this.textAnio.Size = new System.Drawing.Size(121, 20);
            this.textAnio.TabIndex = 3;
            this.textAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textDominio
            // 
            this.textDominio.Location = new System.Drawing.Point(75, 24);
            this.textDominio.Mask = "AAA-000";
            this.textDominio.Name = "textDominio";
            this.textDominio.Size = new System.Drawing.Size(121, 20);
            this.textDominio.TabIndex = 0;
            this.textDominio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboMarca
            // 
            this.comboMarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboMarca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboMarca.FormattingEnabled = true;
            this.comboMarca.Items.AddRange(new object[] {
            "Alfa Romeo",
            "BMW",
            "Chevrolet",
            "Citroën",
            "Dacia",
            "Daihatsu",
            "Dodge",
            "Fiat",
            "Ford",
            "Honda",
            "Hyundai",
            "Isuzu",
            "Jeep",
            "Kia",
            "Lada",
            "Lancia",
            "Mazda",
            "Mercedes Benz",
            "Mini",
            "Mitsubishi",
            "Nissan",
            "Opel",
            "Peugeot",
            "Renault",
            "Saab",
            "Seat",
            "SsangYong",
            "Subaru",
            "Suzuki",
            "Tata",
            "Toyota",
            "Volkswagen",
            "Volvo"});
            this.comboMarca.Location = new System.Drawing.Point(75, 64);
            this.comboMarca.Name = "comboMarca";
            this.comboMarca.Size = new System.Drawing.Size(121, 21);
            this.comboMarca.TabIndex = 1;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Location = new System.Drawing.Point(411, 426);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(102, 54);
            this.buttonGuardar.TabIndex = 0;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textNombre);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.buttonBuscarCliente);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(503, 58);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Dueño";
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(130, 24);
            this.textNombre.Name = "textNombre";
            this.textNombre.ReadOnly = true;
            this.textNombre.Size = new System.Drawing.Size(195, 20);
            this.textNombre.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Nombre/Razón Social:";
            // 
            // buttonBuscarCliente
            // 
            this.buttonBuscarCliente.Location = new System.Drawing.Point(331, 22);
            this.buttonBuscarCliente.Name = "buttonBuscarCliente";
            this.buttonBuscarCliente.Size = new System.Drawing.Size(26, 23);
            this.buttonBuscarCliente.TabIndex = 0;
            this.buttonBuscarCliente.Text = "...";
            this.buttonBuscarCliente.UseVisualStyleBackColor = true;
            this.buttonBuscarCliente.Click += new System.EventHandler(this.buttonBuscarCliente_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textObservaciones);
            this.groupBox3.Location = new System.Drawing.Point(9, 335);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(506, 85);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Observaciones";
            // 
            // textObservaciones
            // 
            this.textObservaciones.Location = new System.Drawing.Point(6, 19);
            this.textObservaciones.Name = "textObservaciones";
            this.textObservaciones.Size = new System.Drawing.Size(494, 58);
            this.textObservaciones.TabIndex = 0;
            this.textObservaciones.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.comboBoxTipo);
            this.groupBox4.Controls.Add(this.textCapacidad);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(12, 209);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(504, 113);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Carga Gas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Gr.";
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Location = new System.Drawing.Point(130, 25);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(211, 21);
            this.comboBoxTipo.TabIndex = 3;
            // 
            // textCapacidad
            // 
            this.textCapacidad.Location = new System.Drawing.Point(130, 68);
            this.textCapacidad.Name = "textCapacidad";
            this.textCapacidad.Size = new System.Drawing.Size(94, 20);
            this.textCapacidad.TabIndex = 2;
            this.textCapacidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Capacidad de Carga:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tipo de Gas:";
            // 
            // frmAgregarEditarVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 491);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAgregarEditarVehiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vehículo";
            this.Load += new System.EventHandler(this.frmAgregarEditarVehiculo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textModelo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.ComboBox comboMarca;
        private System.Windows.Forms.MaskedTextBox textDominio;
        private System.Windows.Forms.MaskedTextBox textAnio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonBuscarCliente;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox textObservaciones;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBoxTipo;
        private System.Windows.Forms.TextBox textCapacidad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
    }
}