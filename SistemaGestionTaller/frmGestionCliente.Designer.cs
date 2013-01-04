namespace SistemaGestionTaller
{
    partial class frmGestionCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridCliente = new System.Windows.Forms.DataGridView();
            this.idcliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreRazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deuda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textFiltro = new System.Windows.Forms.TextBox();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonNuevo = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridCliente
            // 
            this.dataGridCliente.AllowUserToAddRows = false;
            this.dataGridCliente.AllowUserToDeleteRows = false;
            this.dataGridCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idcliente,
            this.dni,
            this.nombreRazonSocial,
            this.email,
            this.cuit,
            this.telefono,
            this.direccion,
            this.cp,
            this.localidad,
            this.provincia,
            this.deuda,
            this.observaciones});
            this.dataGridCliente.Location = new System.Drawing.Point(12, 42);
            this.dataGridCliente.MultiSelect = false;
            this.dataGridCliente.Name = "dataGridCliente";
            this.dataGridCliente.ReadOnly = true;
            this.dataGridCliente.RowHeadersVisible = false;
            this.dataGridCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCliente.Size = new System.Drawing.Size(1035, 388);
            this.dataGridCliente.TabIndex = 0;
            this.dataGridCliente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridCliente.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCliente_CellDoubleClick);
            this.dataGridCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridCliente_KeyDown);
            // 
            // idcliente
            // 
            this.idcliente.HeaderText = "ID";
            this.idcliente.Name = "idcliente";
            this.idcliente.ReadOnly = true;
            this.idcliente.Visible = false;
            // 
            // dni
            // 
            this.dni.HeaderText = "DNI";
            this.dni.Name = "dni";
            this.dni.ReadOnly = true;
            // 
            // nombreRazonSocial
            // 
            this.nombreRazonSocial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreRazonSocial.DefaultCellStyle = dataGridViewCellStyle3;
            this.nombreRazonSocial.HeaderText = "Nombre/Razón Social";
            this.nombreRazonSocial.Name = "nombreRazonSocial";
            this.nombreRazonSocial.ReadOnly = true;
            this.nombreRazonSocial.Width = 125;
            // 
            // email
            // 
            this.email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.email.HeaderText = "E-Mail";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 61;
            // 
            // cuit
            // 
            this.cuit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cuit.HeaderText = "CUIT";
            this.cuit.Name = "cuit";
            this.cuit.ReadOnly = true;
            this.cuit.Width = 57;
            // 
            // telefono
            // 
            this.telefono.HeaderText = "Telefono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            // 
            // direccion
            // 
            this.direccion.HeaderText = "Dirección";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            this.direccion.Width = 120;
            // 
            // cp
            // 
            this.cp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cp.HeaderText = "Código Postal";
            this.cp.Name = "cp";
            this.cp.ReadOnly = true;
            this.cp.Width = 89;
            // 
            // localidad
            // 
            this.localidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.localidad.HeaderText = "Localidad";
            this.localidad.Name = "localidad";
            this.localidad.ReadOnly = true;
            this.localidad.Width = 78;
            // 
            // provincia
            // 
            this.provincia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.provincia.HeaderText = "Provincia";
            this.provincia.Name = "provincia";
            this.provincia.ReadOnly = true;
            this.provincia.Width = 76;
            // 
            // deuda
            // 
            this.deuda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.deuda.DefaultCellStyle = dataGridViewCellStyle4;
            this.deuda.HeaderText = "Deuda";
            this.deuda.Name = "deuda";
            this.deuda.ReadOnly = true;
            this.deuda.Width = 64;
            // 
            // observaciones
            // 
            this.observaciones.HeaderText = "Observaciones";
            this.observaciones.Name = "observaciones";
            this.observaciones.ReadOnly = true;
            // 
            // textFiltro
            // 
            this.textFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textFiltro.Location = new System.Drawing.Point(916, 12);
            this.textFiltro.Name = "textFiltro";
            this.textFiltro.Size = new System.Drawing.Size(131, 20);
            this.textFiltro.TabIndex = 23;
            this.textFiltro.TextChanged += new System.EventHandler(this.textFiltro_TextChanged);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditar.Image = global::SistemaGestionTaller.Properties.Resources.modificar_comp;
            this.buttonEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditar.Location = new System.Drawing.Point(882, 436);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(80, 40);
            this.buttonEditar.TabIndex = 21;
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEliminar.Image = global::SistemaGestionTaller.Properties.Resources.eliminar_comp;
            this.buttonEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEliminar.Location = new System.Drawing.Point(796, 436);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(80, 40);
            this.buttonEliminar.TabIndex = 20;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonNuevo
            // 
            this.buttonNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNuevo.Image = global::SistemaGestionTaller.Properties.Resources.agregar_comp;
            this.buttonNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNuevo.Location = new System.Drawing.Point(968, 436);
            this.buttonNuevo.Name = "buttonNuevo";
            this.buttonNuevo.Size = new System.Drawing.Size(80, 40);
            this.buttonNuevo.TabIndex = 19;
            this.buttonNuevo.Text = "Nuevo";
            this.buttonNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonNuevo.UseVisualStyleBackColor = true;
            this.buttonNuevo.Click += new System.EventHandler(this.buttonNuevo_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Nombre/Razón Social",
            "Dominio"});
            this.comboBox1.Location = new System.Drawing.Point(742, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(168, 21);
            this.comboBox1.TabIndex = 25;
            // 
            // frmGestionCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 484);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textFiltro);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonNuevo);
            this.Controls.Add(this.dataGridCliente);
            this.Name = "frmGestionCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestión de Clientes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGestionCliente_FormClosed);
            this.Load += new System.EventHandler(this.frmGestionCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridCliente;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonNuevo;
        private System.Windows.Forms.TextBox textFiltro;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreRazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cp;
        private System.Windows.Forms.DataGridViewTextBoxColumn localidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn provincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn deuda;
        private System.Windows.Forms.DataGridViewTextBoxColumn observaciones;
    }
}