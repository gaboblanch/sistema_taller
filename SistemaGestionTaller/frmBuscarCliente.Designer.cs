namespace SistemaGestionTaller
{
    partial class frmBuscarCliente
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
            this.textApellido = new System.Windows.Forms.TextBox();
            this.listCliente = new System.Windows.Forms.ListBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Apellido:";
            // 
            // textApellido
            // 
            this.textApellido.Location = new System.Drawing.Point(216, 13);
            this.textApellido.Name = "textApellido";
            this.textApellido.Size = new System.Drawing.Size(100, 20);
            this.textApellido.TabIndex = 3;
            this.textApellido.TextChanged += new System.EventHandler(this.textApellido_TextChanged);
            // 
            // listCliente
            // 
            this.listCliente.FormattingEnabled = true;
            this.listCliente.Location = new System.Drawing.Point(11, 41);
            this.listCliente.Name = "listCliente";
            this.listCliente.Size = new System.Drawing.Size(337, 121);
            this.listCliente.TabIndex = 4;
            this.listCliente.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listCliente_MouseDoubleClick);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Image = global::SistemaGestionTaller.Properties.Resources.buscar3;
            this.buttonBuscar.Location = new System.Drawing.Point(322, 12);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(26, 23);
            this.buttonBuscar.TabIndex = 5;
            this.buttonBuscar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonBuscar);
            this.groupBox1.Controls.Add(this.listCliente);
            this.groupBox1.Controls.Add(this.textApellido);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 172);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // frmBuscarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 183);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscarCliente";
            this.Text = "Buscar Cliente";
            this.Load += new System.EventHandler(this.frmBuscarCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textApellido;
        private System.Windows.Forms.ListBox listCliente;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}