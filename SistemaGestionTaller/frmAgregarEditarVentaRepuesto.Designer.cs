namespace SistemaGestionTaller
{
    partial class frmAgregarEditarVentaRepuesto
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonNuevoCliente = new System.Windows.Forms.Button();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.buttonBuscarCliente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textDescripcion = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabRepuestos = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonEliminarRepuesto = new System.Windows.Forms.Button();
            this.textCantidadRepuesto = new System.Windows.Forms.TextBox();
            this.buttonAgregarRepuesto = new System.Windows.Forms.Button();
            this.textRepuesto = new System.Windows.Forms.TextBox();
            this.buttonBuscarRepuesto = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridRepuesto = new System.Windows.Forms.DataGridView();
            this.idrepuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionrepuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadrepuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciorepuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonDeshacer = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabRepuestos.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRepuesto)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonNuevoCliente);
            this.groupBox1.Controls.Add(this.textNombre);
            this.groupBox1.Controls.Add(this.buttonBuscarCliente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 52);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente :: Datos Personales";
            // 
            // buttonNuevoCliente
            // 
            this.buttonNuevoCliente.Location = new System.Drawing.Point(482, 20);
            this.buttonNuevoCliente.Name = "buttonNuevoCliente";
            this.buttonNuevoCliente.Size = new System.Drawing.Size(27, 23);
            this.buttonNuevoCliente.TabIndex = 6;
            this.buttonNuevoCliente.Text = "+";
            this.buttonNuevoCliente.UseVisualStyleBackColor = true;
            this.buttonNuevoCliente.Click += new System.EventHandler(this.buttonNuevoCliente_Click);
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(127, 21);
            this.textNombre.Name = "textNombre";
            this.textNombre.ReadOnly = true;
            this.textNombre.Size = new System.Drawing.Size(316, 20);
            this.textNombre.TabIndex = 3;
            // 
            // buttonBuscarCliente
            // 
            this.buttonBuscarCliente.Location = new System.Drawing.Point(449, 20);
            this.buttonBuscarCliente.Name = "buttonBuscarCliente";
            this.buttonBuscarCliente.Size = new System.Drawing.Size(27, 23);
            this.buttonBuscarCliente.TabIndex = 0;
            this.buttonBuscarCliente.Text = "...";
            this.buttonBuscarCliente.UseVisualStyleBackColor = true;
            this.buttonBuscarCliente.Click += new System.EventHandler(this.buttonBuscarCliente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre/Razón Social:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(138, 20);
            this.dateTimePicker1.TabIndex = 22;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Location = new System.Drawing.Point(533, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 52);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fecha";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textDescripcion);
            this.groupBox5.Location = new System.Drawing.Point(13, 70);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(674, 75);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Descripción";
            // 
            // textDescripcion
            // 
            this.textDescripcion.Location = new System.Drawing.Point(7, 19);
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(661, 50);
            this.textDescripcion.TabIndex = 0;
            this.textDescripcion.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRepuestos);
            this.tabControl1.Location = new System.Drawing.Point(12, 151);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(675, 359);
            this.tabControl1.TabIndex = 1;
            // 
            // tabRepuestos
            // 
            this.tabRepuestos.Controls.Add(this.groupBox4);
            this.tabRepuestos.Controls.Add(this.dataGridRepuesto);
            this.tabRepuestos.Location = new System.Drawing.Point(4, 22);
            this.tabRepuestos.Name = "tabRepuestos";
            this.tabRepuestos.Padding = new System.Windows.Forms.Padding(3);
            this.tabRepuestos.Size = new System.Drawing.Size(667, 333);
            this.tabRepuestos.TabIndex = 1;
            this.tabRepuestos.Text = "Repuestos";
            this.tabRepuestos.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonEliminarRepuesto);
            this.groupBox4.Controls.Add(this.textCantidadRepuesto);
            this.groupBox4.Controls.Add(this.buttonAgregarRepuesto);
            this.groupBox4.Controls.Add(this.textRepuesto);
            this.groupBox4.Controls.Add(this.buttonBuscarRepuesto);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(18, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(630, 61);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            // 
            // buttonEliminarRepuesto
            // 
            this.buttonEliminarRepuesto.Image = global::SistemaGestionTaller.Properties.Resources.eliminar;
            this.buttonEliminarRepuesto.Location = new System.Drawing.Point(584, 13);
            this.buttonEliminarRepuesto.Name = "buttonEliminarRepuesto";
            this.buttonEliminarRepuesto.Size = new System.Drawing.Size(40, 40);
            this.buttonEliminarRepuesto.TabIndex = 43;
            this.buttonEliminarRepuesto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminarRepuesto.UseVisualStyleBackColor = true;
            this.buttonEliminarRepuesto.Click += new System.EventHandler(this.buttonEliminarRepuesto_Click);
            // 
            // textCantidadRepuesto
            // 
            this.textCantidadRepuesto.Location = new System.Drawing.Point(473, 23);
            this.textCantidadRepuesto.Name = "textCantidadRepuesto";
            this.textCantidadRepuesto.Size = new System.Drawing.Size(38, 20);
            this.textCantidadRepuesto.TabIndex = 0;
            this.textCantidadRepuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textCantidadRepuesto.TextChanged += new System.EventHandler(this.textCantidadRepuesto_TextChanged);
            this.textCantidadRepuesto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCantidadRepuesto_KeyPress);
            // 
            // buttonAgregarRepuesto
            // 
            this.buttonAgregarRepuesto.Image = global::SistemaGestionTaller.Properties.Resources.agregar;
            this.buttonAgregarRepuesto.Location = new System.Drawing.Point(538, 13);
            this.buttonAgregarRepuesto.Name = "buttonAgregarRepuesto";
            this.buttonAgregarRepuesto.Size = new System.Drawing.Size(40, 40);
            this.buttonAgregarRepuesto.TabIndex = 1;
            this.buttonAgregarRepuesto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAgregarRepuesto.UseVisualStyleBackColor = true;
            this.buttonAgregarRepuesto.Click += new System.EventHandler(this.buttonAgregarRepuesto_Click);
            // 
            // textRepuesto
            // 
            this.textRepuesto.Location = new System.Drawing.Point(73, 23);
            this.textRepuesto.Name = "textRepuesto";
            this.textRepuesto.ReadOnly = true;
            this.textRepuesto.Size = new System.Drawing.Size(262, 20);
            this.textRepuesto.TabIndex = 6;
            // 
            // buttonBuscarRepuesto
            // 
            this.buttonBuscarRepuesto.Location = new System.Drawing.Point(356, 22);
            this.buttonBuscarRepuesto.Name = "buttonBuscarRepuesto";
            this.buttonBuscarRepuesto.Size = new System.Drawing.Size(27, 23);
            this.buttonBuscarRepuesto.TabIndex = 0;
            this.buttonBuscarRepuesto.Text = "...";
            this.buttonBuscarRepuesto.UseVisualStyleBackColor = true;
            this.buttonBuscarRepuesto.Click += new System.EventHandler(this.buttonBuscarRepuesto_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(415, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Cantidad:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Repuesto:";
            // 
            // dataGridRepuesto
            // 
            this.dataGridRepuesto.AllowUserToAddRows = false;
            this.dataGridRepuesto.AllowUserToDeleteRows = false;
            this.dataGridRepuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRepuesto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idrepuesto,
            this.marca,
            this.modelo,
            this.descripcionrepuesto,
            this.cantidadrepuesto,
            this.preciorepuesto});
            this.dataGridRepuesto.Location = new System.Drawing.Point(19, 90);
            this.dataGridRepuesto.MultiSelect = false;
            this.dataGridRepuesto.Name = "dataGridRepuesto";
            this.dataGridRepuesto.RowHeadersVisible = false;
            this.dataGridRepuesto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridRepuesto.Size = new System.Drawing.Size(630, 181);
            this.dataGridRepuesto.TabIndex = 17;
            this.dataGridRepuesto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRepuesto_CellClick);
            this.dataGridRepuesto.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRepuesto_CellEndEdit);
            // 
            // idrepuesto
            // 
            this.idrepuesto.HeaderText = "ID";
            this.idrepuesto.Name = "idrepuesto";
            this.idrepuesto.ReadOnly = true;
            this.idrepuesto.Visible = false;
            // 
            // marca
            // 
            this.marca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.marca.HeaderText = "Marca";
            this.marca.Name = "marca";
            this.marca.ReadOnly = true;
            this.marca.Width = 62;
            // 
            // modelo
            // 
            this.modelo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.modelo.HeaderText = "Modelo";
            this.modelo.Name = "modelo";
            this.modelo.ReadOnly = true;
            this.modelo.Width = 67;
            // 
            // descripcionrepuesto
            // 
            this.descripcionrepuesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcionrepuesto.HeaderText = "Descripción";
            this.descripcionrepuesto.Name = "descripcionrepuesto";
            this.descripcionrepuesto.ReadOnly = true;
            // 
            // cantidadrepuesto
            // 
            this.cantidadrepuesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cantidadrepuesto.HeaderText = "Cantidad";
            this.cantidadrepuesto.Name = "cantidadrepuesto";
            this.cantidadrepuesto.Width = 74;
            // 
            // preciorepuesto
            // 
            this.preciorepuesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.preciorepuesto.DefaultCellStyle = dataGridViewCellStyle1;
            this.preciorepuesto.HeaderText = "Precio";
            this.preciorepuesto.Name = "preciorepuesto";
            this.preciorepuesto.ReadOnly = true;
            this.preciorepuesto.Width = 62;
            // 
            // textTotal
            // 
            this.textTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotal.Location = new System.Drawing.Point(107, 516);
            this.textTotal.Name = "textTotal";
            this.textTotal.ReadOnly = true;
            this.textTotal.Size = new System.Drawing.Size(144, 31);
            this.textTotal.TabIndex = 26;
            this.textTotal.Text = "0.0";
            this.textTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 519);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 25);
            this.label5.TabIndex = 25;
            this.label5.Text = "TOTAL:";
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Location = new System.Drawing.Point(585, 519);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(102, 54);
            this.buttonGuardar.TabIndex = 24;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonDeshacer
            // 
            this.buttonDeshacer.Image = global::SistemaGestionTaller.Properties.Resources.deshacer_icono_5403_32;
            this.buttonDeshacer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeshacer.Location = new System.Drawing.Point(477, 519);
            this.buttonDeshacer.Name = "buttonDeshacer";
            this.buttonDeshacer.Size = new System.Drawing.Size(102, 54);
            this.buttonDeshacer.TabIndex = 27;
            this.buttonDeshacer.Text = "Deshacer cambios";
            this.buttonDeshacer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDeshacer.UseVisualStyleBackColor = true;
            this.buttonDeshacer.Click += new System.EventHandler(this.buttonDeshacer_Click);
            // 
            // frmAgregarEditarVentaRepuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 576);
            this.Controls.Add(this.buttonDeshacer);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.textTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAgregarEditarVentaRepuesto";
            this.Text = "Venta de Repuestos";
            this.Load += new System.EventHandler(this.frmAgregarEditarVentaRepuesto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabRepuestos.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRepuesto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonNuevoCliente;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Button buttonBuscarCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox textDescripcion;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabRepuestos;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonEliminarRepuesto;
        private System.Windows.Forms.TextBox textCantidadRepuesto;
        private System.Windows.Forms.Button buttonAgregarRepuesto;
        private System.Windows.Forms.TextBox textRepuesto;
        private System.Windows.Forms.Button buttonBuscarRepuesto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridRepuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idrepuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionrepuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadrepuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn preciorepuesto;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.TextBox textTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonDeshacer;
    }
}