using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SistemaGestionTaller
{
    public partial class frmBuscarProveedor : Form
    {
        private Proveedor proveedor;
        private int IdProveedor;
        private string razonsocialProveedor;

        // DELEGACION
        public delegate void BuscarProveedorHandler(
            object sender, BuscarProveedorEventArgs e);

        // EVENTO
        public event BuscarProveedorHandler ProveedorEncontrado;

        public frmBuscarProveedor()
        {
            InitializeComponent();
        }

        private void llenarListBox()
        {
            ArrayList colProveedor = new ArrayList();
            proveedor.Filtro = textRazonSocial.Text;

            colProveedor = proveedor.coleccion();

            this.listBoxProveedor.Items.Clear();

            for (int i = 0; i < colProveedor.Count; i++)
            {
                Proveedor objProveedorLocal = new Proveedor();

                objProveedorLocal = (Proveedor)colProveedor[i];

                this.listBoxProveedor.Items.Add(
                        objProveedorLocal.Id.ToString() + "," +
                        objProveedorLocal.NombreRazonSocial
                    );
            }
        }

        private void frmBuscarProveedor_Load(object sender, EventArgs e)
        {
            proveedor = new Proveedor();
            llenarListBox();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            llenarListBox();
        }

        private void textRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.buttonBuscar.PerformClick();
            }
        }

        private void textRazonSocial_TextChanged(object sender, EventArgs e)
        {
            llenarListBox();
        }

        private void listBoxProveedor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string curItem = this.listBoxProveedor.SelectedItem.ToString();

            IdProveedor = Convert.ToInt32(curItem.Split(',')[0]);
            razonsocialProveedor = curItem.Split(',')[1];

            BuscarProveedorEventArgs args = new BuscarProveedorEventArgs(
                IdProveedor,
                razonsocialProveedor
                );

            ProveedorEncontrado(this, args);
            
            this.Close();
        }
    }
}
