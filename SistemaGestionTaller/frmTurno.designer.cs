namespace SistemaClinica
{
    partial class frmTurno
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
            this.vOutlookNavPane1 = new VIBlend.WinForms.Controls.vOutlookNavPane();
            this.monthView1 = new System.Windows.Forms.Calendar.MonthView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.calendar1 = new System.Windows.Forms.Calendar.Calendar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboDoctor = new System.Windows.Forms.ComboBox();
            this.comboCiudad = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboObra = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maskedCelular = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedNacimiento = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textDireccion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textDni = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textApellido = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.vOutlookNavPane1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vOutlookNavPane1
            // 
            this.vOutlookNavPane1.Dock = System.Windows.Forms.DockStyle.Left;
            this.vOutlookNavPane1.Location = new System.Drawing.Point(0, 0);
            this.vOutlookNavPane1.Name = "vOutlookNavPane1";
            this.vOutlookNavPane1.SelectedItem = null;
            this.vOutlookNavPane1.Size = new System.Drawing.Size(97, 554);
            this.vOutlookNavPane1.TabIndex = 2;
            this.vOutlookNavPane1.Text = "vOutlookNavPane1";
            this.vOutlookNavPane1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
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
            this.monthView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.monthView1.ItemPadding = new System.Windows.Forms.Padding(2);
            this.monthView1.Location = new System.Drawing.Point(97, 0);
            this.monthView1.MaxSelectionCount = 35;
            this.monthView1.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthView1.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.monthView1.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthView1.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthView1.Name = "monthView1";
            this.monthView1.Size = new System.Drawing.Size(210, 554);
            this.monthView1.TabIndex = 7;
            this.monthView1.Text = "monthView1";
            this.monthView1.TodayBorderColor = System.Drawing.Color.Maroon;
            this.monthView1.SelectionChanged += new System.EventHandler(this.monthView1_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.calendar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(307, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(666, 366);
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
            this.calendar1.Size = new System.Drawing.Size(645, 870);
            this.calendar1.TabIndex = 7;
            this.calendar1.Text = "calendar1";
            this.calendar1.ItemCreated += new System.Windows.Forms.Calendar.Calendar.CalendarItemCancelEventHandler(this.calendar1_ItemCreated);
            this.calendar1.ItemDeleted += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemDeleted);
            this.calendar1.ItemClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.comboDoctor);
            this.groupBox1.Controls.Add(this.comboCiudad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboObra);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.maskedCelular);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.maskedNacimiento);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textDireccion);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textDni);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textApellido);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textNombre);
            this.groupBox1.Location = new System.Drawing.Point(441, 384);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 161);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Personales";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Doctor:";
            // 
            // comboDoctor
            // 
            this.comboDoctor.FormattingEnabled = true;
            this.comboDoctor.Location = new System.Drawing.Point(57, 127);
            this.comboDoctor.Name = "comboDoctor";
            this.comboDoctor.Size = new System.Drawing.Size(121, 21);
            this.comboDoctor.TabIndex = 9;
            // 
            // comboCiudad
            // 
            this.comboCiudad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboCiudad.FormattingEnabled = true;
            this.comboCiudad.Location = new System.Drawing.Point(277, 97);
            this.comboCiudad.Name = "comboCiudad";
            this.comboCiudad.Size = new System.Drawing.Size(121, 21);
            this.comboCiudad.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido:";
            // 
            // comboObra
            // 
            this.comboObra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboObra.FormattingEnabled = true;
            this.comboObra.Location = new System.Drawing.Point(275, 21);
            this.comboObra.Name = "comboObra";
            this.comboObra.Size = new System.Drawing.Size(121, 21);
            this.comboObra.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "D.N.I.:";
            // 
            // maskedCelular
            // 
            this.maskedCelular.Location = new System.Drawing.Point(277, 47);
            this.maskedCelular.Mask = "0000-000000";
            this.maskedCelular.Name = "maskedCelular";
            this.maskedCelular.Size = new System.Drawing.Size(74, 20);
            this.maskedCelular.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Celular:";
            // 
            // maskedNacimiento
            // 
            this.maskedNacimiento.Location = new System.Drawing.Point(123, 101);
            this.maskedNacimiento.Mask = "00/00/00";
            this.maskedNacimiento.Name = "maskedNacimiento";
            this.maskedNacimiento.Size = new System.Drawing.Size(55, 20);
            this.maskedNacimiento.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Dirección:";
            // 
            // textDireccion
            // 
            this.textDireccion.Location = new System.Drawing.Point(277, 72);
            this.textDireccion.Name = "textDireccion";
            this.textDireccion.Size = new System.Drawing.Size(121, 20);
            this.textDireccion.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fecha de Nacimiento:";
            // 
            // textDni
            // 
            this.textDni.Location = new System.Drawing.Point(57, 75);
            this.textDni.Name = "textDni";
            this.textDni.Size = new System.Drawing.Size(121, 20);
            this.textDni.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(209, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ciudad:";
            // 
            // textApellido
            // 
            this.textApellido.Location = new System.Drawing.Point(57, 48);
            this.textApellido.Name = "textApellido";
            this.textApellido.Size = new System.Drawing.Size(121, 20);
            this.textApellido.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(209, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Obra Social:";
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(57, 22);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(121, 20);
            this.textNombre.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(871, 470);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 75);
            this.button1.TabIndex = 12;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.monthView1);
            this.Controls.Add(this.vOutlookNavPane1);
            this.Name = "frmTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Turnos";
            this.Load += new System.EventHandler(this.frmTurno_Load);
            this.vOutlookNavPane1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private VIBlend.WinForms.Controls.vOutlookNavPane vOutlookNavPane1;
        private System.Windows.Forms.Calendar.MonthView monthView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Calendar.Calendar calendar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboDoctor;
        private System.Windows.Forms.ComboBox comboCiudad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboObra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox maskedCelular;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox maskedNacimiento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textDireccion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textDni;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textApellido;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Button button1;

    }
}