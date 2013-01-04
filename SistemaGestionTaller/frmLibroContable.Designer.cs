namespace SistemaGestionTaller
{
    partial class frmLibroContable
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
            this.dataGridIngreso = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIngresos = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEgresos = new System.Windows.Forms.TextBox();
            this.dataGridEgreso = new System.Windows.Forms.DataGridView();
            this.comboBoxMes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fechaingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaegreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoegreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionegreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeegreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIngreso)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEgreso)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridIngreso.Size = new System.Drawing.Size(727, 350);
            this.dataGridIngreso.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(768, 426);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBoxIngresos);
            this.tabPage1.Controls.Add(this.dataGridIngreso);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(760, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ingresos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(435, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Ingresos:";
            // 
            // textBoxIngresos
            // 
            this.textBoxIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIngresos.Location = new System.Drawing.Point(570, 362);
            this.textBoxIngresos.Name = "textBoxIngresos";
            this.textBoxIngresos.Size = new System.Drawing.Size(173, 26);
            this.textBoxIngresos.TabIndex = 1;
            this.textBoxIngresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.textBoxEgresos);
            this.tabPage2.Controls.Add(this.dataGridEgreso);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(760, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Egresos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(439, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Total Egresos:";
            // 
            // textBoxEgresos
            // 
            this.textBoxEgresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEgresos.Location = new System.Drawing.Point(570, 362);
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
            this.dataGridEgreso.Size = new System.Drawing.Size(727, 350);
            this.dataGridEgreso.TabIndex = 3;
            // 
            // comboBoxMes
            // 
            this.comboBoxMes.FormattingEnabled = true;
            this.comboBoxMes.Items.AddRange(new object[] {
            "ENERO",
            "FEBRERO",
            "MARZO",
            "ABRIL",
            "MAYO",
            "JUNIO",
            "JULIO",
            "AGOSTO",
            "SEPTIEMBRE",
            "OCTUBRE",
            "NOVIEMBRE",
            "DICIEMBRE"});
            this.comboBoxMes.Location = new System.Drawing.Point(659, 12);
            this.comboBoxMes.Name = "comboBoxMes";
            this.comboBoxMes.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMes.TabIndex = 3;
            this.comboBoxMes.SelectedIndexChanged += new System.EventHandler(this.comboBoxMes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(623, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mes:";
            // 
            // fechaingreso
            // 
            this.fechaingreso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.fechaingreso.DefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.importe.DefaultCellStyle = dataGridViewCellStyle2;
            this.importe.HeaderText = "Importe";
            this.importe.Name = "importe";
            this.importe.ReadOnly = true;
            // 
            // fechaegreso
            // 
            this.fechaegreso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.fechaegreso.DefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.importeegreso.DefaultCellStyle = dataGridViewCellStyle4;
            this.importeegreso.HeaderText = "Importe";
            this.importeegreso.Name = "importeegreso";
            this.importeegreso.ReadOnly = true;
            // 
            // frmLibroContable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 477);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxMes);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmLibroContable";
            this.Text = "Libro Contable";
            this.Load += new System.EventHandler(this.frmLibroContable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIngreso)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEgreso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridIngreso;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIngresos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEgresos;
        private System.Windows.Forms.DataGridView dataGridEgreso;
        private System.Windows.Forms.ComboBox comboBoxMes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaegreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoegreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionegreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeegreso;
    }
}