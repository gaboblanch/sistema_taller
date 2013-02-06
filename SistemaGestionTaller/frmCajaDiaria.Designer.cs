namespace SistemaGestionTaller
{
    partial class frmCajaDiaria
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIngresos = new System.Windows.Forms.TextBox();
            this.dataGridIngreso = new System.Windows.Forms.DataGridView();
            this.fechaingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxEgresos = new System.Windows.Forms.TextBox();
            this.dataGridEgreso = new System.Windows.Forms.DataGridView();
            this.fechaegreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoegreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionegreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeegreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIngreso)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEgreso)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePickerInicio);
            this.groupBox1.Controls.Add(this.dateTimePickerFin);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 34);
            this.groupBox1.TabIndex = 50;
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(768, 448);
            this.tabControl1.TabIndex = 51;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBoxIngresos);
            this.tabPage1.Controls.Add(this.dataGridIngreso);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(760, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ingresos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(435, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Ingresos:";
            // 
            // textBoxIngresos
            // 
            this.textBoxIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIngresos.Location = new System.Drawing.Point(570, 390);
            this.textBoxIngresos.Name = "textBoxIngresos";
            this.textBoxIngresos.Size = new System.Drawing.Size(173, 26);
            this.textBoxIngresos.TabIndex = 1;
            this.textBoxIngresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridIngreso
            // 
            this.dataGridIngreso.AllowUserToAddRows = false;
            this.dataGridIngreso.AllowUserToDeleteRows = false;
            this.dataGridIngreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIngreso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaingreso,
            this.tipo,
            this.descripcion,
            this.importe});
            this.dataGridIngreso.Location = new System.Drawing.Point(16, 6);
            this.dataGridIngreso.Name = "dataGridIngreso";
            this.dataGridIngreso.ReadOnly = true;
            this.dataGridIngreso.RowHeadersVisible = false;
            this.dataGridIngreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridIngreso.Size = new System.Drawing.Size(727, 378);
            this.dataGridIngreso.TabIndex = 0;
            // 
            // fechaingreso
            // 
            this.fechaingreso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle21.Format = "d";
            dataGridViewCellStyle21.NullValue = null;
            this.fechaingreso.DefaultCellStyle = dataGridViewCellStyle21;
            this.fechaingreso.HeaderText = "Fecha";
            this.fechaingreso.Name = "fechaingreso";
            this.fechaingreso.ReadOnly = true;
            this.fechaingreso.Width = 62;
            // 
            // tipo
            // 
            this.tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Width = 53;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 88;
            // 
            // importe
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle22.Format = "C2";
            dataGridViewCellStyle22.NullValue = null;
            this.importe.DefaultCellStyle = dataGridViewCellStyle22;
            this.importe.HeaderText = "Importe";
            this.importe.Name = "importe";
            this.importe.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.textBoxEgresos);
            this.tabPage2.Controls.Add(this.dataGridEgreso);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(760, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Egresos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(435, 393);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Total Egresos:";
            // 
            // textBoxEgresos
            // 
            this.textBoxEgresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEgresos.Location = new System.Drawing.Point(570, 390);
            this.textBoxEgresos.Name = "textBoxEgresos";
            this.textBoxEgresos.Size = new System.Drawing.Size(173, 26);
            this.textBoxEgresos.TabIndex = 4;
            this.textBoxEgresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridEgreso
            // 
            this.dataGridEgreso.AllowUserToAddRows = false;
            this.dataGridEgreso.AllowUserToDeleteRows = false;
            this.dataGridEgreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEgreso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaegreso,
            this.tipoegreso,
            this.descripcionegreso,
            this.importeegreso});
            this.dataGridEgreso.Location = new System.Drawing.Point(16, 6);
            this.dataGridEgreso.Name = "dataGridEgreso";
            this.dataGridEgreso.ReadOnly = true;
            this.dataGridEgreso.RowHeadersVisible = false;
            this.dataGridEgreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridEgreso.Size = new System.Drawing.Size(727, 378);
            this.dataGridEgreso.TabIndex = 3;
            // 
            // fechaegreso
            // 
            this.fechaegreso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.Format = "d";
            dataGridViewCellStyle23.NullValue = null;
            this.fechaegreso.DefaultCellStyle = dataGridViewCellStyle23;
            this.fechaegreso.HeaderText = "Fecha";
            this.fechaegreso.Name = "fechaegreso";
            this.fechaegreso.ReadOnly = true;
            this.fechaegreso.Width = 62;
            // 
            // tipoegreso
            // 
            this.tipoegreso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tipoegreso.HeaderText = "Tipo";
            this.tipoegreso.Name = "tipoegreso";
            this.tipoegreso.ReadOnly = true;
            this.tipoegreso.Width = 53;
            // 
            // descripcionegreso
            // 
            this.descripcionegreso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.descripcionegreso.HeaderText = "Descripcion";
            this.descripcionegreso.Name = "descripcionegreso";
            this.descripcionegreso.ReadOnly = true;
            this.descripcionegreso.Width = 88;
            // 
            // importeegreso
            // 
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle24.Format = "C2";
            dataGridViewCellStyle24.NullValue = null;
            this.importeegreso.DefaultCellStyle = dataGridViewCellStyle24;
            this.importeegreso.HeaderText = "Importe";
            this.importeegreso.Name = "importeegreso";
            this.importeegreso.ReadOnly = true;
            // 
            // frmCajaDiaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 498);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCajaDiaria";
            this.Text = "Caja Diaria";
            this.Load += new System.EventHandler(this.frmCajaDiaria_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIngreso)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEgreso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIngresos;
        private System.Windows.Forms.DataGridView dataGridIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxEgresos;
        private System.Windows.Forms.DataGridView dataGridEgreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaegreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoegreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionegreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeegreso;
    }
}