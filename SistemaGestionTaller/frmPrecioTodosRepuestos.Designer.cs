namespace SistemaGestionTaller
{
    partial class frmPrecioTodosRepuestos
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAumento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxAumento);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 52);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "%";
            // 
            // textBoxAumento
            // 
            this.textBoxAumento.Location = new System.Drawing.Point(73, 19);
            this.textBoxAumento.Name = "textBoxAumento";
            this.textBoxAumento.Size = new System.Drawing.Size(51, 20);
            this.textBoxAumento.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Aumento:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(190, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(81, 47);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Aplicar Aumento";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmPrecioTodosRepuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 65);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrecioTodosRepuestos";
            this.Text = "Precios de Respuestos";
            this.Load += new System.EventHandler(this.frmPrecioTodosRepuestos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAumento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuardar;
    }
}