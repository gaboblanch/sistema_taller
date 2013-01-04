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
    public partial class frmBuscarCliente : Form
    {
        private Cliente cliente;

        // DELEGACION
        public delegate void BuscarClienteHandler(
            object sender, BuscarClienteEventArgs e);

        // EVENTO
        public event BuscarClienteHandler ClienteEncontrado;

        public frmBuscarCliente()
        {
            InitializeComponent();
        }

        private void llenarListBox()
        {
            ArrayList colCliente = new ArrayList();
            cliente.Filtro = this.textApellido.Text;

            colCliente = cliente.coleccion();

            this.listCliente.Items.Clear();

            for (int i = 0; i < colCliente.Count; i++)
            {
                this.listCliente.Items.Add((Cliente)colCliente[i]);
            }
        }

        private void frmBuscarCliente_Load(object sender, EventArgs e)
        {
            cliente = new Cliente();
            llenarListBox();
        }

        private void listCliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cliente = (Cliente)this.listCliente.SelectedItem;
            
            BuscarClienteEventArgs args = new BuscarClienteEventArgs(cliente);

            ClienteEncontrado(this, args);

            this.Close();
        }

        private void textApellido_TextChanged(object sender, EventArgs e)
        {
            llenarListBox();
        }


    }
}
