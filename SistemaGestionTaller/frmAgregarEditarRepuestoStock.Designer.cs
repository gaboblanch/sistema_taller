namespace SistemaGestionTaller
{
    partial class frmAgregarEditarRepuestoStock
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textCodigo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonTipo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.textDescripcion = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textMarca = new System.Windows.Forms.ComboBox();
            this.textModelo = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Marca:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textModelo);
            this.groupBox1.Controls.Add(this.textMarca);
            this.groupBox1.Controls.Add(this.textCodigo);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.buttonTipo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboTipo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 159);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // textCodigo
            // 
            this.textCodigo.Location = new System.Drawing.Point(80, 56);
            this.textCodigo.Name = "textCodigo";
            this.textCodigo.Size = new System.Drawing.Size(206, 20);
            this.textCodigo.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Código:";
            // 
            // buttonTipo
            // 
            this.buttonTipo.Location = new System.Drawing.Point(292, 23);
            this.buttonTipo.Name = "buttonTipo";
            this.buttonTipo.Size = new System.Drawing.Size(24, 23);
            this.buttonTipo.TabIndex = 10;
            this.buttonTipo.Text = "...";
            this.buttonTipo.UseVisualStyleBackColor = true;
            this.buttonTipo.Click += new System.EventHandler(this.buttonTipo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Modelo:";
            // 
            // comboTipo
            // 
            this.comboTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Location = new System.Drawing.Point(80, 24);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(206, 21);
            this.comboTipo.TabIndex = 0;
            this.comboTipo.SelectedIndexChanged += new System.EventHandler(this.comboTipo_SelectedIndexChanged);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Location = new System.Drawing.Point(238, 252);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(102, 54);
            this.buttonGuardar.TabIndex = 0;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // textDescripcion
            // 
            this.textDescripcion.Location = new System.Drawing.Point(8, 19);
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(318, 41);
            this.textDescripcion.TabIndex = 0;
            this.textDescripcion.Text = "";
            this.textDescripcion.TextChanged += new System.EventHandler(this.textDescripcion_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textDescripcion);
            this.groupBox2.Location = new System.Drawing.Point(8, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(332, 69);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Descripción";
            // 
            // textMarca
            // 
            this.textMarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textMarca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.textMarca.FormattingEnabled = true;
            this.textMarca.Location = new System.Drawing.Point(80, 87);
            this.textMarca.Name = "textMarca";
            this.textMarca.Size = new System.Drawing.Size(206, 21);
            this.textMarca.TabIndex = 12;
            // 
            // textModelo
            // 
            this.textModelo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textModelo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.textModelo.FormattingEnabled = true;
            this.textModelo.Location = new System.Drawing.Point(80, 119);
            this.textModelo.Name = "textModelo";
            this.textModelo.Size = new System.Drawing.Size(206, 21);
            this.textModelo.TabIndex = 13;
            // 
            // frmAgregarEditarRepuestoStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 317);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAgregarEditarRepuestoStock";
            this.Text = "Respuestos";
            this.Load += new System.EventHandler(this.frmAgregarEditarRespuesto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboTipo;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonTipo;
        private System.Windows.Forms.TextBox textCodigo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox textDescripcion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox textModelo;
        private System.Windows.Forms.ComboBox textMarca;
    }
}