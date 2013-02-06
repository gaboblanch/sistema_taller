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
    public partial class frmAgregarEditarStockSalida : Form
    {
        private Repuesto repuesto;

        public frmAgregarEditarStockSalida()
        {
            InitializeComponent();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if(this.buttonGuardar.Text == "Terminar")
            {
                this.Close();
                return;
            }

            try
            {
                repuesto.CantidadStock = Convert.ToDouble(this.textStockDisponible.Text);
                repuesto.ObservacionAjuste = this.textObservacion.Text;
                repuesto.CantidadTemp = Convert.ToDouble(this.textBoxSalida.Text);
                repuesto.ajusteSalidaStock();

                //Cambiar aspecto del boton
                this.buttonGuardar.Text = "Terminar";
                this.buttonGuardar.TextAlign = ContentAlignment.MiddleCenter;
                this.buttonGuardar.Image = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex,"ERROR");
            }
        }

        private void frmAgregarEditarStockSalida_Load(object sender, EventArgs e)
        {
            repuesto = new Repuesto();
        }

        private void buttonBuscarRespuesto_Click(object sender, EventArgs e)
        {
            this.textBoxSalida.ResetText();
            this.textStockDisponible.Text = "0";



            frmBuscarRepuesto fbr = new frmBuscarRepuesto();
            fbr.RepuestoEncontrado += new frmBuscarRepuesto.BuscarRepuestoHandler(fbr_RepuestoEncontrado);
            fbr.MdiParent = this.MdiParent;
            fbr.Show();
            this.textBoxSalida.Focus();
        }

        void fbr_RepuestoEncontrado(object sender, BuscarRepuestoEventArgs e)
        {
            repuesto = (Repuesto)e.Repuesto;
            repuesto.getDatosRepuesto();
            this.textTipo.Text = repuesto.DescripcionTipo;
            this.textCodigo.Text = repuesto.CodigoRepuesto;
            this.textMarca.Text = repuesto.Marca;
            this.textModelo.Text = repuesto.Modelo;
            this.textStockDisponible.Text = repuesto.CantidadStock.ToString();
            this.textBoxProveedor.Text = repuesto.Proveedor.NombreRazonSocial;

            this.buttonGuardar.Image = global::SistemaGestionTaller.Properties.Resources.guardar_documento_icono_7840_48;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void textBoxSalida_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxSalida.Text == "")
            {
                this.textStockDisponible.Text = Convert.ToString(repuesto.CantidadStock - 0);
            }
            else
            {
                this.textStockDisponible.Text = Convert.ToString(repuesto.CantidadStock - Convert.ToDouble(this.textBoxSalida.Text));
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

        private void textBoxSalida_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comprobarNumero(this, e, this.textBoxSalida.Text);
        }
    }
}
