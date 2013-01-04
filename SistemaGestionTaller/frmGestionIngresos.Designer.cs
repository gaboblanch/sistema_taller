namespace SistemaGestionTaller
{
    partial class frmGestionIngresos
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
            this.dataGridIngreso = new System.Windows.Forms.DataGridView();
            this.idingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcioningreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFiltro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIngreso)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridIngreso
            // 
            this.dataGridIngreso.AllowUserToAddRows = false;
            this.dataGridIngreso.AllowUserToDeleteRows = false;
            this.dataGridIngreso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridIngreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIngreso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idingreso,
            this.fechaingreso,
            this.descripcioningreso,
            this.importeingreso});
            this.dataGridIngreso.Location = new System.Drawing.Point(12, 48);
            this.dataGridIngreso.Name = "dataGridIngreso";
            this.dataGridIngreso.ReadOnly = true;
            this.dataGridIngreso.RowHeadersVisible = false;
            this.dataGridIngreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridIngreso.Size = new System.Drawing.Size(609, 411);
            this.dataGridIngreso.TabIndex = 0;
            // 
            // idingreso
            // 
            this.idingreso.HeaderText = "IdIngreso";
            this.idingreso.Name = "idingreso";
            this.idingreso.ReadOnly = true;
            this.idingreso.Visible = false;
            // 
            // fechaingreso
            // 
            this.fechaingreso.HeaderText = "Fecha";
            this.fechaingreso.Name = "fechaingreso";
            this.fechaingreso.ReadOnly = true;
            // 
            // descripcioningreso
            // 
            this.descripcioningreso.HeaderText = "Descripción";
            this.descripcioningreso.Name = "descripcioningreso";
            this.descripcioningreso.ReadOnly = true;
            // 
            // importeingreso
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.importeingreso.DefaultCellStyle = dataGridViewCellStyle1;
            this.importeingreso.HeaderText = "Importe";
            this.importeingreso.Name = "importeingreso";
            this.importeingreso.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePickerInicio);
            this.groupBox1.Controls.Add(this.dateTimePickerFin);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 34);
            this.groupBox1.TabIndex = 49;
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
            // buttonAgregar
            // 
            this.buttonAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAgregar.Image = global::SistemaGestionTaller.Properties.Resources.agregar;
            this.buttonAgregar.Location = new System.Drawing.Point(581, 465);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(40, 40);
            this.buttonAgregar.TabIndex = 50;
            this.buttonAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEliminar.Image = global::SistemaGestionTaller.Properties.Resources.eliminar;
            this.buttonEliminar.Location = new System.Drawing.Point(489, 465);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(40, 40);
            this.buttonEliminar.TabIndex = 51;
            this.buttonEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditar.Image = global::SistemaGestionTaller.Properties.Resources.editar;
            this.buttonEditar.Location = new System.Drawing.Point(535, 465);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(40, 40);
            this.buttonEditar.TabIndex = 52;
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Descripción:";
            // 
            // textBoxFiltro
            // 
            this.textBoxFiltro.Location = new System.Drawing.Point(464, 18);
            this.textBoxFiltro.Name = "textBoxFiltro";
            this.textBoxFiltro.Size = new System.Drawing.Size(157, 20);
            this.textBoxFiltro.TabIndex = 54;
            this.textBoxFiltro.TextChanged += new System.EventHandler(this.textBoxFiltro_TextChanged);
            // 
            // frmGestionIngresos
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
            this.Controls.Add(this.dataGridIngreso);
            this.Name = "frmGestionIngresos";
            this.Text = "Gestión de Ingresos";
            this.Load += new System.EventHandler(this.frmGestionIngresos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIngreso)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridIngreso;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcioningreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeingreso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFiltro;
    }
}