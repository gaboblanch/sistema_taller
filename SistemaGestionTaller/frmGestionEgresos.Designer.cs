namespace SistemaGestionTaller
{
    partial class frmGestionEgresos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.dataGridEgreso = new System.Windows.Forms.DataGridView();
            this.idegreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaegreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionegreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeegreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.textBoxFiltro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEgreso)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePickerInicio);
            this.groupBox1.Controls.Add(this.dateTimePickerFin);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 34);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Inicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fin:";
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerInicio.Location = new System.Drawing.Point(55, 10);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(85, 20);
            this.dateTimePickerInicio.TabIndex = 1;
            this.dateTimePickerInicio.ValueChanged += new System.EventHandler(this.dateTimePickerInicio_ValueChanged);
            // 
            // dateTimePickerFin
            // 
            this.dateTimePickerFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFin.Location = new System.Drawing.Point(211, 10);
            this.dateTimePickerFin.Name = "dateTimePickerFin";
            this.dateTimePickerFin.Size = new System.Drawing.Size(85, 20);
            this.dateTimePickerFin.TabIndex = 0;
            this.dateTimePickerFin.ValueChanged += new System.EventHandler(this.dateTimePickerFin_ValueChanged);
            // 
            // dataGridEgreso
            // 
            this.dataGridEgreso.AllowUserToAddRows = false;
            this.dataGridEgreso.AllowUserToDeleteRows = false;
            this.dataGridEgreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEgreso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idegreso,
            this.fechaegreso,
            this.descripcionegreso,
            this.importeegreso});
            this.dataGridEgreso.Location = new System.Drawing.Point(12, 47);
            this.dataGridEgreso.Name = "dataGridEgreso";
            this.dataGridEgreso.ReadOnly = true;
            this.dataGridEgreso.RowHeadersVisible = false;
            this.dataGridEgreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridEgreso.Size = new System.Drawing.Size(609, 411);
            this.dataGridEgreso.TabIndex = 53;
            // 
            // idegreso
            // 
            this.idegreso.HeaderText = "IdEgreso";
            this.idegreso.Name = "idegreso";
            this.idegreso.ReadOnly = true;
            this.idegreso.Visible = false;
            // 
            // fechaegreso
            // 
            this.fechaegreso.HeaderText = "Fecha";
            this.fechaegreso.Name = "fechaegreso";
            this.fechaegreso.ReadOnly = true;
            // 
            // descripcionegreso
            // 
            this.descripcionegreso.HeaderText = "Descripción";
            this.descripcionegreso.Name = "descripcionegreso";
            this.descripcionegreso.ReadOnly = true;
            // 
            // importeegreso
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.importeegreso.DefaultCellStyle = dataGridViewCellStyle2;
            this.importeegreso.HeaderText = "Importe";
            this.importeegreso.Name = "importeegreso";
            this.importeegreso.ReadOnly = true;
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAgregar.Image = global::SistemaGestionTaller.Properties.Resources.agregar;
            this.buttonAgregar.Location = new System.Drawing.Point(581, 464);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(40, 40);
            this.buttonAgregar.TabIndex = 55;
            this.buttonAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEliminar.Image = global::SistemaGestionTaller.Properties.Resources.eliminar;
            this.buttonEliminar.Location = new System.Drawing.Point(489, 464);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(40, 40);
            this.buttonEliminar.TabIndex = 56;
            this.buttonEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditar.Image = global::SistemaGestionTaller.Properties.Resources.editar;
            this.buttonEditar.Location = new System.Drawing.Point(535, 464);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(40, 40);
            this.buttonEditar.TabIndex = 57;
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // textBoxFiltro
            // 
            this.textBoxFiltro.Location = new System.Drawing.Point(464, 18);
            this.textBoxFiltro.Name = "textBoxFiltro";
            this.textBoxFiltro.Size = new System.Drawing.Size(157, 20);
            this.textBoxFiltro.TabIndex = 59;
            this.textBoxFiltro.TextChanged += new System.EventHandler(this.textBoxFiltro_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Descripción:";
            // 
            // frmGestionEgresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 511);
            this.Controls.Add(this.textBoxFiltro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridEgreso);
            this.Name = "frmGestionEgresos";
            this.Text = "Gestión de Egresos";
            this.Load += new System.EventHandler(this.frmGestionEgresos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEgreso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.DataGridView dataGridEgreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn idegreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaegreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionegreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeegreso;
        private System.Windows.Forms.TextBox textBoxFiltro;
        private System.Windows.Forms.Label label1;
    }
}