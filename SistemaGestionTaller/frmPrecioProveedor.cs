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
    public partial class frmPrecioProveedor : Form
    {
        private Proveedor proveedor;

        public frmPrecioProveedor()
        {
            InitializeComponent();
        }

        private void frmPrecioProveedor_Load(object sender, EventArgs e)
        {
            proveedor = new Proveedor();
        }

        private void buttonBuscarProveedor_Click(object sender, EventArgs e)
        {
            this.proveedor.Id = 0;
            this.proveedor.NombreRazonSocial = "";
            this.proveedor.Repuestos.RemoveRange(0, proveedor.Repuestos.Count);

            this.textBoxAumento.Text = "";
            this.btnGuardar.Text = "Aplicar Aumento";

            frmBuscarProveedor fbp = new frmBuscarProveedor();
            fbp.ProveedorEncontrado += new frmBuscarProveedor.BuscarProveedorHandler(fbp_ProveedorEncontrado);
            fbp.MdiParent = this.MdiParent;
            fbp.Show();
        }

        void fbp_ProveedorEncontrado(object sender, BuscarProveedorEventArgs e)
        {
            proveedor.Id = e.IdProveedor;
            proveedor.NombreRazonSocial = e.RazonSocialProveedor;

            this.textBoxProveedor.Text = proveedor.NombreRazonSocial;
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

        private void textBoxAumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comprobarNumero(this, e, this.textBoxAumento.Text);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(this.btnGuardar.Text == "Terminar")
            {
                this.Close();
                return;
            }

            if (this.textBoxAumento.Text != "")
            {
                try
                {
                    double porcentaje = 0;
                    porcentaje = Convert.ToInt32(this.textBoxAumento.Text);
                    porcentaje = porcentaje / 100;
                    proveedor.AumentoPrecio = porcentaje+1;
                    proveedor.aumentarRepuestos();

                    this.btnGuardar.Text = "Terminar";

                    MessageBox.Show("Aumento aplicado con éxito.", "Información");
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "ERROR");
                }
            }
            else
            {
                MessageBox.Show("Debe escribir un aumento para poder realizar la operación.","ERROR");
                return;
            }
        }

        private void textBoxAumento_TextChanged(object sender, EventArgs e)
        {
            this.btnGuardar.Text = "Aplicar Aumento";
        }
    }
}
