namespace SistemaGestionTaller
{
    partial class frmGestiónRepuesto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textFiltro = new System.Windows.Forms.TextBox();
            this.dataGridRepuesto = new System.Windows.Forms.DataGridView();
            this.idRepuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripciontipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigorepuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionrespuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idproveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonsocialproveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonActualizar = new System.Windows.Forms.Button();
            this.checkBoxFaltantes = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMarca = new System.Windows.Forms.TextBox();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRepuesto)).BeginInit();
            this.SuspendLayout();
            // 
            // textFiltro
            // 
            this.textFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textFiltro.Location = new System.Drawing.Point(821, 12);
            this.textFiltro.Name = "textFiltro";
            this.textFiltro.Size = new System.Drawing.Size(141, 20);
            this.textFiltro.TabIndex = 37;
            this.textFiltro.TextChanged += new System.EventHandler(this.textFiltro_TextChanged);
            // 
            // dataGridRepuesto
            // 
            this.dataGridRepuesto.AllowUserToAddRows = false;
            this.dataGridRepuesto.AllowUserToDeleteRows = false;
            this.dataGridRepuesto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridRepuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRepuesto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idRepuesto,
            this.idtipo,
            this.descripciontipo,
            this.codigorepuesto,
            this.marca,
            this.modelo,
            this.descripcionrespuesto,
            this.costo,
            this.precio,
            this.cantidad,
            this.minimo,
            this.idproveedor,
            this.razonsocialproveedor});
            this.dataGridRepuesto.Location = new System.Drawing.Point(12, 40);
            this.dataGridRepuesto.MultiSelect = false;
            this.dataGridRepuesto.Name = "dataGridRepuesto";
            this.dataGridRepuesto.ReadOnly = true;
            this.dataGridRepuesto.RowHeadersVisible = false;
            this.dataGridRepuesto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridRepuesto.Size = new System.Drawing.Size(986, 388);
            this.dataGridRepuesto.TabIndex = 32;
            this.dataGridRepuesto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRepuesto_CellClick);
            this.dataGridRepuesto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRepuesto_CellDoubleClick);
            // 
            // idRepuesto
            // 
            this.idRepuesto.HeaderText = "ID Repuesto";
            this.idRepuesto.Name = "idRepuesto";
            this.idRepuesto.ReadOnly = true;
            this.idRepuesto.Visible = false;
            // 
            // idtipo
            // 
            this.idtipo.HeaderText = "ID tipo";
            this.idtipo.Name = "idtipo";
            this.idtipo.ReadOnly = true;
            this.idtipo.Visible = false;
            // 
            // descripciontipo
            // 
            this.descripciontipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.descripciontipo.HeaderText = "Tipo";
            this.descripciontipo.Name = "descripciontipo";
            this.descripciontipo.ReadOnly = true;
            this.descripciontipo.Width = 53;
            // 
            // codigorepuesto
            // 
            this.codigorepuesto.HeaderText = "Codigo";
            this.codigorepuesto.Name = "codigorepuesto";
            this.codigorepuesto.ReadOnly = true;
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
            // descripcionrespuesto
            // 
            this.descripcionrespuesto.HeaderText = "Descripción";
            this.descripcionrespuesto.Name = "descripcionrespuesto";
            this.descripcionrespuesto.ReadOnly = true;
            this.descripcionrespuesto.Width = 150;
            // 
            // costo
            // 
            this.costo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.costo.DefaultCellStyle = dataGridViewCellStyle1;
            this.costo.HeaderText = "Costo";
            this.costo.Name = "costo";
            this.costo.ReadOnly = true;
            this.costo.Width = 59;
            // 
            // precio
            // 
            this.precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.precio.DefaultCellStyle = dataGridViewCellStyle2;
            this.precio.HeaderText = "Precio Público";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            // 
            // cantidad
            // 
            this.cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 74;
            // 
            // minimo
            // 
            this.minimo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.minimo.DefaultCellStyle = dataGridViewCellStyle4;
            this.minimo.HeaderText = "Cant. Minima";
            this.minimo.Name = "minimo";
            this.minimo.ReadOnly = true;
            this.minimo.Width = 93;
            // 
            // idproveedor
            // 
            this.idproveedor.HeaderText = "ID proveedor";
            this.idproveedor.Name = "idproveedor";
            this.idproveedor.ReadOnly = true;
            this.idproveedor.Visible = false;
            // 
            // razonsocialproveedor
            // 
            this.razonsocialproveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.razonsocialproveedor.HeaderText = "Proveedor";
            this.razonsocialproveedor.Name = "razonsocialproveedor";
            this.razonsocialproveedor.ReadOnly = true;
            this.razonsocialproveedor.Width = 81;
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEliminar.Image = global::SistemaGestionTaller.Properties.Resources.eliminar;
            this.buttonEliminar.Location = new System.Drawing.Point(913, 434);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(40, 40);
            this.buttonEliminar.TabIndex = 40;
            this.buttonEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditar.Image = global::SistemaGestionTaller.Properties.Resources.editar;
            this.buttonEditar.Location = new System.Drawing.Point(959, 434);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(40, 40);
            this.buttonEditar.TabIndex = 41;
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonActualizar
            // 
            this.buttonActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonActualizar.BackgroundImage = global::SistemaGestionTaller.Properties.Resources.actualizar_restaure_agt_icono_7628_16;
            this.buttonActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonActualizar.Location = new System.Drawing.Point(969, 11);
            this.buttonActualizar.Name = "buttonActualizar";
            this.buttonActualizar.Size = new System.Drawing.Size(30, 23);
            this.buttonActualizar.TabIndex = 57;
            this.buttonActualizar.UseVisualStyleBackColor = true;
            this.buttonActualizar.Click += new System.EventHandler(this.buttonActualizar_Click);
            // 
            // checkBoxFaltantes
            // 
            this.checkBoxFaltantes.AutoSize = true;
            this.checkBoxFaltantes.Location = new System.Drawing.Point(12, 17);
            this.checkBoxFaltantes.Name = "checkBoxFaltantes";
            this.checkBoxFaltantes.Size = new System.Drawing.Size(69, 17);
            this.checkBoxFaltantes.TabIndex = 58;
            this.checkBoxFaltantes.Text = "Faltantes";
            this.checkBoxFaltantes.UseVisualStyleBackColor = true;
            this.checkBoxFaltantes.CheckedChanged += new System.EventHandler(this.checkBoxFaltantes_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(506, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Marca/Modelo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(750, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "Descripción:";
            // 
            // textBoxMarca
            // 
            this.textBoxMarca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMarca.Location = new System.Drawing.Point(590, 12);
            this.textBoxMarca.Name = "textBoxMarca";
            this.textBoxMarca.Size = new System.Drawing.Size(141, 20);
            this.textBoxMarca.TabIndex = 62;
            this.textBoxMarca.TextChanged += new System.EventHandler(this.textBoxMarca_TextChanged);
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCodigo.Location = new System.Drawing.Point(341, 12);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(141, 20);
            this.textBoxCodigo.TabIndex = 63;
            this.textBoxCodigo.TextChanged += new System.EventHandler(this.textBoxCodigo_TextChanged);
            // 
            // frmGestiónRepuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 484);
            this.Controls.Add(this.textBoxCodigo);
            this.Controls.Add(this.textBoxMarca);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxFaltantes);
            this.Controls.Add(this.buttonActualizar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.textFiltro);
            this.Controls.Add(this.dataGridRepuesto);
            this.Name = "frmGestiónRepuesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestión de Repuestos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGestiónRepuesto_FormClosed);
            this.Load += new System.EventHandler(this.frmGestiónRepuesto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRepuesto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textFiltro;
        private System.Windows.Forms.DataGridView dataGridRepuesto;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRepuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripciontipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigorepuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionrespuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn minimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idproveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonsocialproveedor;
        private System.Windows.Forms.Button buttonActualizar;
        private System.Windows.Forms.CheckBox checkBoxFaltantes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMarca;
        private System.Windows.Forms.TextBox textBoxCodigo;

    }
}