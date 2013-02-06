namespace SistemaGestionTaller
{
    partial class frmBuscarTarea
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridTarea = new System.Windows.Forms.DataGridView();
            this.idtarea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripciontarea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTarea)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tarea:";
            // 
            // textFiltro
            // 
            this.textFiltro.Location = new System.Drawing.Point(251, 19);
            this.textFiltro.Name = "textFiltro";
            this.textFiltro.Size = new System.Drawing.Size(148, 20);
            this.textFiltro.TabIndex = 2;
            this.textFiltro.TextChanged += new System.EventHandler(this.textFiltro_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridTarea);
            this.groupBox1.Controls.Add(this.textFiltro);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 394);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // dataGridTarea
            // 
            this.dataGridTarea.AllowUserToAddRows = false;
            this.dataGridTarea.AllowUserToDeleteRows = false;
            this.dataGridTarea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridTarea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTarea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtarea,
            this.descripciontarea,
            this.duracion,
            this.costo});
            this.dataGridTarea.Location = new System.Drawing.Point(6, 45);
            this.dataGridTarea.MultiSelect = false;
            this.dataGridTarea.Name = "dataGridTarea";
            this.dataGridTarea.ReadOnly = true;
            this.dataGridTarea.RowHeadersVisible = false;
            this.dataGridTarea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTarea.Size = new System.Drawing.Size(393, 343);
            this.dataGridTarea.TabIndex = 3;
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
            this.duracion.Width = 75;
            // 
            // costo
            // 
            this.costo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.costo.HeaderText = "Costo";
            this.costo.Name = "costo";
            this.costo.ReadOnly = true;
            this.costo.Visible = false;
            this.costo.Width = 59;
            // 
            // frmBuscarTarea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 408);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBuscarTarea";
            this.Text = "Buscar Tarea";
            this.Load += new System.EventHandler(this.frmBuscarTarea_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTarea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textFiltro;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridTarea;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtarea;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripciontarea;
        private System.Windows.Forms.DataGridViewTextBoxColumn duracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
    }
}