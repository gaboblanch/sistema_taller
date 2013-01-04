namespace SistemaGestionTaller
{
    partial class frmGestionProveedor
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
            this.textFiltro = new System.Windows.Forms.TextBox();
            this.dataGridProveedor = new System.Windows.Forms.DataGridView();
            this.idproveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreRazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paginaweb = new System.Windows.Forms.DataGridViewLinkColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.banconombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titularcuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentatipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numerocuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonNuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(780, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Nombre / Razón Social:";
            // 
            // textFiltro
            // 
            this.textFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textFiltro.Location = new System.Drawing.Point(903, 12);
            this.textFiltro.Name = "textFiltro";
            this.textFiltro.Size = new System.Drawing.Size(131, 20);
            this.textFiltro.TabIndex = 30;
            this.textFiltro.TextChanged += new System.EventHandler(this.textFiltro_TextChanged);
            // 
            // dataGridProveedor
            // 
            this.dataGridProveedor.AllowUserToAddRows = false;
            this.dataGridProveedor.AllowUserToDeleteRows = false;
            this.dataGridProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idproveedor,
            this.cuit,
            this.nombreRazonSocial,
            this.email,
            this.paginaweb,
            this.telefono,
            this.banconombre,
            this.titularcuenta,
            this.cuentatipo,
            this.numerocuenta,
            this.direccion,
            this.cp,
            this.localidad,
            this.provincia,
            this.observaciones});
            this.dataGridProveedor.Location = new System.Drawing.Point(12, 40);
            this.dataGridProveedor.MultiSelect = false;
            this.dataGridProveedor.Name = "dataGridProveedor";
            this.dataGridProveedor.ReadOnly = true;
            this.dataGridProveedor.RowHeadersVisible = false;
            this.dataGridProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridProveedor.Size = new System.Drawing.Size(1022, 388);
            this.dataGridProveedor.TabIndex = 25;
            this.dataGridProveedor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridProveedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProveedor_CellDoubleClick);
            // 
            // idproveedor
            // 
            this.idproveedor.HeaderText = "ID";
            this.idproveedor.Name = "idproveedor";
            this.idproveedor.ReadOnly = true;
            this.idproveedor.Visible = false;
            // 
            // cuit
            // 
            this.cuit.HeaderText = "CUIT";
            this.cuit.Name = "cuit";
            this.cuit.ReadOnly = true;
            // 
            // nombreRazonSocial
            // 
            this.nombreRazonSocial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nombreRazonSocial.HeaderText = "Nombre / Razon Social";
            this.nombreRazonSocial.Name = "nombreRazonSocial";
            this.nombreRazonSocial.ReadOnly = true;
            this.nombreRazonSocial.Width = 105;
            // 
            // email
            // 
            this.email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.email.HeaderText = "E-mail";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 60;
            // 
            // paginaweb
            // 
            this.paginaweb.HeaderText = "Web";
            this.paginaweb.Name = "paginaweb";
            this.paginaweb.ReadOnly = true;
            this.paginaweb.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.paginaweb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // telefono
            // 
            this.telefono.HeaderText = "Telefono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            // 
            // banconombre
            // 
            this.banconombre.HeaderText = "Banco";
            this.banconombre.Name = "banconombre";
            this.banconombre.ReadOnly = true;
            // 
            // titularcuenta
            // 
            this.titularcuenta.HeaderText = "Titular";
            this.titularcuenta.Name = "titularcuenta";
            this.titularcuenta.ReadOnly = true;
            // 
            // cuentatipo
            // 
            this.cuentatipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cuentatipo.HeaderText = "Tipo Cuenta";
            this.cuentatipo.Name = "cuentatipo";
            this.cuentatipo.ReadOnly = true;
            this.cuentatipo.Width = 83;
            // 
            // numerocuenta
            // 
            this.numerocuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.numerocuenta.HeaderText = "N° Cuenta";
            this.numerocuenta.Name = "numerocuenta";
            this.numerocuenta.ReadOnly = true;
            this.numerocuenta.Width = 75;
            // 
            // direccion
            // 
            this.direccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.direccion.HeaderText = "Dirección";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            this.direccion.Width = 77;
            // 
            // cp
            // 
            this.cp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cp.HeaderText = "Cód. Postal";
            this.cp.Name = "cp";
            this.cp.ReadOnly = true;
            this.cp.Width = 79;
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
            // observaciones
            // 
            this.observaciones.HeaderText = "Observaciones";
            this.observaciones.Name = "observaciones";
            this.observaciones.ReadOnly = true;
            this.observaciones.Width = 150;
            // 
            // buttonEditar
            // 
            this.buttonEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditar.Image = global::SistemaGestionTaller.Properties.Resources.modificar_comp;
            this.buttonEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditar.Location = new System.Drawing.Point(869, 434);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(80, 40);
            this.buttonEditar.TabIndex = 28;
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
            this.buttonEliminar.Location = new System.Drawing.Point(783, 434);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(80, 40);
            this.buttonEliminar.TabIndex = 27;
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
            this.buttonNuevo.Location = new System.Drawing.Point(955, 434);
            this.buttonNuevo.Name = "buttonNuevo";
            this.buttonNuevo.Size = new System.Drawing.Size(80, 40);
            this.buttonNuevo.TabIndex = 26;
            this.buttonNuevo.Text = "Nuevo";
            this.buttonNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonNuevo.UseVisualStyleBackColor = true;
            this.buttonNuevo.Click += new System.EventHandler(this.buttonNuevo_Click);
            // 
            // frmGestionProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 484);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textFiltro);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonNuevo);
            this.Controls.Add(this.dataGridProveedor);
            this.Name = "frmGestionProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestión de Proveedores";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGestionProveedor_FormClosed);
            this.Load += new System.EventHandler(this.frmGestionProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProveedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textFiltro;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonNuevo;
        private System.Windows.Forms.DataGridView dataGridProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idproveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreRazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewLinkColumn paginaweb;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn banconombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn titularcuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentatipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn numerocuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cp;
        private System.Windows.Forms.DataGridViewTextBoxColumn localidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn provincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn observaciones;
    }
}