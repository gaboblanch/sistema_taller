namespace SistemaGestionTaller
{
    partial class frmGestionIva
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
            this.dataGridIva = new System.Windows.Forms.DataGridView();
            this.idiva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreiva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIva)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridIva
            // 
            this.dataGridIva.AllowUserToAddRows = false;
            this.dataGridIva.AllowUserToDeleteRows = false;
            this.dataGridIva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIva.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idiva,
            this.nombreiva,
            this.porcentaje});
            this.dataGridIva.Location = new System.Drawing.Point(13, 10);
            this.dataGridIva.Name = "dataGridIva";
            this.dataGridIva.ReadOnly = true;
            this.dataGridIva.RowHeadersVisible = false;
            this.dataGridIva.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridIva.Size = new System.Drawing.Size(284, 287);
            this.dataGridIva.TabIndex = 7;
            // 
            // idiva
            // 
            this.idiva.HeaderText = "ID";
            this.idiva.Name = "idiva";
            this.idiva.ReadOnly = true;
            this.idiva.Visible = false;
            // 
            // nombreiva
            // 
            this.nombreiva.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nombreiva.HeaderText = "I.V.A.";
            this.nombreiva.Name = "nombreiva";
            this.nombreiva.ReadOnly = true;
            this.nombreiva.Width = 58;
            // 
            // porcentaje
            // 
            this.porcentaje.HeaderText = "%";
            this.porcentaje.Name = "porcentaje";
            this.porcentaje.ReadOnly = true;
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
            // frmGestionIva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 352);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.dataGridIva);
            this.Name = "frmGestionIva";
            this.Text = "Gestión Condición IVA";
            this.Load += new System.EventHandler(this.frmGestionIva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIva)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.DataGridView dataGridIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn idiva;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreiva;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentaje;
    }
}