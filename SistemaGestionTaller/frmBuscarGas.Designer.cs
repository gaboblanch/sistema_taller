namespace SistemaGestionTaller
{
    partial class frmBuscarGas
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
            this.comboBoxBuscar = new System.Windows.Forms.ComboBox();
            this.dataGridRepuesto = new System.Windows.Forms.DataGridView();
            this.textFiltro = new System.Windows.Forms.TextBox();
            this.idRepuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripciontipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigorepuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionrepuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRepuesto)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxBuscar);
            this.groupBox1.Controls.Add(this.dataGridRepuesto);
            this.groupBox1.Controls.Add(this.textFiltro);
            this.groupBox1.Location = new System.Drawing.Point(7, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 407);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // comboBoxBuscar
            // 
            this.comboBoxBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBuscar.FormattingEnabled = true;
            this.comboBoxBuscar.Items.AddRange(new object[] {
            "Código",
            "Descripción"});
            this.comboBoxBuscar.Location = new System.Drawing.Point(507, 16);
            this.comboBoxBuscar.Name = "comboBoxBuscar";
            this.comboBoxBuscar.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBuscar.TabIndex = 43;
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
            this.cantidad,
            this.codigorepuesto,
            this.marca,
            this.modelo,
            this.descripcionrepuesto,
            this.costo,
            this.precio,
            this.minimo});
            this.dataGridRepuesto.Location = new System.Drawing.Point(6, 43);
            this.dataGridRepuesto.MultiSelect = false;
            this.dataGridRepuesto.Name = "dataGridRepuesto";
            this.dataGridRepuesto.ReadOnly = true;
            this.dataGridRepuesto.RowHeadersVisible = false;
            this.dataGridRepuesto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridRepuesto.Size = new System.Drawing.Size(756, 358);
            this.dataGridRepuesto.TabIndex = 33;
            this.dataGridRepuesto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRepuesto_CellDoubleClick);
            // 
            // textFiltro
            // 
            this.textFiltro.Location = new System.Drawing.Point(634, 17);
            this.textFiltro.Name = "textFiltro";
            this.textFiltro.Size = new System.Drawing.Size(128, 20);
            this.textFiltro.TabIndex = 1;
            this.textFiltro.TextChanged += new System.EventHandler(this.textFiltro_TextChanged);
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
            this.descripciontipo.HeaderText = "Tipo";
            this.descripciontipo.Name = "descripciontipo";
            this.descripciontipo.ReadOnly = true;
            this.descripciontipo.Visible = false;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cantidad Disponible";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // codigorepuesto
            // 
            this.codigorepuesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codigorepuesto.HeaderText = "Código";
            this.codigorepuesto.Name = "codigorepuesto";
            this.codigorepuesto.ReadOnly = true;
            this.codigorepuesto.Width = 65;
            // 
            // marca
            // 
            this.marca.HeaderText = "Marca";
            this.marca.Name = "marca";
            this.marca.ReadOnly = true;
            this.marca.Visible = false;
            // 
            // modelo
            // 
            this.modelo.HeaderText = "Modelo";
            this.modelo.Name = "modelo";
            this.modelo.ReadOnly = true;
            this.modelo.Visible = false;
            this.modelo.Width = 110;
            // 
            // descripcionrepuesto
            // 
            this.descripcionrepuesto.HeaderText = "Descripción";
            this.descripcionrepuesto.Name = "descripcionrepuesto";
            this.descripcionrepuesto.ReadOnly = true;
            this.descripcionrepuesto.Width = 150;
            // 
            // costo
            // 
            this.costo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.costo.DefaultCellStyle = dataGridViewCellStyle1;
            this.costo.HeaderText = "Costo Unitario";
            this.costo.Name = "costo";
            this.costo.ReadOnly = true;
            this.costo.Width = 90;
            // 
            // precio
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.precio.DefaultCellStyle = dataGridViewCellStyle2;
            this.precio.HeaderText = "Precio Unitario";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            this.precio.Width = 60;
            // 
            // minimo
            // 
            this.minimo.HeaderText = "Minimo";
            this.minimo.Name = "minimo";
            this.minimo.ReadOnly = true;
            this.minimo.Visible = false;
            // 
            // frmBuscarGas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 415);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscarGas";
            this.Text = "Buscar Gas";
            this.Load += new System.EventHandler(this.frmBuscarGas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRepuesto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxBuscar;
        private System.Windows.Forms.DataGridView dataGridRepuesto;
        private System.Windows.Forms.TextBox textFiltro;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRepuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripciontipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigorepuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionrepuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn minimo;
    }
}