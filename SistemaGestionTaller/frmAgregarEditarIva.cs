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
    public partial class frmAgregarEditarIva : Form
    {
        private Iva iva;
        private bool flagEditar;
        private int idIva;

        //DELEGADO Y EVENTO PARA ACTUALIZAR GRILLA EN frmGestionTarea
        public delegate void actualizarDataGrid();
        public event actualizarDataGrid actualizarDataGridEvento;

        public frmAgregarEditarIva()
        {
            InitializeComponent();
        }

        public frmAgregarEditarIva(int idIva_p)
        {
            InitializeComponent();
            this.flagEditar = true;
            this.idIva = idIva_p;
        }

        private void frmAgregarEditarIva_Load(object sender, EventArgs e)
        {
            iva = new Iva();

            if (flagEditar)
            {
                iva.Id = this.idIva;
                iva.getIva();

                this.textBoxDescripcion.Text = iva.CondicionIva;
                this.textBoxPorcentaje.Text = iva.PorcentajeIva.ToString();
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (this.textBoxDescripcion.Text == "")
            {
                MessageBox.Show("Debe completar el campo descripción.","Error");
                return;
            }

            iva.CondicionIva = this.textBoxDescripcion.Text.ToUpper();

            if (this.textBoxPorcentaje.Text != "")
                iva.PorcentajeIva = Convert.ToDouble(this.textBoxPorcentaje.Text);
            else
                iva.PorcentajeIva = 0;

            if (flagEditar)
            {
                iva.actualizar();
            }
            else
            {
                iva.agregar();
            }

            if (this.actualizarDataGridEvento != null)
                this.actualizarDataGridEvento();
            this.limpiarCampos();
        }

        private void limpiarCampos()
        {
            this.textBoxPorcentaje.ResetText();
            this.textBoxDescripcion.ResetText();
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

        private void textBoxPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comprobarNumero(this, e, this.textBoxPorcentaje.Text);
        }
    }
}
