namespace SistemaGestionTaller
{
    partial class frmGestionVentaRepuesto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.dataGridReparacion = new System.Windows.Forms.DataGridView();
            this.idventarepuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreRazonsocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.estadoventa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textFiltro = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReparacion)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Image = global::SistemaGestionTaller.Properties.Resources.agregar;
            this.buttonAgregar.Location = new System.Drawing.Point(783, 458);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(40, 40);
            this.buttonAgregar.TabIndex = 45;
            this.buttonAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Image = global::SistemaGestionTaller.Properties.Resources.eliminar;
            this.buttonEliminar.Location = new System.Drawing.Point(691, 458);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(40, 40);
            this.buttonEliminar.TabIndex = 46;
            this.buttonEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Image = global::SistemaGestionTaller.Properties.Resources.editar;
            this.buttonEditar.Location = new System.Drawing.Point(737, 458);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(40, 40);
            this.buttonEditar.TabIndex = 47;
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePickerInicio);
            this.groupBox1.Controls.Add(this.dateTimePickerFin);
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 34);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Inicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fin:";
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerInicio.Location = new System.Drawing.Point(55, 10);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(85, 20);
            this.dateTimePickerInicio.TabIndex = 1;
            this.dateTimePickerInicio.ValueChanged += new System.EventHandler(this.dateTimePickerInicio_ValueChanged);
            // 
            // dateTimePickerFin
            // 
            this.dateTimePickerFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFin.Location = new System.Drawing.Point(211, 10);
            this.dateTimePickerFin.Name = "dateTimePickerFin";
            this.dateTimePickerFin.Size = new System.Drawing.Size(85, 20);
            this.dateTimePickerFin.TabIndex = 0;
            this.dateTimePickerFin.ValueChanged += new System.EventHandler(this.dateTimePickerFin_ValueChanged);
            // 
            // dataGridReparacion
            // 
            this.dataGridReparacion.AllowUserToAddRows = false;
            this.dataGridReparacion.AllowUserToDeleteRows = false;
            this.dataGridReparacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReparacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idventarepuesto,
            this.fecha,
            this.nombreRazonsocial,
            this.descripcion,
            this.importe,
            this.pagar,
            this.estadoventa});
            this.dataGridReparacion.Location = new System.Drawing.Point(12, 40);
            this.dataGridReparacion.MultiSelect = false;
            this.dataGridReparacion.Name = "dataGridReparacion";
            this.dataGridReparacion.RowHeadersVisible = false;
            this.dataGridReparacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridReparacion.Size = new System.Drawing.Size(811, 412);
            this.dataGridReparacion.TabIndex = 50;
            this.dataGridReparacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridReparacion_CellClick);
            this.dataGridReparacion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridReparacion_CellDoubleClick);
            // 
            // idventarepuesto
            // 
            this.idventarepuesto.HeaderText = "ID";
            this.idventarepuesto.Name = "idventarepuesto";
            this.idventarepuesto.ReadOnly = true;
            this.idventarepuesto.Visible = false;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // nombreRazonsocial
            // 
            this.nombreRazonsocial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nombreRazonsocial.HeaderText = "Nombre / Razón Social";
            this.nombreRazonsocial.Name = "nombreRazonsocial";
            this.nombreRazonsocial.ReadOnly = true;
            this.nombreRazonsocial.Width = 105;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 250;
            // 
            // importe
            // 
            this.importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.importe.DefaultCellStyle = dataGridViewCellStyle2;
            this.importe.HeaderText = "Importe";
            this.importe.Name = "importe";
            this.importe.ReadOnly = true;
            this.importe.Width = 67;
            // 
            // pagar
            // 
            this.pagar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pagar.HeaderText = "Pagar";
            this.pagar.Name = "pagar";
            this.pagar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pagar.Text = "PAGAR";
            this.pagar.UseColumnTextForButtonValue = true;
            this.pagar.Width = 41;
            // 
            // estadoventa
            // 
            this.estadoventa.HeaderText = "Estado";
            this.estadoventa.Name = "estadoventa";
            this.estadoventa.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(638, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Apellido:";
            // 
            // textFiltro
            // 
            this.textFiltro.Location = new System.Drawing.Point(691, 10);
            this.textFiltro.Name = "textFiltro";
            this.textFiltro.Size = new System.Drawing.Size(132, 20);
            this.textFiltro.TabIndex = 51;
            // 
            // frmGestionVentaRepuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 510);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textFiltro);
            this.Controls.Add(this.dataGridReparacion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonEditar);
            this.Name = "frmGestionVentaRepuesto";
            this.Text = "Gestión de Ventas de Repuestos";
            this.Load += new System.EventHandler(this.frmGestionVentaRepuesto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReparacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.DataGridView dataGridReparacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textFiltro;
        private System.Windows.Forms.DataGridViewTextBoxColumn idventarepuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreRazonsocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.DataGridViewButtonColumn pagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoventa;
    }
}