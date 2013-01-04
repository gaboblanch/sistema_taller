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
    public partial class frmAgregarEditarEgresoGlobal : Form
    {
        private GlobalEgreso egreso;
        private bool flagEditar;
        private int idEgreso;

        //DELEGADO Y EVENTO PARA ACTUALIZAR GRILLA EN frmGestionCliente
        public delegate void actualizarDataGrid();
        public event actualizarDataGrid actualizarDataGridEvento;

        public delegate void calcularDataGrid();
        public event calcularDataGrid calcularDataGridEvento;

        public frmAgregarEditarEgresoGlobal()
        {
            InitializeComponent();
        }

        public frmAgregarEditarEgresoGlobal(int idEgreso_p)
        {
            InitializeComponent();
            this.idEgreso = idEgreso_p;
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

        private void frmAgregarEditarEgresoGlobal_Load(object sender, EventArgs e)
        {
            egreso = new GlobalEgreso();

            if (flagEditar)
            {
                egreso.IdEgreso = this.idEgreso;
                egreso.getEgreso();

                this.textBoxDescripcion.Text = egreso.Descripcion;
                this.textBoxImporte.Text = egreso.Importe.ToString();
                this.comboBoxTipo.Text = egreso.Tipo;
                this.dateTimePickerFecha.Value = egreso.Fecha;

                this.buttonGuardar.Text = "Terminar";
                this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                this.buttonGuardar.Image = null;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (this.buttonGuardar.Text == "Terminar")
            {
                this.Dispose();
                return;
            }

            egreso.Fecha = this.dateTimePickerFecha.Value;
            egreso.Importe = Convert.ToDouble(this.textBoxImporte.Text);
            egreso.Descripcion = this.textBoxDescripcion.Text.ToUpper();
            egreso.Tipo = this.comboBoxTipo.Text;

            if (this.comboBoxTipo.Text != "" || this.textBoxImporte.Text != "")
            {
                if (flagEditar)
                {
                    try
                    {
                        egreso.actualizar();
                        MessageBox.Show("Egreso actualizado con éxito.", "Información");

                        if (this.actualizarDataGridEvento != null)
                            this.actualizarDataGridEvento();

                        this.buttonGuardar.Text = "Terminar";
                        this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                        this.buttonGuardar.Image = null;
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        egreso.agregar();
                        MessageBox.Show("Egreso guardado con éxito.", "Información");

                        if (this.actualizarDataGridEvento != null)
                            this.actualizarDataGridEvento();


                        this.buttonGuardar.Text = "Terminar";
                        this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                        this.buttonGuardar.Image = null;
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe completar los campos marcados con *.", "Error");
                return;
            }
        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
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

        private void textBoxImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comprobarNumero(this, e, this.textBoxImporte.Text);
        }
    }
}
