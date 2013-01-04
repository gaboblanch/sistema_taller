namespace SistemaGestionTaller
{
    partial class frmGestionGarantia
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
            this.buttonImprimir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxTotalImporte = new System.Windows.Forms.TextBox();
            this.textBoxTotalOt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBuscar = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.textFiltro = new System.Windows.Forms.TextBox();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.dataGridReparacion = new System.Windows.Forms.DataGridView();
            this.idgarantia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoreparacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreRazonsocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costogarantia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idvehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoreparacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReparacion)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonImprimir.Location = new System.Drawing.Point(827, 513);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.Size = new System.Drawing.Size(75, 23);
            this.buttonImprimir.TabIndex = 63;
            this.buttonImprimir.Text = "Imprimir";
            this.buttonImprimir.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.textBoxTotalImporte);
            this.groupBox2.Controls.Add(this.textBoxTotalOt);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 477);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 67);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            // 
            // textBoxTotalImporte
            // 
            this.textBoxTotalImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotalImporte.Location = new System.Drawing.Point(155, 40);
            this.textBoxTotalImporte.Name = "textBoxTotalImporte";
            this.textBoxTotalImporte.ReadOnly = true;
            this.textBoxTotalImporte.Size = new System.Drawing.Size(100, 22);
            this.textBoxTotalImporte.TabIndex = 3;
            this.textBoxTotalImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxTotalOt
            // 
            this.textBoxTotalOt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotalOt.Location = new System.Drawing.Point(155, 11);
            this.textBoxTotalOt.Name = "textBoxTotalOt";
            this.textBoxTotalOt.ReadOnly = true;
            this.textBoxTotalOt.Size = new System.Drawing.Size(100, 22);
            this.textBoxTotalOt.TabIndex = 2;
            this.textBoxTotalOt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Total Importes:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total de Garantías:";
            // 
            // comboBoxBuscar
            // 
            this.comboBoxBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxBuscar.FormattingEnabled = true;
            this.comboBoxBuscar.Items.AddRange(new object[] {
            "Apellido",
            "Dominio",
            "N° de Factura"});
            this.comboBoxBuscar.Location = new System.Drawing.Point(746, 14);
            this.comboBoxBuscar.Name = "comboBoxBuscar";
            this.comboBoxBuscar.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBuscar.TabIndex = 61;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePickerInicio);
            this.groupBox1.Controls.Add(this.dateTimePickerFin);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 34);
            this.groupBox1.TabIndex = 60;
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
            // textFiltro
            // 
            this.textFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textFiltro.Location = new System.Drawing.Point(873, 14);
            this.textFiltro.Name = "textFiltro";
            this.textFiltro.Size = new System.Drawing.Size(132, 20);
            this.textFiltro.TabIndex = 59;
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEliminar.Image = global::SistemaGestionTaller.Properties.Resources.eliminar;
            this.buttonEliminar.Location = new System.Drawing.Point(919, 504);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(40, 40);
            this.buttonEliminar.TabIndex = 57;
            this.buttonEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditar.Image = global::SistemaGestionTaller.Properties.Resources.editar;
            this.buttonEditar.Location = new System.Drawing.Point(965, 504);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(40, 40);
            this.buttonEditar.TabIndex = 58;
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // dataGridReparacion
            // 
            this.dataGridReparacion.AllowUserToAddRows = false;
            this.dataGridReparacion.AllowUserToDeleteRows = false;
            this.dataGridReparacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridReparacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReparacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idgarantia,
            this.fecha,
            this.codigoreparacion,
            this.nombreRazonsocial,
            this.descripcion,
            this.costogarantia,
            this.idvehiculo,
            this.vehiculo,
            this.estadoreparacion});
            this.dataGridReparacion.Location = new System.Drawing.Point(12, 43);
            this.dataGridReparacion.MultiSelect = false;
            this.dataGridReparacion.Name = "dataGridReparacion";
            this.dataGridReparacion.RowHeadersVisible = false;
            this.dataGridReparacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridReparacion.Size = new System.Drawing.Size(993, 428);
            this.dataGridReparacion.TabIndex = 55;
            this.dataGridReparacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridReparacion_CellClick);
            this.dataGridReparacion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridReparacion_CellDoubleClick);
            // 
            // idgarantia
            // 
            this.idgarantia.HeaderText = "ID";
            this.idgarantia.Name = "idgarantia";
            this.idgarantia.ReadOnly = true;
            this.idgarantia.Visible = false;
            // 
            // fecha
            // 
            this.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 62;
            // 
            // codigoreparacion
            // 
            this.codigoreparacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.codigoreparacion.HeaderText = "Código de Reparación";
            this.codigoreparacion.Name = "codigoreparacion";
            this.codigoreparacion.Width = 126;
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
            // costogarantia
            // 
            this.costogarantia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.costogarantia.DefaultCellStyle = dataGridViewCellStyle1;
            this.costogarantia.HeaderText = "Costo";
            this.costogarantia.Name = "costogarantia";
            this.costogarantia.ReadOnly = true;
            this.costogarantia.Width = 59;
            // 
            // idvehiculo
            // 
            this.idvehiculo.HeaderText = "IdVehiculo";
            this.idvehiculo.Name = "idvehiculo";
            this.idvehiculo.ReadOnly = true;
            this.idvehiculo.Visible = false;
            // 
            // vehiculo
            // 
            this.vehiculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vehiculo.HeaderText = "Vehículo";
            this.vehiculo.Name = "vehiculo";
            this.vehiculo.ReadOnly = true;
            this.vehiculo.Width = 75;
            // 
            // estadoreparacion
            // 
            this.estadoreparacion.HeaderText = "Estado Reparación";
            this.estadoreparacion.Name = "estadoreparacion";
            this.estadoreparacion.Visible = false;
            // 
            // frmGestionGarantia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 549);
            this.Controls.Add(this.buttonImprimir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.comboBoxBuscar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textFiltro);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.dataGridReparacion);
            this.Name = "frmGestionGarantia";
            this.Text = "Gestión de Garantias";
            this.Load += new System.EventHandler(this.frmGestionGarantia_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReparacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonImprimir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxTotalImporte;
        private System.Windows.Forms.TextBox textBoxTotalOt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.TextBox textFiltro;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.DataGridView dataGridReparacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idgarantia;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoreparacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreRazonsocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn costogarantia;
        private System.Windows.Forms.DataGridViewTextBoxColumn idvehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoreparacion;

    }
}