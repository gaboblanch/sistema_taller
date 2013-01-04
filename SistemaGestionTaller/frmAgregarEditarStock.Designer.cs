namespace SistemaGestionTaller
{
    partial class frmAgregarEditarStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonProveedor = new System.Windows.Forms.Button();
            this.textBoxProveedor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonNuevoRepuesto = new System.Windows.Forms.Button();
            this.textRepuesto = new System.Windows.Forms.TextBox();
            this.buttonEliminarRepuesto = new System.Windows.Forms.Button();
            this.buttonAgregarRepuesto = new System.Windows.Forms.Button();
            this.buttonBuscarRepuesto = new System.Windows.Forms.Button();
            this.dataGridRepuesto = new System.Windows.Forms.DataGridView();
            this.idrepuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigorepuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionrepuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidaddeposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciounitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRepuesto)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonProveedor);
            this.groupBox1.Controls.Add(this.textBoxProveedor);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 56);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos :: Proveedor";
            // 
            // buttonProveedor
            // 
            this.buttonProveedor.Location = new System.Drawing.Point(361, 19);
            this.buttonProveedor.Name = "buttonProveedor";
            this.buttonProveedor.Size = new System.Drawing.Size(24, 23);
            this.buttonProveedor.TabIndex = 9;
            this.buttonProveedor.Text = "...";
            this.buttonProveedor.UseVisualStyleBackColor = true;
            this.buttonProveedor.Click += new System.EventHandler(this.buttonProveedor_Click);
            // 
            // textBoxProveedor
            // 
            this.textBoxProveedor.Location = new System.Drawing.Point(80, 20);
            this.textBoxProveedor.Name = "textBoxProveedor";
            this.textBoxProveedor.ReadOnly = true;
            this.textBoxProveedor.Size = new System.Drawing.Size(275, 20);
            this.textBoxProveedor.TabIndex = 9;
            this.textBoxProveedor.TextChanged += new System.EventHandler(this.textBoxProveedor_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Proveedor:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonEditar);
            this.groupBox4.Controls.Add(this.buttonNuevoRepuesto);
            this.groupBox4.Controls.Add(this.textRepuesto);
            this.groupBox4.Controls.Add(this.buttonEliminarRepuesto);
            this.groupBox4.Controls.Add(this.buttonAgregarRepuesto);
            this.groupBox4.Controls.Add(this.buttonBuscarRepuesto);
            this.groupBox4.Location = new System.Drawing.Point(12, 74);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(808, 67);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Repuesto";
            // 
            // buttonNuevoRepuesto
            // 
            this.buttonNuevoRepuesto.Location = new System.Drawing.Point(500, 28);
            this.buttonNuevoRepuesto.Name = "buttonNuevoRepuesto";
            this.buttonNuevoRepuesto.Size = new System.Drawing.Size(67, 23);
            this.buttonNuevoRepuesto.TabIndex = 7;
            this.buttonNuevoRepuesto.Text = "Nuevo";
            this.buttonNuevoRepuesto.UseVisualStyleBackColor = true;
            this.buttonNuevoRepuesto.Click += new System.EventHandler(this.button1_Click);
            // 
            // textRepuesto
            // 
            this.textRepuesto.Location = new System.Drawing.Point(80, 30);
            this.textRepuesto.Name = "textRepuesto";
            this.textRepuesto.ReadOnly = true;
            this.textRepuesto.Size = new System.Drawing.Size(384, 20);
            this.textRepuesto.TabIndex = 6;
            this.textRepuesto.TextChanged += new System.EventHandler(this.textRepuesto_TextChanged);
            // 
            // buttonEliminarRepuesto
            // 
            this.buttonEliminarRepuesto.Image = global::SistemaGestionTaller.Properties.Resources.eliminar;
            this.buttonEliminarRepuesto.Location = new System.Drawing.Point(727, 19);
            this.buttonEliminarRepuesto.Name = "buttonEliminarRepuesto";
            this.buttonEliminarRepuesto.Size = new System.Drawing.Size(40, 40);
            this.buttonEliminarRepuesto.TabIndex = 5;
            this.buttonEliminarRepuesto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminarRepuesto.UseVisualStyleBackColor = true;
            this.buttonEliminarRepuesto.Click += new System.EventHandler(this.buttonEliminarRepuesto_Click);
            // 
            // buttonAgregarRepuesto
            // 
            this.buttonAgregarRepuesto.Image = global::SistemaGestionTaller.Properties.Resources.agregar;
            this.buttonAgregarRepuesto.Location = new System.Drawing.Point(681, 19);
            this.buttonAgregarRepuesto.Name = "buttonAgregarRepuesto";
            this.buttonAgregarRepuesto.Size = new System.Drawing.Size(40, 40);
            this.buttonAgregarRepuesto.TabIndex = 4;
            this.buttonAgregarRepuesto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAgregarRepuesto.UseVisualStyleBackColor = true;
            this.buttonAgregarRepuesto.Click += new System.EventHandler(this.buttonAgregarRepuesto_Click);
            // 
            // buttonBuscarRepuesto
            // 
            this.buttonBuscarRepuesto.Location = new System.Drawing.Point(470, 28);
            this.buttonBuscarRepuesto.Name = "buttonBuscarRepuesto";
            this.buttonBuscarRepuesto.Size = new System.Drawing.Size(24, 23);
            this.buttonBuscarRepuesto.TabIndex = 1;
            this.buttonBuscarRepuesto.Text = "...";
            this.buttonBuscarRepuesto.UseVisualStyleBackColor = true;
            this.buttonBuscarRepuesto.Click += new System.EventHandler(this.buttonBuscarRepuesto_Click);
            // 
            // dataGridRepuesto
            // 
            this.dataGridRepuesto.AllowUserToAddRows = false;
            this.dataGridRepuesto.AllowUserToDeleteRows = false;
            this.dataGridRepuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRepuesto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idrepuesto,
            this.codigorepuesto,
            this.marca,
            this.modelo,
            this.descripcionrepuesto,
            this.cantidad,
            this.cantidaddeposito,
            this.minimo,
            this.costo,
            this.preciounitario});
            this.dataGridRepuesto.Location = new System.Drawing.Point(13, 147);
            this.dataGridRepuesto.MultiSelect = false;
            this.dataGridRepuesto.Name = "dataGridRepuesto";
            this.dataGridRepuesto.RowHeadersVisible = false;
            this.dataGridRepuesto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridRepuesto.Size = new System.Drawing.Size(807, 282);
            this.dataGridRepuesto.TabIndex = 19;
            this.dataGridRepuesto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRepuesto_CellClick);
            this.dataGridRepuesto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRepuesto_CellDoubleClick);
            this.dataGridRepuesto.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRepuesto_CellEndEdit);
            // 
            // idrepuesto
            // 
            dataGridViewCellStyle11.NullValue = "0";
            this.idrepuesto.DefaultCellStyle = dataGridViewCellStyle11;
            this.idrepuesto.HeaderText = "ID";
            this.idrepuesto.Name = "idrepuesto";
            this.idrepuesto.Visible = false;
            // 
            // codigorepuesto
            // 
            this.codigorepuesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codigorepuesto.HeaderText = "Código";
            this.codigorepuesto.Name = "codigorepuesto";
            this.codigorepuesto.Width = 65;
            // 
            // marca
            // 
            this.marca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.marca.HeaderText = "Marca";
            this.marca.Name = "marca";
            this.marca.ReadOnly = true;
            this.marca.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            // cantidad
            // 
            this.cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.NullValue = "0";
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle12;
            this.cantidad.HeaderText = "Cantidad Entrada";
            this.cantidad.Name = "cantidad";
            this.cantidad.Width = 105;
            // 
            // cantidaddeposito
            // 
            this.cantidaddeposito.HeaderText = "Cantidad Depósito";
            this.cantidaddeposito.Name = "cantidaddeposito";
            this.cantidaddeposito.ReadOnly = true;
            // 
            // minimo
            // 
            this.minimo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.NullValue = "0";
            this.minimo.DefaultCellStyle = dataGridViewCellStyle13;
            this.minimo.HeaderText = "Minimo";
            this.minimo.Name = "minimo";
            this.minimo.Width = 65;
            // 
            // costo
            // 
            this.costo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Format = "C2";
            dataGridViewCellStyle14.NullValue = null;
            this.costo.DefaultCellStyle = dataGridViewCellStyle14;
            this.costo.HeaderText = "Costo";
            this.costo.Name = "costo";
            this.costo.Width = 59;
            // 
            // preciounitario
            // 
            this.preciounitario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.Format = "C2";
            dataGridViewCellStyle15.NullValue = null;
            this.preciounitario.DefaultCellStyle = dataGridViewCellStyle15;
            this.preciounitario.HeaderText = "Precio Unitario";
            this.preciounitario.Name = "preciounitario";
            this.preciounitario.Width = 93;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Location = new System.Drawing.Point(718, 435);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(102, 54);
            this.buttonGuardar.TabIndex = 20;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dateTimePicker1);
            this.groupBox6.Location = new System.Drawing.Point(500, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(320, 56);
            this.groupBox6.TabIndex = 24;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Fecha";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(103, 18);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(137, 20);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // buttonEditar
            // 
            this.buttonEditar.Enabled = false;
            this.buttonEditar.Location = new System.Drawing.Point(573, 28);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(67, 23);
            this.buttonEditar.TabIndex = 8;
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // frmAgregarEditarStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 501);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dataGridRepuesto);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAgregarEditarStock";
            this.Text = "Gestión de Stock";
            this.Load += new System.EventHandler(this.frmAgregarEditarStock_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRepuesto)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonProveedor;
        private System.Windows.Forms.TextBox textBoxProveedor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonEliminarRepuesto;
        private System.Windows.Forms.Button buttonAgregarRepuesto;
        private System.Windows.Forms.Button buttonBuscarRepuesto;
        private System.Windows.Forms.DataGridView dataGridRepuesto;
        private System.Windows.Forms.Button buttonNuevoRepuesto;
        private System.Windows.Forms.TextBox textRepuesto;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idrepuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigorepuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionrepuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidaddeposito;
        private System.Windows.Forms.DataGridViewTextBoxColumn minimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn preciounitario;
        private System.Windows.Forms.Button buttonEditar;

    }
}