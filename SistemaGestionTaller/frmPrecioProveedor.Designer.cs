namespace SistemaGestionTaller
{
    partial class frmPrecioProveedor
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
            this.label2 = new System.Windows.Forms.Label();
            this.buttonBuscarProveedor = new System.Windows.Forms.Button();
            this.textBoxProveedor = new System.Windows.Forms.TextBox();
            this.textBoxAumento = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Aumento:";
            // 
            // buttonBuscarProveedor
            // 
            this.buttonBuscarProveedor.Location = new System.Drawing.Point(335, 17);
            this.buttonBuscarProveedor.Name = "buttonBuscarProveedor";
            this.buttonBuscarProveedor.Size = new System.Drawing.Size(29, 23);
            this.buttonBuscarProveedor.TabIndex = 2;
            this.buttonBuscarProveedor.Text = "...";
            this.buttonBuscarProveedor.UseVisualStyleBackColor = true;
            this.buttonBuscarProveedor.Click += new System.EventHandler(this.buttonBuscarProveedor_Click);
            // 
            // textBoxProveedor
            // 
            this.textBoxProveedor.Location = new System.Drawing.Point(82, 18);
            this.textBoxProveedor.Name = "textBoxProveedor";
            this.textBoxProveedor.ReadOnly = true;
            this.textBoxProveedor.Size = new System.Drawing.Size(239, 20);
            this.textBoxProveedor.TabIndex = 3;
            // 
            // textBoxAumento
            // 
            this.textBoxAumento.Location = new System.Drawing.Point(82, 60);
            this.textBoxAumento.Name = "textBoxAumento";
            this.textBoxAumento.Size = new System.Drawing.Size(51, 20);
            this.textBoxAumento.TabIndex = 4;
            this.textBoxAumento.TextChanged += new System.EventHandler(this.textBoxAumento_TextChanged);
            this.textBoxAumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAumento_KeyPress);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(308, 113);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(81, 47);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Aplicar Aumento";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxAumento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxProveedor);
            this.groupBox1.Controls.Add(this.buttonBuscarProveedor);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 95);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "%";
            // 
            // frmPrecioProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 165);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrecioProveedor";
            this.Text = "Gestión de Precios por Proveedor";
            this.Load += new System.EventHandler(this.frmPrecioProveedor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonBuscarProveedor;
        private System.Windows.Forms.TextBox textBoxProveedor;
        private System.Windows.Forms.TextBox textBoxAumento;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
    }
}