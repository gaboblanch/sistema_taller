namespace SistemaGestionTaller
{
    partial class frmLibroAnual
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
            this.numericAnio = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewMes = new System.Windows.Forms.DataGridView();
            this.idmes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingresototal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.egresototal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ganancias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxEgreso = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxIngreso = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textGanancias = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericAnio)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMes)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericAnio
            // 
            this.numericAnio.Location = new System.Drawing.Point(68, 16);
            this.numericAnio.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numericAnio.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericAnio.Name = "numericAnio";
            this.numericAnio.Size = new System.Drawing.Size(55, 20);
            this.numericAnio.TabIndex = 0;
            this.numericAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericAnio.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericAnio.ValueChanged += new System.EventHandler(this.numericAnio_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Año:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericAnio);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 44);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // dataGridViewMes
            // 
            this.dataGridViewMes.AllowUserToAddRows = false;
            this.dataGridViewMes.AllowUserToDeleteRows = false;
            this.dataGridViewMes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idmes,
            this.mes,
            this.ingresototal,
            this.egresototal,
            this.ganancias});
            this.dataGridViewMes.Location = new System.Drawing.Point(12, 62);
            this.dataGridViewMes.Name = "dataGridViewMes";
            this.dataGridViewMes.ReadOnly = true;
            this.dataGridViewMes.RowHeadersVisible = false;
            this.dataGridViewMes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMes.Size = new System.Drawing.Size(483, 375);
            this.dataGridViewMes.TabIndex = 3;
            this.dataGridViewMes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMes_CellDoubleClick);
            // 
            // idmes
            // 
            this.idmes.HeaderText = "Idmes";
            this.idmes.Name = "idmes";
            this.idmes.ReadOnly = true;
            this.idmes.Visible = false;
            // 
            // mes
            // 
            this.mes.HeaderText = "Mes";
            this.mes.Name = "mes";
            this.mes.ReadOnly = true;
            this.mes.Width = 150;
            // 
            // ingresototal
            // 
            this.ingresototal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.ingresototal.DefaultCellStyle = dataGridViewCellStyle1;
            this.ingresototal.HeaderText = "Ingresos";
            this.ingresototal.Name = "ingresototal";
            this.ingresototal.ReadOnly = true;
            this.ingresototal.Width = 72;
            // 
            // egresototal
            // 
            this.egresototal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.egresototal.DefaultCellStyle = dataGridViewCellStyle2;
            this.egresototal.HeaderText = "Egreso";
            this.egresototal.Name = "egresototal";
            this.egresototal.ReadOnly = true;
            this.egresototal.Width = 65;
            // 
            // ganancias
            // 
            this.ganancias.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.ganancias.DefaultCellStyle = dataGridViewCellStyle3;
            this.ganancias.HeaderText = "Ganancias";
            this.ganancias.Name = "ganancias";
            this.ganancias.ReadOnly = true;
            this.ganancias.Width = 83;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxEgreso);
            this.groupBox2.Location = new System.Drawing.Point(255, 443);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(117, 53);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Egresos";
            // 
            // textBoxEgreso
            // 
            this.textBoxEgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEgreso.Location = new System.Drawing.Point(8, 20);
            this.textBoxEgreso.Name = "textBoxEgreso";
            this.textBoxEgreso.Size = new System.Drawing.Size(100, 22);
            this.textBoxEgreso.TabIndex = 0;
            this.textBoxEgreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxIngreso);
            this.groupBox3.Location = new System.Drawing.Point(132, 443);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(117, 53);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ingresos";
            // 
            // textBoxIngreso
            // 
            this.textBoxIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIngreso.Location = new System.Drawing.Point(8, 20);
            this.textBoxIngreso.Name = "textBoxIngreso";
            this.textBoxIngreso.Size = new System.Drawing.Size(100, 22);
            this.textBoxIngreso.TabIndex = 0;
            this.textBoxIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textGanancias);
            this.groupBox4.Location = new System.Drawing.Point(378, 443);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(117, 53);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ganancias";
            // 
            // textGanancias
            // 
            this.textGanancias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textGanancias.Location = new System.Drawing.Point(8, 20);
            this.textGanancias.Name = "textGanancias";
            this.textGanancias.Size = new System.Drawing.Size(100, 22);
            this.textGanancias.TabIndex = 0;
            this.textGanancias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmLibroAnual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 505);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridViewMes);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmLibroAnual";
            this.Text = "Libro Anual Contable";
            this.Load += new System.EventHandler(this.frmLibroAnual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericAnio)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMes)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericAnio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewMes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxEgreso;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmes;
        private System.Windows.Forms.DataGridViewTextBoxColumn mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ingresototal;
        private System.Windows.Forms.DataGridViewTextBoxColumn egresototal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ganancias;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textGanancias;
    }
}