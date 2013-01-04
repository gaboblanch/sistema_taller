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
    public partial class frmAgregarEditarIngresoGlobal : Form
    {
        private GlobalIngreso ingreso;
        private bool flagEditar;
        private int idIngreso;

        //DELEGADO Y EVENTO PARA ACTUALIZAR GRILLA EN frmGestionCliente
        public delegate void actualizarDataGrid();
        public event actualizarDataGrid actualizarDataGridEvento;

        public delegate void calcularDataGrid();
        public event calcularDataGrid calcularDataGridEvento;

        public frmAgregarEditarIngresoGlobal()
        {
            InitializeComponent();
        }

        public frmAgregarEditarIngresoGlobal(int idIngreso_p)
        {
            InitializeComponent();
            this.flagEditar = true;
            this.idIngreso = idIngreso_p;
        }

        private void frmAgregarEditarIngresoGlobal_Load(object sender, EventArgs e)
        {
            ingreso = new GlobalIngreso();
            if (flagEditar)
            {
                ingreso.IdIngreso = this.idIngreso;
                ingreso.getIngreso();

                this.dateTimePickerFecha.Value = ingreso.Fecha;
                this.textBoxDescripcion.Text = ingreso.Descripcion;
                this.textBoxImporte.Text = ingreso.Importe.ToString();
                this.comboBoxTipo.Text = ingreso.Tipo;

                this.buttonGuardar.Text = "Terminar";
                this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                this.buttonGuardar.Image = null;

            }
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

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (this.buttonGuardar.Text == "Terminar")
            {
                this.Dispose();
                return;
            }
            
            

            if (this.comboBoxTipo.Text != "" && this.textBoxImporte.Text != "")
            {
                ingreso.Fecha = this.dateTimePickerFecha.Value;
                ingreso.Importe = Convert.ToDouble(this.textBoxImporte.Text);
                ingreso.Descripcion = this.textBoxDescripcion.Text.ToUpper();
                ingreso.Tipo = this.comboBoxTipo.Text;

                if (flagEditar)
                {
                    try
                    {
                        ingreso.actualizar();
                        MessageBox.Show("Ingreso actualizado con éxito.", "Información");
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
                        ingreso.agregar();
                        MessageBox.Show("Ingreso guardado con éxito.", "Información");

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
                MessageBox.Show("Debe completar los campos marcados con *.","Error");
                return;
            }
        }

        private void textBoxImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comprobarNumero(this, e, this.textBoxImporte.Text);
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

        private void textBoxDescripcion_TextChanged(object sender, EventArgs e)
        {
            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        
    }
}
