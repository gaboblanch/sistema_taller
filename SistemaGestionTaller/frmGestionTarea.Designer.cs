namespace SistemaGestionTaller
{
    partial class frmGestionTarea
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
            this.dataGridTarea = new System.Windows.Forms.DataGridView();
            this.idtarea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripciontarea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTarea)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridTarea
            // 
            this.dataGridTarea.AllowUserToAddRows = false;
            this.dataGridTarea.AllowUserToDeleteRows = false;
            this.dataGridTarea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTarea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtarea,
            this.descripciontarea,
            this.duracion,
            this.costo});
            this.dataGridTarea.Location = new System.Drawing.Point(12, 12);
            this.dataGridTarea.MultiSelect = false;
            this.dataGridTarea.Name = "dataGridTarea";
            this.dataGridTarea.ReadOnly = true;
            this.dataGridTarea.RowHeadersVisible = false;
            this.dataGridTarea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTarea.Size = new System.Drawing.Size(325, 350);
            this.dataGridTarea.TabIndex = 0;
            this.dataGridTarea.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTarea_CellClick);
            this.dataGridTarea.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTarea_CellDoubleClick);
            // 
            // idtarea
            // 
            this.idtarea.HeaderText = "Id";
            this.idtarea.Name = "idtarea";
            this.idtarea.ReadOnly = true;
            this.idtarea.Visible = false;
            // 
            // descripciontarea
            // 
            this.descripciontarea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.descripciontarea.HeaderText = "Descripción";
            this.descripciontarea.Name = "descripciontarea";
            this.descripciontarea.ReadOnly = true;
            this.descripciontarea.Width = 88;
            // 
            // duracion
            // 
            this.duracion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.duracion.HeaderText = "Duración";
            this.duracion.Name = "duracion";
            this.duracion.ReadOnly = true;
            this.duracion.Visible = false;
            // 
            // costo
            // 
            this.costo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.costo.HeaderText = "Costo";
            this.costo.Name = "costo";
            this.costo.ReadOnly = true;
            this.costo.Visible = false;
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Image = global::SistemaGestionTaller.Properties.Resources.agregar;
            this.buttonAgregar.Location = new System.Drawing.Point(297, 368);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(40, 40);
            this.buttonAgregar.TabIndex = 0;
            this.buttonAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Image = global::SistemaGestionTaller.Properties.Resources.eliminar;
            this.buttonEliminar.Location = new System.Drawing.Point(205, 368);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(40, 40);
            this.buttonEliminar.TabIndex = 2;
            this.buttonEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Image = global::SistemaGestionTaller.Properties.Resources.editar;
            this.buttonEditar.Location = new System.Drawing.Point(251, 368);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(40, 40);
            this.buttonEditar.TabIndex = 1;
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // frmGestionTarea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 414);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.dataGridTarea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGestionTarea";
            this.Text = "Gestión de Tareas";
            this.Load += new System.EventHandler(this.frmGestionTarea_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTarea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridTarea;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtarea;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripciontarea;
        private System.Windows.Forms.DataGridViewTextBoxColumn duracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
    }
}