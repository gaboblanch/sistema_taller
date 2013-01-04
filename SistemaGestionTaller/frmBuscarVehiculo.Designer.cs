namespace SistemaGestionTaller
{
    partial class frmBuscarVehiculo
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
            this.listBoxVehiculos = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxVehiculos
            // 
            this.listBoxVehiculos.FormattingEnabled = true;
            this.listBoxVehiculos.Location = new System.Drawing.Point(18, 45);
            this.listBoxVehiculos.Name = "listBoxVehiculos";
            this.listBoxVehiculos.Size = new System.Drawing.Size(197, 199);
            this.listBoxVehiculos.TabIndex = 0;
            this.listBoxVehiculos.SelectedIndexChanged += new System.EventHandler(this.listBoxVehiculos_SelectedIndexChanged);
            this.listBoxVehiculos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxVehiculos_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonEditar);
            this.groupBox1.Controls.Add(this.listBoxVehiculos);
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 260);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // buttonEditar
            // 
            this.buttonEditar.Location = new System.Drawing.Point(172, 14);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(43, 21);
            this.buttonEditar.TabIndex = 1;
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // frmBuscarVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 285);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscarVehiculo";
            this.Text = "Buscar Vehículo";
            this.Load += new System.EventHandler(this.frmBuscarVehiculo_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxVehiculos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonEditar;
    }
}