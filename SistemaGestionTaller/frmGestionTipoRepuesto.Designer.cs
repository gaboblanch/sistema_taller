namespace SistemaGestionTaller
{
    partial class frmGestionTipoRepuesto
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
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.dataGridTipoRepuesto = new System.Windows.Forms.DataGridView();
            this.idtipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTipoRepuesto)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Image = global::SistemaGestionTaller.Properties.Resources.agregar;
            this.buttonAgregar.Location = new System.Drawing.Point(257, 303);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(40, 40);
            this.buttonAgregar.TabIndex = 8;
            this.buttonAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Image = global::SistemaGestionTaller.Properties.Resources.editar;
            this.buttonEditar.Location = new System.Drawing.Point(211, 303);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(40, 40);
            this.buttonEditar.TabIndex = 9;
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Image = global::SistemaGestionTaller.Properties.Resources.eliminar;
            this.buttonEliminar.Location = new System.Drawing.Point(165, 303);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(40, 40);
            this.buttonEliminar.TabIndex = 10;
            this.buttonEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // dataGridTipoRepuesto
            // 
            this.dataGridTipoRepuesto.AllowUserToAddRows = false;
            this.dataGridTipoRepuesto.AllowUserToDeleteRows = false;
            this.dataGridTipoRepuesto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridTipoRepuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTipoRepuesto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtipo,
            this.descripcion});
            this.dataGridTipoRepuesto.Location = new System.Drawing.Point(13, 10);
            this.dataGridTipoRepuesto.Name = "dataGridTipoRepuesto";
            this.dataGridTipoRepuesto.ReadOnly = true;
            this.dataGridTipoRepuesto.RowHeadersVisible = false;
            this.dataGridTipoRepuesto.Size = new System.Drawing.Size(284, 287);
            this.dataGridTipoRepuesto.TabIndex = 7;
            this.dataGridTipoRepuesto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTipoRepuesto_CellClick);
            // 
            // idtipo
            // 
            this.idtipo.HeaderText = "ID";
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
            // frmGestionTipoRepuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 352);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.dataGridTipoRepuesto);
            this.Name = "frmGestionTipoRepuesto";
            this.Text = "Gestión Tipo de Repuesto";
            this.Load += new System.EventHandler(this.frmGestionTipoRepuesto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTipoRepuesto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.DataGridView dataGridTipoRepuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
    }
}