using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaGestionTaller
{
    public partial class frmAgregarEditarEgreso : Form
    {
        private Egreso egreso;
        private bool flagEditar;
        private int idEgreso;

        //DELEGADOS Y EVENTOS
        public delegate void actualizarDataGrid();
        public event actualizarDataGrid actualizarDataGridEvento;

        public frmAgregarEditarEgreso()
        {
            InitializeComponent();
        }

        public frmAgregarEditarEgreso(int idEgreso_p)
        {
            InitializeComponent();
            this.idEgreso = idEgreso_p;
            this.flagEditar = true;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            egreso.Descripcion = this.textBoxDescripcion.Text.ToUpper();
            egreso.Importe = Convert.ToDouble(this.textBoxImporte.Text);
            egreso.Fecha = this.dateTimePickerFecha.Value;

            if (this.buttonGuardar.Text == "Terminar")
            {
                this.Close();
                return;
            }
            else if (flagEditar)
            {
                try
                {
                    egreso.actualizar();

                    this.buttonGuardar.Text = "Terminar";
                    this.buttonGuardar.Image = null;
                    this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
                    this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    this.buttonGuardar.Text = "Guardar";
                    this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                }
            }
            else
            {
                try
                {
                    egreso.agregar();

                    this.buttonGuardar.Text = "Terminar";
                    this.buttonGuardar.Image = null;
                    this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
                    this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    this.buttonGuardar.Text = "Guardar";
                    this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                }
            }
            
            if (this.actualizarDataGridEvento != null)
                this.actualizarDataGridEvento();
        }

        private void frmAgregarEditarEgreso_Load(object sender, EventArgs e)
        {
            egreso = new Egreso();

            if (flagEditar)
            {
                egreso.getEgreso();

                this.textBoxDescripcion.Text = egreso.Descripcion;
                this.textBoxImporte.Text = egreso.Importe.ToString();
                this.dateTimePickerFecha.Value = egreso.Fecha;
            }
        }

        private void textBoxImporte_TextChanged(object sender, EventArgs e)
        {
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void textBoxDescripcion_TextChanged(object sender, EventArgs e)
        {
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void dateTimePickerFecha_ValueChanged(object sender, EventArgs e)
        {
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void frmAgregarEditarEgreso_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void textBoxImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comprobarNumero(this, e, this.textBoxImporte.Text);
        }

        //SOLO PERMITE EL INGRESO DE NUMEROS Y UNA COMA
        private void comprobarNumero(object sender, KeyPressEventArgs e, String cadena)
        {
            if (cadena.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }
    }
}
