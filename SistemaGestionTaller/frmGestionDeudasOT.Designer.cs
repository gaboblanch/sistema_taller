namespace SistemaGestionTaller
{
    partial class frmGestionDeudasOT
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
            this.buttonActualizar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxTotalImporte = new System.Windows.Forms.TextBox();
            this.textBoxTotalOt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textFiltro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReparacion)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonActualizar
            // 
            this.buttonActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonActualizar.BackgroundImage = global::SistemaGestionTaller.Properties.Resources.actualizar_restaure_agt_icono_7628_16;
            this.buttonActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonActualizar.Location = new System.Drawing.Point(1144, 8);
            this.buttonActualizar.Name = "buttonActualizar";
            this.buttonActualizar.Size = new System.Drawing.Size(30, 23);
            this.buttonActualizar.TabIndex = 65;
            this.buttonActualizar.UseVisualStyleBackColor = true;
            this.buttonActualizar.Click += new System.EventHandler(this.buttonActualizar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.textBoxTotalImporte);
            this.groupBox2.Controls.Add(this.textBoxTotalOt);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 473);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 67);
            this.groupBox2.TabIndex = 64;
            this.groupBox2.TabStop = false;
            // 
            // textBoxTotalImporte
            // 
            this.textBoxTotalImporte.Location = new System.Drawing.Point(155, 40);
            this.textBoxTotalImporte.Name = "textBoxTotalImporte";
            this.textBoxTotalImporte.ReadOnly = true;
            this.textBoxTotalImporte.Size = new System.Drawing.Size(100, 20);
            this.textBoxTotalImporte.TabIndex = 3;
            this.textBoxTotalImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxTotalOt
            // 
            this.textBoxTotalOt.Location = new System.Drawing.Point(155, 11);
            this.textBoxTotalOt.Name = "textBoxTotalOt";
            this.textBoxTotalOt.ReadOnly = true;
            this.textBoxTotalOt.Size = new System.Drawing.Size(100, 20);
            this.textBoxTotalOt.TabIndex = 2;
            this.textBoxTotalOt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Total Saldo:";
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
            // textFiltro
            // 
            this.textFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textFiltro.Location = new System.Drawing.Point(141, 10);
            this.textFiltro.Name = "textFiltro";
            this.textFiltro.Size = new System.Drawing.Size(132, 20);
            this.textFiltro.TabIndex = 61;
            this.textFiltro.TextChanged += new System.EventHandler(this.textFiltro_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 66;
            this.label2.Text = "Nombre/Razón Social:";
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
            this.dataGridReparacion.Location = new System.Drawing.Point(12, 39);
            this.dataGridReparacion.MultiSelect = false;
            this.dataGridReparacion.Name = "dataGridReparacion";
            this.dataGridReparacion.RowHeadersVisible = false;
            this.dataGridReparacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridReparacion.Size = new System.Drawing.Size(1162, 428);
            this.dataGridReparacion.TabIndex = 67;
            this.dataGridReparacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridReparacion_CellClick);
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
            // frmGestionDeudasOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 549);
            this.Controls.Add(this.dataGridReparacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonActualizar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textFiltro);
            this.Name = "frmGestionDeudasOT";
            this.Text = "Gestión de OT Impagas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGestionDeudasOT_FormClosed);
            this.Load += new System.EventHandler(this.frmGestionDeudasOT_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReparacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonActualizar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxTotalImporte;
        private System.Windows.Forms.TextBox textBoxTotalOt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textFiltro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridReparacion;
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
    }
}