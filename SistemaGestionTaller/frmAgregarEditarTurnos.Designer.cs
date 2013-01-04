namespace SistemaGestionTaller
{
    partial class frmAgregarEditarTurnos
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
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange1 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange2 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange3 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange4 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange5 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            this.panel1 = new System.Windows.Forms.Panel();
            this.calendar1 = new System.Windows.Forms.Calendar.Calendar();
            this.monthView1 = new System.Windows.Forms.Calendar.MonthView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonAgregarVehiculo = new System.Windows.Forms.Button();
            this.textModelo = new System.Windows.Forms.TextBox();
            this.textDominio = new System.Windows.Forms.TextBox();
            this.buttonBuscarVehiculo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonNuevoCliente = new System.Windows.Forms.Button();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.textApellido = new System.Windows.Forms.TextBox();
            this.buttonBuscarCliente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.calendar1);
            this.panel1.Location = new System.Drawing.Point(228, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 495);
            this.panel1.TabIndex = 8;
            // 
            // calendar1
            // 
            this.calendar1.AllowItemResize = false;
            this.calendar1.AutoScroll = true;
            this.calendar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.calendar1.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.calendar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            calendarHighlightRange1.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange1.EndTime = System.TimeSpan.Parse("21:00:00");
            calendarHighlightRange1.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange2.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange2.EndTime = System.TimeSpan.Parse("21:00:00");
            calendarHighlightRange2.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange3.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange3.EndTime = System.TimeSpan.Parse("21:00:00");
            calendarHighlightRange3.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange4.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange4.EndTime = System.TimeSpan.Parse("21:00:00");
            calendarHighlightRange4.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange5.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange5.EndTime = System.TimeSpan.Parse("21:00:00");
            calendarHighlightRange5.StartTime = System.TimeSpan.Parse("08:00:00");
            this.calendar1.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange1,
        calendarHighlightRange2,
        calendarHighlightRange3,
        calendarHighlightRange4,
        calendarHighlightRange5};
            this.calendar1.Location = new System.Drawing.Point(0, 0);
            this.calendar1.Name = "calendar1";
            this.calendar1.Size = new System.Drawing.Size(640, 1067);
            this.calendar1.TabIndex = 8;
            this.calendar1.Text = "calendar1";
            this.calendar1.ItemCreated += new System.Windows.Forms.Calendar.Calendar.CalendarItemCancelEventHandler(this.calendar1_ItemCreated_1);
            // 
            // monthView1
            // 
            this.monthView1.ArrowsColor = System.Drawing.SystemColors.Window;
            this.monthView1.ArrowsSelectedColor = System.Drawing.Color.Gold;
            this.monthView1.DayBackgroundColor = System.Drawing.Color.Empty;
            this.monthView1.DayGrayedText = System.Drawing.SystemColors.GrayText;
            this.monthView1.DaySelectedBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.monthView1.DaySelectedColor = System.Drawing.SystemColors.WindowText;
            this.monthView1.DaySelectedTextColor = System.Drawing.SystemColors.HighlightText;
            this.monthView1.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.monthView1.ItemPadding = new System.Windows.Forms.Padding(2);
            this.monthView1.Location = new System.Drawing.Point(12, 97);
            this.monthView1.MaxSelectionCount = 3;
            this.monthView1.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthView1.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.monthView1.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthView1.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthView1.Name = "monthView1";
            this.monthView1.Size = new System.Drawing.Size(210, 480);
            this.monthView1.TabIndex = 7;
            this.monthView1.Text = "monthView1";
            this.monthView1.TodayBorderColor = System.Drawing.Color.Maroon;
            this.monthView1.SelectionChanged += new System.EventHandler(this.monthView1_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonAgregarVehiculo);
            this.groupBox2.Controls.Add(this.textModelo);
            this.groupBox2.Controls.Add(this.textDominio);
            this.groupBox2.Controls.Add(this.buttonBuscarVehiculo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(557, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 81);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Vehículo";
            // 
            // buttonAgregarVehiculo
            // 
            this.buttonAgregarVehiculo.Location = new System.Drawing.Point(281, 17);
            this.buttonAgregarVehiculo.Name = "buttonAgregarVehiculo";
            this.buttonAgregarVehiculo.Size = new System.Drawing.Size(27, 23);
            this.buttonAgregarVehiculo.TabIndex = 7;
            this.buttonAgregarVehiculo.Text = "+";
            this.buttonAgregarVehiculo.UseVisualStyleBackColor = true;
            // 
            // textModelo
            // 
            this.textModelo.Location = new System.Drawing.Point(114, 52);
            this.textModelo.Name = "textModelo";
            this.textModelo.ReadOnly = true;
            this.textModelo.Size = new System.Drawing.Size(126, 20);
            this.textModelo.TabIndex = 6;
            // 
            // textDominio
            // 
            this.textDominio.Location = new System.Drawing.Point(114, 18);
            this.textDominio.Name = "textDominio";
            this.textDominio.ReadOnly = true;
            this.textDominio.Size = new System.Drawing.Size(126, 20);
            this.textDominio.TabIndex = 5;
            // 
            // buttonBuscarVehiculo
            // 
            this.buttonBuscarVehiculo.Location = new System.Drawing.Point(248, 17);
            this.buttonBuscarVehiculo.Name = "buttonBuscarVehiculo";
            this.buttonBuscarVehiculo.Size = new System.Drawing.Size(27, 23);
            this.buttonBuscarVehiculo.TabIndex = 0;
            this.buttonBuscarVehiculo.Text = "...";
            this.buttonBuscarVehiculo.UseVisualStyleBackColor = true;
            this.buttonBuscarVehiculo.Click += new System.EventHandler(this.buttonBuscarVehiculo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Marca, Modelo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dominio:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonNuevoCliente);
            this.groupBox1.Controls.Add(this.textNombre);
            this.groupBox1.Controls.Add(this.textApellido);
            this.groupBox1.Controls.Add(this.buttonBuscarCliente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(247, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 81);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente :: Datos Personales";
            // 
            // buttonNuevoCliente
            // 
            this.buttonNuevoCliente.Location = new System.Drawing.Point(265, 20);
            this.buttonNuevoCliente.Name = "buttonNuevoCliente";
            this.buttonNuevoCliente.Size = new System.Drawing.Size(27, 23);
            this.buttonNuevoCliente.TabIndex = 6;
            this.buttonNuevoCliente.Text = "+";
            this.buttonNuevoCliente.UseVisualStyleBackColor = true;
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(79, 21);
            this.textNombre.Name = "textNombre";
            this.textNombre.ReadOnly = true;
            this.textNombre.Size = new System.Drawing.Size(145, 20);
            this.textNombre.TabIndex = 3;
            // 
            // textApellido
            // 
            this.textApellido.Location = new System.Drawing.Point(79, 52);
            this.textApellido.Name = "textApellido";
            this.textApellido.ReadOnly = true;
            this.textApellido.Size = new System.Drawing.Size(145, 20);
            this.textApellido.TabIndex = 4;
            // 
            // buttonBuscarCliente
            // 
            this.buttonBuscarCliente.Location = new System.Drawing.Point(232, 20);
            this.buttonBuscarCliente.Name = "buttonBuscarCliente";
            this.buttonBuscarCliente.Size = new System.Drawing.Size(27, 23);
            this.buttonBuscarCliente.TabIndex = 0;
            this.buttonBuscarCliente.Text = "...";
            this.buttonBuscarCliente.UseVisualStyleBackColor = true;
            this.buttonBuscarCliente.Click += new System.EventHandler(this.buttonBuscarCliente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido:";
            // 
            // frmAgregarEditarTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 629);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.monthView1);
            this.Name = "frmAgregarEditarTurnos";
            this.Text = "Turnos";
            this.Load += new System.EventHandler(this.frmAgregarEditarTurnos_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Calendar.MonthView monthView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonAgregarVehiculo;
        private System.Windows.Forms.TextBox textModelo;
        private System.Windows.Forms.TextBox textDominio;
        private System.Windows.Forms.Button buttonBuscarVehiculo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonNuevoCliente;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.TextBox textApellido;
        private System.Windows.Forms.Button buttonBuscarCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Calendar.Calendar calendar1;
    }
}