namespace SistemaGestionTaller
{
    partial class frmGestionGlobal
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.dataGridIngreso = new System.Windows.Forms.DataGridView();
            this.idingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcioningreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textTarjetaIngreso = new System.Windows.Forms.TextBox();
            this.textGlobalIngreso = new System.Windows.Forms.TextBox();
            this.textChequeIngreso = new System.Windows.Forms.TextBox();
            this.textBancoIngreso = new System.Windows.Forms.TextBox();
            this.textEfectivoIngreso = new System.Windows.Forms.TextBox();
            this.buttonAgregarIngreso = new System.Windows.Forms.Button();
            this.buttonEliminarIngreso = new System.Windows.Forms.Button();
            this.buttonEditarIngreso = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textGlobalEgreso = new System.Windows.Forms.TextBox();
            this.textChequeEgreso = new System.Windows.Forms.TextBox();
            this.textBancoEgreso = new System.Windows.Forms.TextBox();
            this.textEfectivoEgreso = new System.Windows.Forms.TextBox();
            this.buttonAgregarEgreso = new System.Windows.Forms.Button();
            this.buttonEliminarEgreso = new System.Windows.Forms.Button();
            this.dataGridEgreso = new System.Windows.Forms.DataGridView();
            this.idegreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoegreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaegreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionegreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeegreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonEditarEgreso = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textTarjetaInicio = new System.Windows.Forms.TextBox();
            this.textGlobalInicio = new System.Windows.Forms.TextBox();
            this.textChequeInicio = new System.Windows.Forms.TextBox();
            this.textBancoInicio = new System.Windows.Forms.TextBox();
            this.textEfectivoInicio = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textTarjetaTotal = new System.Windows.Forms.TextBox();
            this.textGlobalTotal = new System.Windows.Forms.TextBox();
            this.textChequeTotal = new System.Windows.Forms.TextBox();
            this.textBancoTotal = new System.Windows.Forms.TextBox();
            this.textEfectivoTotal = new System.Windows.Forms.TextBox();
            this.buttonTerminar = new System.Windows.Forms.Button();
            this.buttonActualizar = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textTotalTotal = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIngreso)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEgreso)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePickerInicio);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 34);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha:";
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
            // dataGridIngreso
            // 
            this.dataGridIngreso.AllowUserToAddRows = false;
            this.dataGridIngreso.AllowUserToDeleteRows = false;
            this.dataGridIngreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIngreso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idingreso,
            this.tipoingreso,
            this.fechaingreso,
            this.descripcioningreso,
            this.importeingreso});
            this.dataGridIngreso.Location = new System.Drawing.Point(19, 41);
            this.dataGridIngreso.Name = "dataGridIngreso";
            this.dataGridIngreso.ReadOnly = true;
            this.dataGridIngreso.RowHeadersVisible = false;
            this.dataGridIngreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridIngreso.Size = new System.Drawing.Size(433, 393);
            this.dataGridIngreso.TabIndex = 58;
            // 
            // idingreso
            // 
            this.idingreso.HeaderText = "IdIngreso";
            this.idingreso.Name = "idingreso";
            this.idingreso.ReadOnly = true;
            this.idingreso.Visible = false;
            // 
            // tipoingreso
            // 
            this.tipoingreso.HeaderText = "Tipo";
            this.tipoingreso.Name = "tipoingreso";
            this.tipoingreso.ReadOnly = true;
            this.tipoingreso.Visible = false;
            // 
            // fechaingreso
            // 
            this.fechaingreso.HeaderText = "Fecha";
            this.fechaingreso.Name = "fechaingreso";
            this.fechaingreso.ReadOnly = true;
            // 
            // descripcioningreso
            // 
            this.descripcioningreso.HeaderText = "Descripción";
            this.descripcioningreso.Name = "descripcioningreso";
            this.descripcioningreso.ReadOnly = true;
            this.descripcioningreso.Width = 200;
            // 
            // importeingreso
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.importeingreso.DefaultCellStyle = dataGridViewCellStyle1;
            this.importeingreso.HeaderText = "Importe";
            this.importeingreso.Name = "importeingreso";
            this.importeingreso.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textTarjetaIngreso);
            this.groupBox2.Controls.Add(this.textGlobalIngreso);
            this.groupBox2.Controls.Add(this.textChequeIngreso);
            this.groupBox2.Controls.Add(this.textBancoIngreso);
            this.groupBox2.Controls.Add(this.textEfectivoIngreso);
            this.groupBox2.Controls.Add(this.dataGridIngreso);
            this.groupBox2.Controls.Add(this.buttonAgregarIngreso);
            this.groupBox2.Controls.Add(this.buttonEliminarIngreso);
            this.groupBox2.Controls.Add(this.buttonEditarIngreso);
            this.groupBox2.Location = new System.Drawing.Point(12, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 484);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ingresos";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(394, 443);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 74;
            this.label8.Text = "Tarjetas";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(301, 443);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 73;
            this.label9.Text = "Global";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(115, 443);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 72;
            this.label10.Text = "Banco";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(208, 443);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 71;
            this.label11.Text = "Cheques";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 443);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 70;
            this.label12.Text = "Efectivo";
            // 
            // textTarjetaIngreso
            // 
            this.textTarjetaIngreso.Location = new System.Drawing.Point(394, 459);
            this.textTarjetaIngreso.Name = "textTarjetaIngreso";
            this.textTarjetaIngreso.ReadOnly = true;
            this.textTarjetaIngreso.Size = new System.Drawing.Size(58, 20);
            this.textTarjetaIngreso.TabIndex = 69;
            this.textTarjetaIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textGlobalIngreso
            // 
            this.textGlobalIngreso.Location = new System.Drawing.Point(301, 459);
            this.textGlobalIngreso.Name = "textGlobalIngreso";
            this.textGlobalIngreso.ReadOnly = true;
            this.textGlobalIngreso.Size = new System.Drawing.Size(58, 20);
            this.textGlobalIngreso.TabIndex = 68;
            this.textGlobalIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textChequeIngreso
            // 
            this.textChequeIngreso.Location = new System.Drawing.Point(208, 459);
            this.textChequeIngreso.Name = "textChequeIngreso";
            this.textChequeIngreso.ReadOnly = true;
            this.textChequeIngreso.Size = new System.Drawing.Size(58, 20);
            this.textChequeIngreso.TabIndex = 67;
            this.textChequeIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBancoIngreso
            // 
            this.textBancoIngreso.Location = new System.Drawing.Point(115, 459);
            this.textBancoIngreso.Name = "textBancoIngreso";
            this.textBancoIngreso.ReadOnly = true;
            this.textBancoIngreso.Size = new System.Drawing.Size(58, 20);
            this.textBancoIngreso.TabIndex = 66;
            this.textBancoIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textEfectivoIngreso
            // 
            this.textEfectivoIngreso.Location = new System.Drawing.Point(19, 459);
            this.textEfectivoIngreso.Name = "textEfectivoIngreso";
            this.textEfectivoIngreso.ReadOnly = true;
            this.textEfectivoIngreso.Size = new System.Drawing.Size(58, 20);
            this.textEfectivoIngreso.TabIndex = 65;
            this.textEfectivoIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonAgregarIngreso
            // 
            this.buttonAgregarIngreso.BackgroundImage = global::SistemaGestionTaller.Properties.Resources.agregar;
            this.buttonAgregarIngreso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAgregarIngreso.Location = new System.Drawing.Point(427, 10);
            this.buttonAgregarIngreso.Name = "buttonAgregarIngreso";
            this.buttonAgregarIngreso.Size = new System.Drawing.Size(25, 25);
            this.buttonAgregarIngreso.TabIndex = 62;
            this.buttonAgregarIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAgregarIngreso.UseVisualStyleBackColor = true;
            this.buttonAgregarIngreso.Click += new System.EventHandler(this.buttonAgregarIngreso_Click);
            // 
            // buttonEliminarIngreso
            // 
            this.buttonEliminarIngreso.BackgroundImage = global::SistemaGestionTaller.Properties.Resources.eliminar;
            this.buttonEliminarIngreso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonEliminarIngreso.Location = new System.Drawing.Point(365, 10);
            this.buttonEliminarIngreso.Name = "buttonEliminarIngreso";
            this.buttonEliminarIngreso.Size = new System.Drawing.Size(25, 25);
            this.buttonEliminarIngreso.TabIndex = 63;
            this.buttonEliminarIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminarIngreso.UseVisualStyleBackColor = true;
            this.buttonEliminarIngreso.Click += new System.EventHandler(this.buttonEliminarIngreso_Click);
            // 
            // buttonEditarIngreso
            // 
            this.buttonEditarIngreso.BackgroundImage = global::SistemaGestionTaller.Properties.Resources.editar;
            this.buttonEditarIngreso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonEditarIngreso.Location = new System.Drawing.Point(396, 10);
            this.buttonEditarIngreso.Name = "buttonEditarIngreso";
            this.buttonEditarIngreso.Size = new System.Drawing.Size(25, 25);
            this.buttonEditarIngreso.TabIndex = 64;
            this.buttonEditarIngreso.UseVisualStyleBackColor = true;
            this.buttonEditarIngreso.Click += new System.EventHandler(this.buttonEditarIngreso_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.textGlobalEgreso);
            this.groupBox3.Controls.Add(this.textChequeEgreso);
            this.groupBox3.Controls.Add(this.textBancoEgreso);
            this.groupBox3.Controls.Add(this.textEfectivoEgreso);
            this.groupBox3.Controls.Add(this.buttonAgregarEgreso);
            this.groupBox3.Controls.Add(this.buttonEliminarEgreso);
            this.groupBox3.Controls.Add(this.dataGridEgreso);
            this.groupBox3.Controls.Add(this.buttonEditarEgreso);
            this.groupBox3.Location = new System.Drawing.Point(486, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(468, 484);
            this.groupBox3.TabIndex = 61;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Egresos";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(303, 443);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 83;
            this.label13.Text = "Global";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(117, 443);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 82;
            this.label14.Text = "Banco";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(210, 443);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 81;
            this.label15.Text = "Cheques";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 443);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 80;
            this.label16.Text = "Efectivo";
            // 
            // textGlobalEgreso
            // 
            this.textGlobalEgreso.Location = new System.Drawing.Point(303, 459);
            this.textGlobalEgreso.Name = "textGlobalEgreso";
            this.textGlobalEgreso.ReadOnly = true;
            this.textGlobalEgreso.Size = new System.Drawing.Size(58, 20);
            this.textGlobalEgreso.TabIndex = 78;
            this.textGlobalEgreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textChequeEgreso
            // 
            this.textChequeEgreso.Location = new System.Drawing.Point(210, 459);
            this.textChequeEgreso.Name = "textChequeEgreso";
            this.textChequeEgreso.ReadOnly = true;
            this.textChequeEgreso.Size = new System.Drawing.Size(58, 20);
            this.textChequeEgreso.TabIndex = 77;
            this.textChequeEgreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBancoEgreso
            // 
            this.textBancoEgreso.Location = new System.Drawing.Point(117, 459);
            this.textBancoEgreso.Name = "textBancoEgreso";
            this.textBancoEgreso.ReadOnly = true;
            this.textBancoEgreso.Size = new System.Drawing.Size(58, 20);
            this.textBancoEgreso.TabIndex = 76;
            this.textBancoEgreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textEfectivoEgreso
            // 
            this.textEfectivoEgreso.Location = new System.Drawing.Point(24, 459);
            this.textEfectivoEgreso.Name = "textEfectivoEgreso";
            this.textEfectivoEgreso.ReadOnly = true;
            this.textEfectivoEgreso.Size = new System.Drawing.Size(58, 20);
            this.textEfectivoEgreso.TabIndex = 75;
            this.textEfectivoEgreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonAgregarEgreso
            // 
            this.buttonAgregarEgreso.BackgroundImage = global::SistemaGestionTaller.Properties.Resources.agregar;
            this.buttonAgregarEgreso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAgregarEgreso.Location = new System.Drawing.Point(432, 10);
            this.buttonAgregarEgreso.Name = "buttonAgregarEgreso";
            this.buttonAgregarEgreso.Size = new System.Drawing.Size(25, 25);
            this.buttonAgregarEgreso.TabIndex = 65;
            this.buttonAgregarEgreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAgregarEgreso.UseVisualStyleBackColor = true;
            this.buttonAgregarEgreso.Click += new System.EventHandler(this.buttonAgregarEgreso_Click);
            // 
            // buttonEliminarEgreso
            // 
            this.buttonEliminarEgreso.BackgroundImage = global::SistemaGestionTaller.Properties.Resources.eliminar;
            this.buttonEliminarEgreso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonEliminarEgreso.Location = new System.Drawing.Point(370, 10);
            this.buttonEliminarEgreso.Name = "buttonEliminarEgreso";
            this.buttonEliminarEgreso.Size = new System.Drawing.Size(25, 25);
            this.buttonEliminarEgreso.TabIndex = 66;
            this.buttonEliminarEgreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminarEgreso.UseVisualStyleBackColor = true;
            this.buttonEliminarEgreso.Click += new System.EventHandler(this.buttonEliminarEgreso_Click);
            // 
            // dataGridEgreso
            // 
            this.dataGridEgreso.AllowUserToAddRows = false;
            this.dataGridEgreso.AllowUserToDeleteRows = false;
            this.dataGridEgreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEgreso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idegreso,
            this.tipoegreso,
            this.fechaegreso,
            this.descripcionegreso,
            this.importeegreso});
            this.dataGridEgreso.Location = new System.Drawing.Point(24, 41);
            this.dataGridEgreso.Name = "dataGridEgreso";
            this.dataGridEgreso.ReadOnly = true;
            this.dataGridEgreso.RowHeadersVisible = false;
            this.dataGridEgreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridEgreso.Size = new System.Drawing.Size(433, 393);
            this.dataGridEgreso.TabIndex = 58;
            //this.dataGridEgreso.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridEgreso_CellContentClick);
            // 
            // idegreso
            // 
            this.idegreso.HeaderText = "IdIngreso";
            this.idegreso.Name = "idegreso";
            this.idegreso.ReadOnly = true;
            this.idegreso.Visible = false;
            // 
            // tipoegreso
            // 
            this.tipoegreso.HeaderText = "Tipo";
            this.tipoegreso.Name = "tipoegreso";
            this.tipoegreso.ReadOnly = true;
            this.tipoegreso.Visible = false;
            // 
            // fechaegreso
            // 
            this.fechaegreso.HeaderText = "Fecha";
            this.fechaegreso.Name = "fechaegreso";
            this.fechaegreso.ReadOnly = true;
            // 
            // descripcionegreso
            // 
            this.descripcionegreso.HeaderText = "Descripción";
            this.descripcionegreso.Name = "descripcionegreso";
            this.descripcionegreso.ReadOnly = true;
            this.descripcionegreso.Width = 200;
            // 
            // importeegreso
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.importeegreso.DefaultCellStyle = dataGridViewCellStyle2;
            this.importeegreso.HeaderText = "Importe";
            this.importeegreso.Name = "importeegreso";
            this.importeegreso.ReadOnly = true;
            // 
            // buttonEditarEgreso
            // 
            this.buttonEditarEgreso.BackgroundImage = global::SistemaGestionTaller.Properties.Resources.editar;
            this.buttonEditarEgreso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonEditarEgreso.Location = new System.Drawing.Point(401, 10);
            this.buttonEditarEgreso.Name = "buttonEditarEgreso";
            this.buttonEditarEgreso.Size = new System.Drawing.Size(25, 25);
            this.buttonEditarEgreso.TabIndex = 67;
            this.buttonEditarEgreso.UseVisualStyleBackColor = true;
            this.buttonEditarEgreso.Click += new System.EventHandler(this.buttonEditarEgreso_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.textTarjetaInicio);
            this.groupBox4.Controls.Add(this.textGlobalInicio);
            this.groupBox4.Controls.Add(this.textChequeInicio);
            this.groupBox4.Controls.Add(this.textBancoInicio);
            this.groupBox4.Controls.Add(this.textEfectivoInicio);
            this.groupBox4.Location = new System.Drawing.Point(322, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(632, 63);
            this.groupBox4.TabIndex = 65;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Inicio de Jornada";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(519, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Tarjetas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(392, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Global";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Banco";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cheques";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Efectivo";
            // 
            // textTarjetaInicio
            // 
            this.textTarjetaInicio.Location = new System.Drawing.Point(522, 33);
            this.textTarjetaInicio.Name = "textTarjetaInicio";
            this.textTarjetaInicio.ReadOnly = true;
            this.textTarjetaInicio.Size = new System.Drawing.Size(100, 20);
            this.textTarjetaInicio.TabIndex = 4;
            this.textTarjetaInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textGlobalInicio
            // 
            this.textGlobalInicio.Location = new System.Drawing.Point(395, 33);
            this.textGlobalInicio.Name = "textGlobalInicio";
            this.textGlobalInicio.ReadOnly = true;
            this.textGlobalInicio.Size = new System.Drawing.Size(100, 20);
            this.textGlobalInicio.TabIndex = 3;
            this.textGlobalInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textChequeInicio
            // 
            this.textChequeInicio.Location = new System.Drawing.Point(268, 33);
            this.textChequeInicio.Name = "textChequeInicio";
            this.textChequeInicio.ReadOnly = true;
            this.textChequeInicio.Size = new System.Drawing.Size(100, 20);
            this.textChequeInicio.TabIndex = 2;
            this.textChequeInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBancoInicio
            // 
            this.textBancoInicio.Location = new System.Drawing.Point(141, 33);
            this.textBancoInicio.Name = "textBancoInicio";
            this.textBancoInicio.ReadOnly = true;
            this.textBancoInicio.Size = new System.Drawing.Size(100, 20);
            this.textBancoInicio.TabIndex = 1;
            this.textBancoInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textEfectivoInicio
            // 
            this.textEfectivoInicio.Location = new System.Drawing.Point(14, 33);
            this.textEfectivoInicio.Name = "textEfectivoInicio";
            this.textEfectivoInicio.ReadOnly = true;
            this.textEfectivoInicio.Size = new System.Drawing.Size(100, 20);
            this.textEfectivoInicio.TabIndex = 0;
            this.textEfectivoInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.textTarjetaTotal);
            this.groupBox5.Controls.Add(this.textGlobalTotal);
            this.groupBox5.Controls.Add(this.textChequeTotal);
            this.groupBox5.Controls.Add(this.textBancoTotal);
            this.groupBox5.Controls.Add(this.textEfectivoTotal);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 566);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(632, 63);
            this.groupBox5.TabIndex = 66;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Totales";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tarjetas";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(392, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 13);
            this.label17.TabIndex = 8;
            this.label17.Text = "Global";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(138, 17);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 13);
            this.label18.TabIndex = 7;
            this.label18.Text = "Banco";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(265, 17);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 13);
            this.label19.TabIndex = 6;
            this.label19.Text = "Cheques";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(11, 17);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 13);
            this.label20.TabIndex = 5;
            this.label20.Text = "Efectivo";
            // 
            // textTarjetaTotal
            // 
            this.textTarjetaTotal.Location = new System.Drawing.Point(522, 33);
            this.textTarjetaTotal.Name = "textTarjetaTotal";
            this.textTarjetaTotal.ReadOnly = true;
            this.textTarjetaTotal.Size = new System.Drawing.Size(100, 20);
            this.textTarjetaTotal.TabIndex = 4;
            this.textTarjetaTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textGlobalTotal
            // 
            this.textGlobalTotal.Location = new System.Drawing.Point(395, 33);
            this.textGlobalTotal.Name = "textGlobalTotal";
            this.textGlobalTotal.ReadOnly = true;
            this.textGlobalTotal.Size = new System.Drawing.Size(100, 20);
            this.textGlobalTotal.TabIndex = 3;
            this.textGlobalTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textChequeTotal
            // 
            this.textChequeTotal.Location = new System.Drawing.Point(268, 33);
            this.textChequeTotal.Name = "textChequeTotal";
            this.textChequeTotal.ReadOnly = true;
            this.textChequeTotal.Size = new System.Drawing.Size(100, 20);
            this.textChequeTotal.TabIndex = 2;
            this.textChequeTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBancoTotal
            // 
            this.textBancoTotal.Location = new System.Drawing.Point(141, 33);
            this.textBancoTotal.Name = "textBancoTotal";
            this.textBancoTotal.ReadOnly = true;
            this.textBancoTotal.Size = new System.Drawing.Size(100, 20);
            this.textBancoTotal.TabIndex = 1;
            this.textBancoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textEfectivoTotal
            // 
            this.textEfectivoTotal.Location = new System.Drawing.Point(14, 33);
            this.textEfectivoTotal.Name = "textEfectivoTotal";
            this.textEfectivoTotal.ReadOnly = true;
            this.textEfectivoTotal.Size = new System.Drawing.Size(100, 20);
            this.textEfectivoTotal.TabIndex = 0;
            this.textEfectivoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonTerminar
            // 
            this.buttonTerminar.Location = new System.Drawing.Point(836, 583);
            this.buttonTerminar.Name = "buttonTerminar";
            this.buttonTerminar.Size = new System.Drawing.Size(118, 39);
            this.buttonTerminar.TabIndex = 67;
            this.buttonTerminar.Text = "Terminar Jornada";
            this.buttonTerminar.UseVisualStyleBackColor = true;
            this.buttonTerminar.Click += new System.EventHandler(this.buttonTerminar_Click);
            // 
            // buttonActualizar
            // 
            this.buttonActualizar.BackgroundImage = global::SistemaGestionTaller.Properties.Resources.actualizar_restaure_agt_icono_7628_16;
            this.buttonActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonActualizar.Location = new System.Drawing.Point(223, 29);
            this.buttonActualizar.Name = "buttonActualizar";
            this.buttonActualizar.Size = new System.Drawing.Size(34, 36);
            this.buttonActualizar.TabIndex = 68;
            this.buttonActualizar.UseVisualStyleBackColor = true;
            this.buttonActualizar.Click += new System.EventHandler(this.buttonActualizar_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textTotalTotal);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(653, 566);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(164, 63);
            this.groupBox6.TabIndex = 69;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "TOTAL";
            // 
            // textTotalTotal
            // 
            this.textTotalTotal.Location = new System.Drawing.Point(34, 27);
            this.textTotalTotal.Name = "textTotalTotal";
            this.textTotalTotal.ReadOnly = true;
            this.textTotalTotal.Size = new System.Drawing.Size(100, 21);
            this.textTotalTotal.TabIndex = 0;
            // 
            // frmGestionGlobal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 641);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.buttonActualizar);
            this.Controls.Add(this.buttonTerminar);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmGestionGlobal";
            this.Text = "Gestión Caja Diaria";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGestionGlobal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGestionGlobal_FormClosed);
            this.Load += new System.EventHandler(this.frmGestionGlobal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIngreso)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEgreso)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.DataGridView dataGridIngreso;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridEgreso;
        private System.Windows.Forms.Button buttonAgregarIngreso;
        private System.Windows.Forms.Button buttonEliminarIngreso;
        private System.Windows.Forms.Button buttonEditarIngreso;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textTarjetaInicio;
        private System.Windows.Forms.TextBox textGlobalInicio;
        private System.Windows.Forms.TextBox textChequeInicio;
        private System.Windows.Forms.TextBox textBancoInicio;
        private System.Windows.Forms.TextBox textEfectivoInicio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAgregarEgreso;
        private System.Windows.Forms.Button buttonEliminarEgreso;
        private System.Windows.Forms.Button buttonEditarEgreso;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textTarjetaIngreso;
        private System.Windows.Forms.TextBox textGlobalIngreso;
        private System.Windows.Forms.TextBox textChequeIngreso;
        private System.Windows.Forms.TextBox textBancoIngreso;
        private System.Windows.Forms.TextBox textEfectivoIngreso;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textGlobalEgreso;
        private System.Windows.Forms.TextBox textChequeEgreso;
        private System.Windows.Forms.TextBox textBancoEgreso;
        private System.Windows.Forms.TextBox textEfectivoEgreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn idingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcioningreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn idegreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoegreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaegreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionegreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeegreso;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textTarjetaTotal;
        private System.Windows.Forms.TextBox textGlobalTotal;
        private System.Windows.Forms.TextBox textChequeTotal;
        private System.Windows.Forms.TextBox textBancoTotal;
        private System.Windows.Forms.TextBox textEfectivoTotal;
        private System.Windows.Forms.Button buttonTerminar;
        private System.Windows.Forms.Button buttonActualizar;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textTotalTotal;
    }
}