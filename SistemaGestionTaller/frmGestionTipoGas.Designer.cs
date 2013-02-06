namespace SistemaGestionTaller
{
    partial class frmGestionTipoGas
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
            this.dataGridTipoGas = new System.Windows.Forms.DataGridView();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.idtipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTipoGas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridTipoGas
            // 
            this.dataGridTipoGas.AllowUserToAddRows = false;
            this.dataGridTipoGas.AllowUserToDeleteRows = false;
            this.dataGridTipoGas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTipoGas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtipo,
            this.descripcion});
            this.dataGridTipoGas.Location = new System.Drawing.Point(12, 12);
            this.dataGridTipoGas.Name = "dataGridTipoGas";
            this.dataGridTipoGas.ReadOnly = true;
            this.dataGridTipoGas.RowHeadersVisible = false;
            this.dataGridTipoGas.Size = new System.Drawing.Size(376, 371);
            this.dataGridTipoGas.TabIndex = 1;
            this.dataGridTipoGas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTipoGas_CellClick);
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Image = global::SistemaGestionTaller.Properties.Resources.agregar;
            this.buttonAgregar.Location = new System.Drawing.Point(348, 389);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(40, 40);
            this.buttonAgregar.TabIndex = 4;
            this.buttonAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Image = global::SistemaGestionTaller.Properties.Resources.editar;
            this.buttonEditar.Location = new System.Drawing.Point(302, 389);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(40, 40);
            this.buttonEditar.TabIndex = 5;
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Image = global::SistemaGestionTaller.Properties.Resources.eliminar;
            this.buttonEliminar.Location = new System.Drawing.Point(256, 389);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(40, 40);
            this.buttonEliminar.TabIndex = 6;
            this.buttonEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // idtipo
            // 
            this.idtipo.HeaderText = "Id";
            this.idtipo.Name = "idtipo";
            this.idtipo.ReadOnly = true;
            this.idtipo.Visible = false;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 88;
            // 
            // frmGestionTipoGas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 434);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.dataGridTipoGas);
            this.Name = "frmGestionTipoGas";
            this.Text = "Gestión Tipo de Gas";
            this.Load += new System.EventHandler(this.frmGestionTipoGas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTipoGas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridTipoGas;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
    }
}