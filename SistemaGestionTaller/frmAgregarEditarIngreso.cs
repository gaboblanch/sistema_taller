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
    public partial class frmAgregarEditarIngreso : Form
    {
        private Ingreso ingreso;
        private bool flagEditar;
        private int idIngreso;

        //DELEGADOS Y EVENTOS
        public delegate void actualizarDataGrid();
        public event actualizarDataGrid actualizarDataGridEvento;

        public frmAgregarEditarIngreso()
        {
            InitializeComponent();
        }

        public frmAgregarEditarIngreso(int id_p)
        {
            InitializeComponent();
            this.idIngreso = id_p;
            this.flagEditar = true;
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

        private void frmAgregarEditarIngreso_Load(object sender, EventArgs e)
        {
            ingreso = new Ingreso();

            if (flagEditar)
            {
                ingreso.getIngreso();
                this.textBoxDescripcion.Text = ingreso.Descripcion;
                this.textBoxImporte.Text = ingreso.Importe.ToString();
                this.dateTimePickerFecha.Value = ingreso.Fecha;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            ingreso.Descripcion = this.textBoxDescripcion.Text.ToUpper();
            ingreso.Importe = Convert.ToDouble(this.textBoxImporte.Text);
            ingreso.Fecha = this.dateTimePickerFecha.Value;

            if(this.buttonGuardar.Text == "Terminar")
            {
                this.Close();
                return;
            }
            else if (flagEditar)
            {
                try
                {
                    ingreso.actualizar();

                    this.buttonGuardar.Text = "Terminar";
                    this.buttonGuardar.Image = null;
                    this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error: "+ex,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    ingreso.agregar();

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

        private void dateTimePickerFecha_ValueChanged(object sender, EventArgs e)
        {
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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

        private void frmAgregarEditarIngreso_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void textBoxImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comprobarNumero(this, e, this.textBoxImporte.Text);
        }
    }
}
