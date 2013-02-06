namespace SistemaGestionTaller
{
    partial class frmBuscarProveedor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textRazonSocial = new System.Windows.Forms.TextBox();
            this.listBoxProveedor = new System.Windows.Forms.ListBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonBuscar);
            this.groupBox1.Controls.Add(this.listBoxProveedor);
            this.groupBox1.Controls.Add(this.textRazonSocial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 167);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razón Social:";
            // 
            // textRazonSocial
            // 
            this.textRazonSocial.Location = new System.Drawing.Point(85, 12);
            this.textRazonSocial.Name = "textRazonSocial";
            this.textRazonSocial.Size = new System.Drawing.Size(145, 20);
            this.textRazonSocial.TabIndex = 1;
            this.textRazonSocial.TextChanged += new System.EventHandler(this.textRazonSocial_TextChanged);
            this.textRazonSocial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textRazonSocial_KeyPress);
            // 
            // listBoxProveedor
            // 
            this.listBoxProveedor.FormattingEnabled = true;
            this.listBoxProveedor.Location = new System.Drawing.Point(6, 40);
            this.listBoxProveedor.Name = "listBoxProveedor";
            this.listBoxProveedor.Size = new System.Drawing.Size(319, 121);
            this.listBoxProveedor.TabIndex = 2;
            this.listBoxProveedor.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxProveedor_MouseDoubleClick);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Image = global::SistemaGestionTaller.Properties.Resources.buscar3;
            this.buttonBuscar.Location = new System.Drawing.Point(236, 11);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(26, 23);
            this.buttonBuscar.TabIndex = 4;
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // frmBuscarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 193);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscarProveedor";
            this.Text = "Buscar Proveedor";
            this.Load += new System.EventHandler(this.frmBuscarProveedor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.ListBox listBoxProveedor;
        private System.Windows.Forms.TextBox textRazonSocial;
        private System.Windows.Forms.Label label1;
    }
}