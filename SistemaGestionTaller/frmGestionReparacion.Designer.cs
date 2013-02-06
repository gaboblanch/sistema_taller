namespace SistemaGestionTaller
{
    partial class frmGestionReparacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridReparacion = new System.Windows.Forms.DataGridView();
            this.idreparacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoreparacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadovisual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreRazonsocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idvehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxTotalSaldo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxTotalImporte = new System.Windows.Forms.TextBox();
            this.textBoxTotalOt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonImprimir = new System.Windows.Forms.Button();
            this.checkBoxFiltroOT = new System.Windows.Forms.CheckBox();
            this.buttonGarantia = new System.Windows.Forms.Button();
            this.buttonActualizar = new System.Windows.Forms.Button();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.checkBoxTodas = new System.Windows.Forms.CheckBox();
            this.textBoxReparacion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDominio = new System.Windows.Forms.TextBox();
            this.textFiltro = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxMarca = new System.Windows.Forms.TextBox();
            this.textBoxModelo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReparacion)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            this.idreparacion,
            this.fecha,
            this.codigoreparacion,
            this.estadovisual,
            this.nombreRazonsocial,
            this.descripcion,
            this.importe,
            this.saldo,
            this.idvehiculo,
            this.vehiculo,
            this.accion,
            this.estado});
            this.dataGridReparacion.Location = new System.Drawing.Point(12, 99);
            this.dataGridReparacion.MultiSelect = false;
            this.dataGridReparacion.Name = "dataGridReparacion";
            this.dataGridReparacion.RowHeadersVisible = false;
            this.dataGridReparacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridReparacion.Size = new System.Drawing.Size(1162, 368);
            this.dataGridReparacion.TabIndex = 0;
            this.dataGridReparacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridReparacion_CellClick);
            this.dataGridReparacion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridReparacion_CellDoubleClick);
            // 
            // idreparacion
            // 
            this.idreparacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.idreparacion.HeaderText = "ID";
            this.idreparacion.Name = "idreparacion";
            this.idreparacion.ReadOnly = true;
            this.idreparacion.Visible = false;
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
            // estadovisual
            // 
            this.estadovisual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estadovisual.DefaultCellStyle = dataGridViewCellStyle1;
            this.estadovisual.HeaderText = "Estado";
            this.estadovisual.Name = "estadovisual";
            this.estadovisual.Width = 65;
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
            // saldo
            // 
            this.saldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.saldo.DefaultCellStyle = dataGridViewCellStyle3;
            this.saldo.HeaderText = "Saldo";
            this.saldo.Name = "saldo";
            this.saldo.Width = 59;
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
            // accion
            // 
            this.accion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.accion.HeaderText = "ACCIÓN";
            this.accion.Name = "accion";
            this.accion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.accion.Text = "";
            this.accion.Width = 53;
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePickerInicio);
            this.groupBox1.Controls.Add(this.dateTimePickerFin);
            this.groupBox1.Location = new System.Drawing.Point(12, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 34);
            this.groupBox1.TabIndex = 48;
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
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.textBoxTotalSaldo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBoxTotalImporte);
            this.groupBox2.Controls.Add(this.textBoxTotalOt);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 473);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 67);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            // 
            // textBoxTotalSaldo
            // 
            this.textBoxTotalSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotalSaldo.Location = new System.Drawing.Point(344, 40);
            this.textBoxTotalSaldo.Name = "textBoxTotalSaldo";
            this.textBoxTotalSaldo.ReadOnly = true;
            this.textBoxTotalSaldo.Size = new System.Drawing.Size(100, 22);
            this.textBoxTotalSaldo.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(274, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Total Saldo:";
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
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Total Importe:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total de Ordenes de Trabajo:";
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonImprimir.Location = new System.Drawing.Point(950, 510);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.Size = new System.Drawing.Size(75, 23);
            this.buttonImprimir.TabIndex = 53;
            this.buttonImprimir.Text = "Imprimir";
            this.buttonImprimir.UseVisualStyleBackColor = true;
            this.buttonImprimir.Click += new System.EventHandler(this.buttonImprimir_Click);
            // 
            // checkBoxFiltroOT
            // 
            this.checkBoxFiltroOT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxFiltroOT.AutoSize = true;
            this.checkBoxFiltroOT.Location = new System.Drawing.Point(337, 16);
            this.checkBoxFiltroOT.Name = "checkBoxFiltroOT";
            this.checkBoxFiltroOT.Size = new System.Drawing.Size(79, 17);
            this.checkBoxFiltroOT.TabIndex = 54;
            this.checkBoxFiltroOT.Text = "Facturadas";
            this.checkBoxFiltroOT.UseVisualStyleBackColor = true;
            this.checkBoxFiltroOT.CheckedChanged += new System.EventHandler(this.checkBoxFiltroOT_CheckedChanged);
            // 
            // buttonGarantia
            // 
            this.buttonGarantia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGarantia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGarantia.Location = new System.Drawing.Point(854, 510);
            this.buttonGarantia.Name = "buttonGarantia";
            this.buttonGarantia.Size = new System.Drawing.Size(75, 23);
            this.buttonGarantia.TabIndex = 55;
            this.buttonGarantia.Text = "Garantía";
            this.buttonGarantia.UseVisualStyleBackColor = true;
            this.buttonGarantia.Click += new System.EventHandler(this.buttonGarantia_Click);
            // 
            // buttonActualizar
            // 
            this.buttonActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonActualizar.BackgroundImage = global::SistemaGestionTaller.Properties.Resources.actualizar_restaure_agt_icono_7628_16;
            this.buttonActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonActualizar.Location = new System.Drawing.Point(1144, 8);
            this.buttonActualizar.Name = "buttonActualizar";
            this.buttonActualizar.Size = new System.Drawing.Size(30, 23);
            this.buttonActualizar.TabIndex = 56;
            this.buttonActualizar.UseVisualStyleBackColor = true;
            this.buttonActualizar.Click += new System.EventHandler(this.buttonActualizar_Click);
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAgregar.Image = global::SistemaGestionTaller.Properties.Resources.agregar;
            this.buttonAgregar.Location = new System.Drawing.Point(1134, 501);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(40, 40);
            this.buttonAgregar.TabIndex = 42;
            this.buttonAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEliminar.Image = global::SistemaGestionTaller.Properties.Resources.eliminar;
            this.buttonEliminar.Location = new System.Drawing.Point(1042, 501);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(40, 40);
            this.buttonEliminar.TabIndex = 43;
            this.buttonEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditar.Image = global::SistemaGestionTaller.Properties.Resources.editar;
            this.buttonEditar.Location = new System.Drawing.Point(1088, 501);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(40, 40);
            this.buttonEditar.TabIndex = 44;
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // checkBoxTodas
            // 
            this.checkBoxTodas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxTodas.AutoSize = true;
            this.checkBoxTodas.Location = new System.Drawing.Point(445, 15);
            this.checkBoxTodas.Name = "checkBoxTodas";
            this.checkBoxTodas.Size = new System.Drawing.Size(107, 17);
            this.checkBoxTodas.TabIndex = 57;
            this.checkBoxTodas.Text = "Buscar en Todas";
            this.checkBoxTodas.UseVisualStyleBackColor = true;
            // 
            // textBoxReparacion
            // 
            this.textBoxReparacion.Location = new System.Drawing.Point(942, 40);
            this.textBoxReparacion.Name = "textBoxReparacion";
            this.textBoxReparacion.Size = new System.Drawing.Size(130, 20);
            this.textBoxReparacion.TabIndex = 72;
            this.textBoxReparacion.TextChanged += new System.EventHandler(this.textBoxReparacion_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(848, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 71;
            this.label8.Text = "Nro. Reparación:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(848, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 70;
            this.label7.Text = "Nro. Factura:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(587, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 68;
            this.label6.Text = "Dominio vehículo:";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(704, 11);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(114, 20);
            this.textBoxNombre.TabIndex = 67;
            this.textBoxNombre.TextChanged += new System.EventHandler(this.textBoxNombre_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(587, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 66;
            this.label5.Text = "Nombre/Razón Social:";
            // 
            // textBoxDominio
            // 
            this.textBoxDominio.Location = new System.Drawing.Point(704, 40);
            this.textBoxDominio.Name = "textBoxDominio";
            this.textBoxDominio.Size = new System.Drawing.Size(114, 20);
            this.textBoxDominio.TabIndex = 69;
            this.textBoxDominio.TextChanged += new System.EventHandler(this.textBoxDominio_TextChanged);
            // 
            // textFiltro
            // 
            this.textFiltro.Location = new System.Drawing.Point(942, 11);
            this.textFiltro.Name = "textFiltro";
            this.textFiltro.Size = new System.Drawing.Size(130, 20);
            this.textFiltro.TabIndex = 73;
            this.textFiltro.TextChanged += new System.EventHandler(this.textFiltro_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(587, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 74;
            this.label10.Text = "Marca:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(848, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 75;
            this.label11.Text = "Modelo:";
            // 
            // textBoxMarca
            // 
            this.textBoxMarca.Location = new System.Drawing.Point(704, 69);
            this.textBoxMarca.Name = "textBoxMarca";
            this.textBoxMarca.Size = new System.Drawing.Size(114, 20);
            this.textBoxMarca.TabIndex = 76;
            this.textBoxMarca.TextChanged += new System.EventHandler(this.textBoxMarca_TextChanged);
            // 
            // textBoxModelo
            // 
            this.textBoxModelo.Location = new System.Drawing.Point(942, 69);
            this.textBoxModelo.Name = "textBoxModelo";
            this.textBoxModelo.Size = new System.Drawing.Size(130, 20);
            this.textBoxModelo.TabIndex = 77;
            this.textBoxModelo.TextChanged += new System.EventHandler(this.textBoxModelo_TextChanged);
            // 
            // frmGestionReparacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 549);
            this.Controls.Add(this.textBoxModelo);
            this.Controls.Add(this.textBoxMarca);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textFiltro);
            this.Controls.Add(this.textBoxReparacion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxDominio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBoxTodas);
            this.Controls.Add(this.buttonActualizar);
            this.Controls.Add(this.buttonGarantia);
            this.Controls.Add(this.checkBoxFiltroOT);
            this.Controls.Add(this.buttonImprimir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.dataGridReparacion);
            this.Name = "frmGestionReparacion";
            this.Text = "Gestión de Reparaciones";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGestionReparacion_FormClosed);
            this.Load += new System.EventHandler(this.frmGestionReparacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReparacion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridReparacion;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTotalImporte;
        private System.Windows.Forms.TextBox textBoxTotalOt;
        private System.Windows.Forms.Button buttonImprimir;
        private System.Windows.Forms.CheckBox checkBoxFiltroOT;
        private System.Windows.Forms.Button buttonGarantia;
        private System.Windows.Forms.DataGridViewTextBoxColumn idreparacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoreparacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadovisual;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreRazonsocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idvehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehiculo;
        private System.Windows.Forms.DataGridViewButtonColumn accion;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.Button buttonActualizar;
        private System.Windows.Forms.CheckBox checkBoxTodas;
        private System.Windows.Forms.TextBox textBoxTotalSaldo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxReparacion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDominio;
        private System.Windows.Forms.TextBox textFiltro;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxMarca;
        private System.Windows.Forms.TextBox textBoxModelo;
      }
}